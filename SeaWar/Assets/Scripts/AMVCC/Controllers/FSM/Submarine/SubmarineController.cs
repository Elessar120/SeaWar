    using System;
    using System.Collections.Generic;
    using AMVCC.Controllers.FSM.Submarine.Submarine_States;
    using AMVCC.Models;
    using AMVCC.Views;
    using UnityEngine;
    using DG.Tweening;
namespace AMVCC.Controllers.FSM.Submarine
{
    public class SubmarineController : SeaWarElement
    {
        public GameObject torpedo;
        public Transform torpedoLauncher;
        private List<GameObject> effectiveMagneticTowers;
        public Action <GameObject> onEffectedByMagneticTower;
        public Action<GameObject> onAttackAction;
        [SerializeField] float currentSpeed;
        public SeaWarSubmarineModel submarineModel;
        public SeaWarSubmarineView submarineView;
        private float radarRange;
        private float submarineLength;
        private GameObject target;
        private Vector3 targetPosition;
        public SpawnController spawnController;
        [SerializeField] private GameObject selfMesh;
        public GameObject backRayCastingPoint;  
        public GameObject frontRayCastingPoint;  
        private SubmarineBaseState currentState;
        private SubmarineBaseState previousState;
        private SubmarineBaseState lastStateBeforeChase;
        public float fireRate;
        private float radarTimer;
        private float distance;
        public bool isAttackState;
        private float rotateDuration;
            public bool lastIsAttackStateBool;
        //private SubmarineBaseState previousPreviousState;
        public SubmarineBaseState CurrentState => currentState;
        public SubmarineBaseState PreviousState => previousState;
        
        public SubmarineBaseState LastStateBeforeChase => lastStateBeforeChase;
        public readonly SubmarineMovingForwardState movingForwardState = 
            new SubmarineMovingForwardState();
        public readonly SubmarineMovingBackState movingBackState = 
            new SubmarineMovingBackState();
        public readonly SubmarineTurningState turningState = 
            new SubmarineTurningState();
        public readonly SubmarineAttackingState attackingState = 
            new SubmarineAttackingState();
        public readonly SubmarineChasingState chasingState = 
            new SubmarineChasingState();

        [SerializeField] private Collider submarineCollider;
        public SubmarineRotationController rotationController;
        private void Awake()
        {
            spawnController = FindObjectOfType<SpawnController>().gameObject.GetComponent<SpawnController>();
        }

        private void SetSeaCraftsToQueue()
        {
            
        }
        private void Start()
        {
            onAttackAction += Launch;
            effectiveMagneticTowers = new List<GameObject>();
            onEffectedByMagneticTower += AddMagneticTowerToList;
            currentSpeed = submarineView.speed;   
            rotateDuration = 1f;
            submarineModel = FindObjectOfType<SeaWarSubmarineModel>();
            submarineLength = 2;
            //radarTimer = Application.model.submarineModel.fireRate;
    
            radarRange = GetComponent<SeaWarSubmarineView>().sightRange + submarineLength/2;
            fireRate = GetComponent<SeaWarSubmarineView>().fireRate;
                TransitionToState(movingForwardState, target);
        }
        private void AddMagneticTowerToList(GameObject magneticTower)
        {
            if (!effectiveMagneticTowers.Contains(magneticTower))
            {
                effectiveMagneticTowers.Add(magneticTower);

            }
            Debug.Log("lists count = " + effectiveMagneticTowers.Count + " " + magneticTower.name);
        }
        public float CalculateCurrentSpeed()
        {
            
            currentSpeed = submarineView.speed;
//            Debug.Log(effectiveMagneticTowers.Count);
            for (int i = 0; i < effectiveMagneticTowers.Count; i++)
            {
                if (!effectiveMagneticTowers[i])
                {
                    effectiveMagneticTowers.RemoveAt(i);

                }
                else
                {
                    currentSpeed *= Application.model.magneticTowerModel.enemyCoenfficientSlowDown;

                }


            }

            return currentSpeed;
        }
      
     public void TransitionToState(SubmarineBaseState state, GameObject target)
        {
            //previousPreviousState = previousState;
            previousState = currentState;
            currentState = state;
            if ((currentState == chasingState) &&
                (previousState == movingForwardState || previousState == movingBackState))
            {
                lastStateBeforeChase = previousState;
            }
            currentState.EnterState(this, target);
            
           
        }

    
        public void FixedUpdate()
        {
            
            currentState.FixedUpdate(this);

            /*if (isAttackState)
            {

                //Chase(submarine,target.GetComponent<Collider>());

                /*if (distance < 1 && distance > -1)
                {
                    StopMoving();
                }#1#

                //Debug.Log(distance);
                if (CompareTag("Blue")) //todo each submarine forward direction like turning state
                {
                    if (distance > 4) //todo bool false and move update to chase statement
                    {
                        lastIsAttackStateBool = isAttackState;

                        isAttackState = false;
                        TransitionToState(turningState, target);
                        Debug.Log("1- target : " + target.name);

                        //isInRange = false; 
                    }

                    else if (distance < -4) //todo bool false
                    {
                        isAttackState = false;
                        //TransitionToState(chasingState, target);
                    }

                }
                else if (CompareTag("Red"))
                {
                    if (distance > 4) //todo bool false
                    {
                        isAttackState = false;
                        //TransitionToState(chasingState,target);
                        //isInRange = false; 
                    }
                    else if (distance < -4) //todo bool false
                    {
                        lastIsAttackStateBool = isAttackState;
                        isAttackState = false;
                        TransitionToState(turningState, target);
                        Debug.Log("2- target : " + target.name);

                    }
                }
            }*/

                
                    //Debug.Log(target.name);
                    if (currentState == chasingState)
                    {
                       // Debug.Log("attackingState");
                        fireRate -= Time.deltaTime;
                        if (fireRate < 0)
                        {

                            fireRate = submarineView.fireRate;
                            submarineView.isAttackTime = true;
                        }
                    }
                    
                    
                
                /*else if (target == null)
                {
                    SetTarget();
                    if (target == null)
                    {
                        TransitionToState(turningState,target);
    
                    }

                }*/
           
                
                
            }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(backRayCastingPoint.transform.position, transform.forward * -3);
            Gizmos.DrawRay(frontRayCastingPoint.transform.position, transform.forward * 30);
        }
        
        public void OnTriggerEnter(Collider other)
        {
          
            currentState.OnTriggerEnter(this, other);   
        }
        public void OnTriggerStay(Collider other)
        {
           
            currentState.OnTriggerStay(this, other);

        }


        public void OnTriggerExit(Collider other)
        {
            /*if (!other.CompareTag(gameObject.tag) &&
                (other.name == "Submarine(Clone)" || other.name == "OilTanker(Clone)" ||
                 other.name == "BattleShip(Clone)" || other.name == "SmallBattleship(Clone)" ||
                 other.name == "MotorBoat(Clone)" ))
            {
                Debug.Log(other.name + other.tag);

                //Chase(submarine,hit.collider);
                //SetFireRate(submarine,hit.collider);
            }        */
            currentState.OnTriggerExit(this, other);

        }
        private void Launch(GameObject target)
        {
            //trench.GetComponent<SeaWarHealthView>().TakeDamage(damage);
            TorpedoSpawner(target);
                        
        }
        private void TorpedoSpawner(GameObject target)
        {
            GameObject spawnedTorpedo = Instantiate(torpedo,torpedoLauncher.position,torpedoLauncher.rotation);
            spawnedTorpedo.GetComponent<SeaWarSubmarineTorpedoMoveController>().target = target;
            spawnedTorpedo.GetComponent<SeaWarSubmarineTorpedoAttackController>().target = target;
           
        }

       
    }
    
    
}
