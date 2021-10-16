    using System;
using AMVCC.Controllers.FSM.Submarine.Submarine_States;
using AMVCC.Views;
using UnityEditor.Build.Player;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Jobs;

namespace AMVCC.Controllers.FSM.Submarine
{
    public class SubmarineController : SeaWarElement
    {
        private float radarRange;
        private float submarineLength;
        private Collider target;
        private SubmarineBaseState currentState;
        private SubmarineBaseState previousState;
        public SubmarineBaseState CurrentState => currentState;
        public SubmarineBaseState PreviousState => previousState;
        public readonly SubmarineMovingForwardState movingForwardState = 
            new SubmarineMovingForwardState();
        public readonly SubmarineMovingBackState movingBackState = 
            new SubmarineMovingBackState();
        public readonly SubmarineTurningState turningState = 
            new SubmarineTurningState();
        public readonly SubmarineChasingAndAttackingState chasingAndAttackingState = 
            new SubmarineChasingAndAttackingState();

        private void Start()
        {
            submarineLength = 2;

            radarRange = GetComponent<SeaWarSubmarineView>().sightRange + submarineLength/2;

            TransitionToState(movingForwardState);
    
            //InvokeRepeating("EnemyDetector",0,1);
        }
        
        public void TransitionToState(SubmarineBaseState state)
        {
            previousState = currentState;
            currentState = state;
            
            currentState.EnterState(this,target);
        }

        public void Update()
        {
            currentState.Update(this);
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
            target = other;
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
