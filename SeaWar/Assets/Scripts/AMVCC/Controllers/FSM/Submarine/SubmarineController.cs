﻿using System;
using AMVCC.Controllers.FSM.Submarine.Submarine_States;
using AMVCC.Views;
using UnityEditor.Build.Player;
using UnityEngine;

namespace AMVCC.Controllers.FSM.Submarine
{
    public class SubmarineController : SeaWarElement
    {
        private SubmarineBaseState currentState;
        private SubmarineBaseState previousState;
        public SubmarineBaseState CurrentState => currentState;
        public SubmarineBaseState PreviousState => previousState;
        public readonly SubmarineMovingForwardState movingForwardState = new SubmarineMovingForwardState();
        public readonly SubmarineMovingBackState movingBackState = new SubmarineMovingBackState();
        public readonly SubmarineTurningState turningState = new SubmarineTurningState();
        public readonly SubmarineChasingAndAttackingState chasingAndAttackingState =
            new SubmarineChasingAndAttackingState();

        private void Start()
        {
            TransitionToState(movingForwardState);
        }

        public void TransitionToState(SubmarineBaseState state)
        {
            previousState = currentState;
            currentState = state;
            currentState.EnterState(this);
        }

        public void Update()
        {
            currentState.Update(this);
            
        }

        public void OnTriggerEnter(Collider other)
        {
         
            if (!other.CompareTag(gameObject.tag) &&
                (other.name == "Submarine(Clone)" || other.name == "OilTanker(Clone)" ||
                 other.name == "BattleShip(Clone)" || other.name == "SmallBattleship(Clone)" ||
                 other.name == "MotorBoat(Clone)" ))
            {
                Debug.Log(other.name + other.tag);
                currentState.OnTriggerEnter(this);

                //Chase(submarine,hit.collider);
                //SetFireRate(submarine,hit.collider);
            }
            
        }
        
        public void SetSubmarineTurnAnimationStateToTrue()
        {
            gameObject.GetComponent<SeaWarSubmarineView>().submarineRotationAnimator.SetBool("isInRotateMod", true);
        }

        public void OnTriggerStay(Collider other)
        {
            currentState.OnTriggerStay(this);

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
            //Debug.Log("event");
        }
      

        public void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag(gameObject.tag) &&
                (other.name == "Submarine(Clone)" || other.name == "OilTanker(Clone)" ||
                 other.name == "BattleShip(Clone)" || other.name == "SmallBattleship(Clone)" ||
                 other.name == "MotorBoat(Clone)" ))
            {
                Debug.Log(other.name + other.tag);
                currentState.OnTriggerExit(this);

                //Chase(submarine,hit.collider);
                //SetFireRate(submarine,hit.collider);
            }        }
       
  

    }
    
    
}
