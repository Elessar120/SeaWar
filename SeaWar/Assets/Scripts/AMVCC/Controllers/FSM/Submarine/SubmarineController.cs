    using System;
    using System.Linq.Expressions;
    using AMVCC.Controllers.FSM.Submarine.Submarine_States;
    using AMVCC.Models;
    using AMVCC.Views;
using UnityEditor.Build.Player;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Jobs;

namespace AMVCC.Controllers.FSM.Submarine
{
    public class SubmarineController : SeaWarElement
    {
        public SeaWarSubmarineModel submarineModel;
        public SeaWarSubmarineView submarineView;
        private float radarRange;
        private float submarineLength;
        private GameObject target;
        [SerializeField] SpawnController spawnController;
        [SerializeField] private GameObject selfMesh;
        [SerializeField] private GameObject forwardRayCastingPoint;
        [SerializeField] private GameObject backwardRayCastingPoint;
        private SubmarineBaseState currentState;
        private SubmarineBaseState previousState;
        private SubmarineBaseState previousPreviousState;
        public SubmarineBaseState CurrentState => currentState;
        public SubmarineBaseState PreviousState => previousState;
        public SubmarineBaseState PreviousPreviousState => previousPreviousState;
        public readonly SubmarineMovingForwardState movingForwardState = 
            new SubmarineMovingForwardState();
        public readonly SubmarineMovingBackState movingBackState = 
            new SubmarineMovingBackState();
        public readonly SubmarineTurningState turningState = 
            new SubmarineTurningState();
        public readonly SubmarineChasingAndAttackingState chasingAndAttackingState = 
            new SubmarineChasingAndAttackingState();

        [SerializeField] private Collider submarineCollider;

        private void Awake()
        {
            spawnController = FindObjectOfType<SpawnController>().gameObject.GetComponent<SpawnController>();
            
        }

        private void SetSeaCraftsToQueue()
        {
            
        }
        private void Start()
        {
            submarineModel = FindObjectOfType<SeaWarSubmarineModel>();
            submarineLength = 2;

            radarRange = GetComponent<SeaWarSubmarineView>().sightRange + submarineLength/2;

            TransitionToState(movingForwardState);
            forwardRayCastingPoint.transform.localPosition +=
                new Vector3(0, 0, selfMesh.GetComponent<MeshRenderer>().bounds.extents.z *3/8.25f);
            backwardRayCastingPoint.transform.localPosition -= new Vector3(0, 0,
                selfMesh.GetComponent<MeshRenderer>().bounds.extents.z * 3 / 7f);
            //InvokeRepeating("EnemyDetector",0,1);
        }

        private void OnEnable()
        {
            SetTarget();
        }

        private void SetTarget()
        {
            if (gameObject.CompareTag("Blue"))
            {
                if (target == null)
                {
                    
                    if (spawnController.spawnedSeaCraftsRed.Peek() != null)
                    {
                        target = (GameObject)spawnController.spawnedSeaCraftsRed.Peek();
                        Debug.Log(spawnController.spawnedSeaCraftsRed.Count + "in submarine controller Red");


                    }
                    else if (spawnController.spawnedSeaCraftsRed.Peek() == null)
                    {
                        throw new Exception("Red queue peek is null");
                    }

                }
            }
            else if (gameObject.CompareTag("Red"))
            {
                if (target == null)
                {
                    if (spawnController.spawnedSeaCraftsBlue.Peek() != null)
                    {
                        target = (GameObject)spawnController.spawnedSeaCraftsBlue.Peek();
                        Debug.Log(spawnController.spawnedSeaCraftsBlue.Count + "in spawn controller Blue");


                    }
                    else if (spawnController.spawnedSeaCraftsBlue == null)
                    {
                        throw new Exception("Blue queue peek is null");
                    }

                }
            }
        }

        public void TransitionToState(SubmarineBaseState state)
        {
            previousPreviousState = previousState;
            previousState = currentState;
            currentState = state;
            
            currentState.EnterState(this,target);
        }

        public void Update()
        {
            currentState.Update(this);
            /*RaycastHit hit;
            Ray forwardRay = new Ray(forwardRayCastingPoint.transform.position , transform.forward);
            Ray backwardRay = new Ray(backwardRayCastingPoint.transform.position , transform.forward * -1);
            Debug.DrawRay(forwardRayCastingPoint.transform.position,transform.forward * 3, Color.red);
            Debug.DrawRay(backwardRayCastingPoint.transform.position,transform.forward * -3, Color.red);
            Debug.Log("update");
            if (Physics.Raycast(forwardRay,out hit, 3f))
            {
                if (!hit.collider.CompareTag(GetComponent<SeaWarSubmarineView>().tag) &&
                    (hit.collider.name == "Submarine(Clone)" || hit.collider.name == "OilTanker(Clone)" ||
                     hit.collider.name == "BattleShip(Clone)" || hit.collider.name == "SmallBattleship(Clone)" ||
                     hit.collider.name == "MotorBoat(Clone)" ))
                {
                    Debug.Log(hit.collider.name + hit.collider.tag);
                    TransitionToState(chasingAndAttackingState);
                    //Chase(submarine,hit.collider);
                    //SetFireRate(submarine,hit.collider);
                }

               
            } if (Physics.Raycast(backwardRay,out hit, 3f))
            {
                if (!hit.collider.CompareTag(GetComponent<SeaWarSubmarineView>().tag) &&
                    (hit.collider.name == "Submarine(Clone)" || hit.collider.name == "OilTanker(Clone)" ||
                     hit.collider.name == "BattleShip(Clone)" || hit.collider.name == "SmallBattleship(Clone)" ||
                     hit.collider.name == "MotorBoat(Clone)" ))
                {
                    Debug.Log(hit.collider.name + hit.collider.tag);
                    TransitionToState(chasingAndAttackingState);
                    //Chase(submarine,hit.collider);
                    //SetFireRate(submarine,hit.collider);
                }

               
            }*/ 
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position,new Vector3(8,2,4));
        }
        
        public void OnTriggerEnter(Collider other)
        {
            
            
            /*
            if (!other.CompareTag(gameObject.tag) &&
                (other.name == "Submarine(Clone)" || other.name == "OilTanker(Clone)" ||
                 other.name == "BattleShip(Clone)" || other.name == "SmallBattleship(Clone)" ||
                 other.name == "MotorBoat(Clone)" ))
            {
                Debug.Log(other.name + other.tag);

                //Chase(submarine,hit.collider);
                //SetFireRate(submarine,hit.collider);
            }*/
            if (other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts") && !other.CompareTag(gameObject.tag))
            {
                //target = other;

            }
            currentState.OnTriggerEnter(this, other);   

        }
        private void EnemyDetector()
        {

            
           
        }
        public void SetSubmarineTurnAnimationStateToTrue()
        {
//            gameObject.GetComponent<SeaWarSubmarineView>().submarineRotationAnimator.SetBool("isInRotateMod", true);
        }

        public void OnTriggerStay(Collider other)
        {
           
            currentState.OnTriggerStay(this, other);

        }
        public void TakeDamage(float damage)
        {
            SeaWarSubmarineView instance = GetComponent<SeaWarSubmarineView>();
            
            if (instance.health > Application.model.submarineModel.submarineData.damage)
            {
                instance.health -= damage;
            
            }
            else
            {
                instance.health = 0;
                Destroy(gameObject);
            }
            
        }
        public void UncheckRotationAnimatorTrigger()
        {
            gameObject.GetComponent<SeaWarSubmarineView>().submarineRotationAnimator.SetBool("isInRotateMod", false);
            if (previousState == movingForwardState )
            {
                TransitionToState(movingBackState);
            }
            else if (previousState == movingBackState)
            {
                TransitionToState(movingForwardState);
            }
            else if (previousState == chasingAndAttackingState)
            {
                TransitionToState(movingBackState);

            }
            if (PreviousState == chasingAndAttackingState)
            {
               TransitionToState(movingBackState);
            }
            //Debug.Log("event");
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

       
    }
    
    
}
