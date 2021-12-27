using System;
using System.Collections;
using UnityEngine;
using AMVCC.Views;
using AMVCC.Models;
using DG.Tweening;
using UnityEditor.VersionControl;

namespace AMVCC.Controllers.FSM.Submarine.Submarine_States
{
    public class SubmarineMovingForwardState :SubmarineBaseState
    {
        private Tween myTween;
        private GameObject target;
        private Ease moveEase = Ease.Linear;
        private float fireRate;
        private float distance;
        private SubmarineController submarine;
        private SpawnController spawnController;
        private float radarTimer;
        private float rotateDuration = 1f;
        public void Start(SubmarineController submarine)
        {
        }
        public void Enable(SubmarineController submarine)
        {
            //this.submarine = submarine;
        }

        
        public void EnterState(SubmarineController submarine, GameObject other)
        {
            submarine.isAttackState = false;
            Debug.Log(submarine.CurrentState + " " + submarine.tag);

            radarTimer = submarine.Application.model.submarineModel.fireRate;

            spawnController = submarine.GetComponent<SubmarineController>().spawnController;
            this.submarine = submarine;
            submarine.StartCoroutine(Move(submarine));
            /*if (target == null)
            {
                target = other;
            }*/
            //submarine.TransitionToState(submarine.turningState);
            //SetTarget();

        }
        private void SetTarget()
        {
//            Debug.Log("1");
            if (submarine.gameObject.CompareTag("Blue") && spawnController.spawnedSeaCraftsRed.Count > 0)
            {
               // Debug.Log("2");

                if (target == null)
                {
                  //  Debug.Log("3");
                  GameObject peekTarget = (GameObject)spawnController.spawnedSeaCraftsRed.Peek();
                  if (peekTarget != null)
                    {
                        //Debug.Log("4");

                        //Debug.Log("set target Blue");

                        target = (GameObject)spawnController.spawnedSeaCraftsRed.Peek();
                       // Debug.Log(spawnController.spawnedSeaCraftsRed.Count + "in submarine controller Red");
                    }
                }
            }
            
            else if (submarine.gameObject.CompareTag("Red") && spawnController.spawnedSeaCraftsBlue.Count > 0)
            {
                //Debug.Log("6");

                if (target == null)
                {
                   // Debug.Log("7");
                   GameObject peekTarget = (GameObject)spawnController.spawnedSeaCraftsBlue.Peek();
                   if (peekTarget != null)
                   {
                     //   Debug.Log("8");

                       // Debug.Log("set target Red");

                        target = (GameObject)spawnController.spawnedSeaCraftsBlue.Peek();
                       // Debug.Log(spawnController.spawnedSeaCraftsBlue.Count + "in spawn controller Blue");

                   }
                }
            }
        }
        private IEnumerator Move(SubmarineController submarine)
        {
            float speed = submarine.GetComponent<SeaWarSubmarineView>().speed;
            Vector3 nextDestination = submarine.Application.model.submarineModel.middleMap.transform.position; 
            myTween = submarine.transform.DOMoveX(nextDestination.x,Vector3.Distance(submarine.transform.position,nextDestination)/submarine.CalculateCurrentSpeed()).SetEase(moveEase).OnComplete(Turning);
            //yield return new WaitForSeconds((Vector3.Distance(submarine.transform.position,nextDestination))/speed);
            yield return myTween.WaitForCompletion();
        }

        private void Turning()
        {
            submarine.TransitionToState(submarine.turningState, target);
        }
        /*private IEnumerator TurningCoroutine()
        {
            Quaternion targetRotationAngle = Quaternion.LookRotation(submarine.transform.forward * -1 ,Vector3.up);

            if (target)
            {
                Tweener rotateForward = submarine.transform.DORotateQuaternion(targetRotationAngle, rotateDuration);
                yield return rotateForward.WaitForCompletion();
                submarine.TransitionToState(submarine.chasingState, target);

            }
            else if (!target)
            {
                Tweener rotateBack = submarine.transform.DORotateQuaternion(targetRotationAngle, rotateDuration);
                yield return rotateBack.WaitForCompletion();        
                submarine.TransitionToState(submarine.movingBackState, target);
            }

        }*/
        private void SetNextState()
        {
            //Debug.Log("set next state : " + submarine.tag );
            distance = submarine.transform.position.x - target.transform.position.x;
            if (submarine.CompareTag("Blue"))
            {
                if (submarine.transform.forward == target.transform.forward)
                {
                    if (distance > 0)
                    {
                        submarine.TransitionToState(submarine.chasingState, target);

                    }
                    else if (distance < 0)
                    {
                        submarine.TransitionToState(submarine.turningState, target);
                        
                    }
                }
                else if (submarine.transform.forward != target.transform.forward)
                {
                    if (distance > 0)
                    {
                        submarine.TransitionToState(submarine.chasingState, target);

                    }
                    else if (distance < 0)
                    {
                        submarine.TransitionToState(submarine.turningState, target);
                    }
                }
                
            }
            else if (submarine.CompareTag("Red"))
            {
                if (submarine.transform.forward == target.transform.forward)
                {
                    if (distance > 0)
                    {
                        submarine.TransitionToState(submarine.turningState, target);

                    }
                    else if (distance < 0)
                    {
                        submarine.TransitionToState(submarine.chasingState, target);

                    }
                }
                else if (submarine.transform.forward != target.transform.forward)
                {
                    if (distance > 0)
                    {
                        submarine.TransitionToState(submarine.turningState, target);

                    }
                    else if (distance < 0)
                    {
                        submarine.TransitionToState(submarine.chasingState, target);

                    }
                }
            }
            
        }

    
        public void FixedUpdate(SubmarineController submarine)
        {
            if (target)
            {
                distance = submarine.transform.position.x - target.transform.position.x;
                //if (Mathf.Abs(distance) < 1)
                //{
                    submarine.transform.DOKill();
                    submarine.TransitionToState(submarine.turningState,target);
                //}
            }
            
        }

        public void OnTriggerEnter(SubmarineController submarine, Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts"))
            {
                if (!other.CompareTag(submarine.tag))
                {
                    if (!target)
                    {
                        target = other.gameObject;
                        
                    }
                }
            }
        }

        public void OnTriggerStay(SubmarineController submarine, Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts"))
            {
                if (!other.CompareTag(submarine.tag))
                {
                    if (!target)
                    {
                        target = other.gameObject;
                        
                    }
                }
            }
        }
        public void OnTriggerExit(SubmarineController submarine, Collider other)
        {
            
        }
    }
}
