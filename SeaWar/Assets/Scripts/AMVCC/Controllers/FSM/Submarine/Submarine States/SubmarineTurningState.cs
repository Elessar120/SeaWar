using System;
using System.Collections;
using UnityEngine;
using AMVCC.Views;
using DG.Tweening;
namespace AMVCC.Controllers.FSM.Submarine.Submarine_States
{
    public class SubmarineTurningState : SubmarineBaseState
    {
        private float rotateDuration;
        private bool isInRange;
        //private float mapPosition;
        private GameObject target;
        private SubmarineController submarine;
        private  SubmarineBaseState beforeTurningState;
        public SubmarineBaseState BeforeTurningState => beforeTurningState;
        public void Start(SubmarineController submarine)
        {
            
        }
        public void EnterState(SubmarineController submarine, GameObject other)
        {
            beforeTurningState = submarine.PreviousState;
            if (target == null)
            {
                target = other;
            }
            this.submarine = submarine;
            rotateDuration = 1f;
            Debug.Log(submarine.CurrentState + " " + submarine.tag);

           submarine.StartCoroutine(Rotate(submarine));
        }

        private IEnumerator Rotate(SubmarineController submarine)
        {
            //Debug.Log("transform.forward = " + submarine.transform.forward + " " + submarine.tag);
            //Debug.Log("vector3.right = " + Vector3.right + " " + submarine.tag);
            //Debug.Log("vector3.left = " + Vector3.left + " " + submarine.tag);
            Quaternion targetRotationAngle = Quaternion.LookRotation(submarine.transform.forward * -1 ,Vector3.up);
            if (target == null)
            {
               // Debug.Log("target is null : " + submarine.tag);
                if (submarine.PreviousState == submarine.movingForwardState)
                {
                    Tweener rotateBack = submarine.transform.DORotateQuaternion(targetRotationAngle, rotateDuration);
                    yield return rotateBack.WaitForCompletion();        
                    submarine.TransitionToState(submarine.movingBackState, target);
                    //Debug.Log("1 " + submarine.tag);
                }

                else if (submarine.PreviousState == submarine.movingBackState)
                {
                    Tweener rotateForward = submarine.transform.DORotateQuaternion(targetRotationAngle, rotateDuration);
                    yield return rotateForward.WaitForCompletion();
                    submarine.TransitionToState(submarine.movingForwardState, target);
                    //Debug.Log("2 " + submarine.tag);

                } 
                else if (submarine.PreviousState == submarine.chasingState)
                {
                    float mapPosition = submarine.transform.position.x - submarine.Application.model.submarineModel.middleMap.transform.position.x;
                    Debug.Log("target is null and turning state");

                   // Tweener rotateForward = submarine.transform.DORotateQuaternion(targetRotationAngle, rotateDuration);
                    //yield return rotateForward.WaitForCompletion();
                    if (submarine.CompareTag("Blue"))
                    {
                        if (submarine.transform.forward == Vector3.right)
                        {
                            if (mapPosition > 0)
                            {
                                Tweener rotateForward = submarine.transform.DORotateQuaternion(targetRotationAngle, rotateDuration);
                                yield return rotateForward.WaitForCompletion();
                                submarine.TransitionToState(submarine.movingBackState, target);
                                //Debug.Log("mapPosition > 0");
                                //Debug.Log("3 " + submarine.tag);

                            }
                            else if (mapPosition < 0)
                            {
                                submarine.TransitionToState(submarine.movingForwardState, target);
                                // Debug.Log("mapPosition < 0");
                                //Debug.Log("4 " + submarine.tag);

                            }
                            //submarine.TransitionToState(submarine.movingBackState,target);
                        }
                        else if (submarine.transform.forward == Vector3.left)
                        {
                            if (mapPosition > 0)
                            {
                                submarine.TransitionToState(submarine.movingBackState, target);
                                //Debug.Log("mapPosition > 0");
                                //Debug.Log("5 " + submarine.tag);

                            }
                            else if (mapPosition < 0)
                            {
                                Tweener rotateForward = submarine.transform.DORotateQuaternion(targetRotationAngle, rotateDuration);
                                yield return rotateForward.WaitForCompletion();
                                submarine.TransitionToState(submarine.movingForwardState, target);
                                // Debug.Log("mapPosition < 0");
                                //Debug.Log("6 " + submarine.tag);

                            }
                            //submarine.TransitionToState(submarine.movingBackState,target);

                        }
                    }
                    else if (submarine.CompareTag("Red"))
                    {
                        if (submarine.transform.forward == Vector3.right)
                        {
                            if (mapPosition > 0)
                            {
                                Tweener rotateForward = submarine.transform.DORotateQuaternion(targetRotationAngle, rotateDuration);
                                yield return rotateForward.WaitForCompletion();
                                submarine.TransitionToState(submarine.movingForwardState, target);
                                //Debug.Log("mapPosition > 0");
                               // Debug.Log("7 " + submarine.tag);

                            }
                            else if (mapPosition < 0)
                            {
                                submarine.TransitionToState(submarine.movingBackState, target);
                                // Debug.Log("mapPosition < 0");
                                //Debug.Log("8 " + submarine.tag);

                            }
                        }
                        else if (submarine.transform.forward == Vector3.left)
                        {
                            if (mapPosition > 0)
                            {
                                submarine.TransitionToState(submarine.movingForwardState, target);
                                //Debug.Log("mapPosition > 0");
                               // Debug.Log("9 " + submarine.tag);

                            }
                            else if (mapPosition < 0)
                            {
                                Tweener rotateForward = submarine.transform.DORotateQuaternion(targetRotationAngle, rotateDuration);
                                yield return rotateForward.WaitForCompletion();
                                submarine.TransitionToState(submarine.movingBackState, target);
                                // Debug.Log("mapPosition < 0");
                                //Debug.Log("10 " + submarine.tag);

                            }
                        }
                    }
                   
                }
            }
            else if (target)
            {
//                Debug.Log("target is full : " + submarine.tag);

                 if (submarine.PreviousState == submarine.chasingState) //in chase state face is to enemy always
                 {
                    float mapPosition = submarine.transform.position.x - target.transform.position.x;
                    Debug.Log("map position : " + mapPosition);

                    Tweener rotateForward = submarine.transform.DORotateQuaternion(targetRotationAngle, rotateDuration);
                    yield return rotateForward.WaitForCompletion();
                    submarine.TransitionToState(submarine.chasingState,target);
                    //if (mapPosition > 0)
                    //{
                       // submarine.TransitionToState(submarine.movingBackState, target);
                        //Debug.Log("mapPosition > 0");
                        //Debug.Log("11 " + submarine.tag);

                    //}
                    //else if (mapPosition < 0)
                    //{
                       // submarine.TransitionToState(submarine.movingForwardState, target);
                        // Debug.Log("mapPosition < 0");
                        //Debug.Log("12 " + submarine.tag);

                    //}
                 }
                 /*else if (submarine.PreviousState == submarine.attackingState) 
                 {
                    float distance = submarine.transform.position.x - target.transform.position.x;
                    //Debug.Log("map position : " + mapPosition);
                    if (submarine.CompareTag("Blue"))
                    {
                        if (submarine.transform.forward == target.transform.forward)
                        {
                            submarine.TransitionToState(submarine.chasingState, target);
                        }
                        else if (submarine.transform.forward != target.transform.forward)
                        {
                            Tweener rotateForward = submarine.transform.DORotateQuaternion(targetRotationAngle, rotateDuration);
                            yield return rotateForward.WaitForCompletion();
                            submarine.TransitionToState(submarine.chasingState,target);
                        }
                    }
                    else if (submarine.CompareTag("Red"))
                    {
                        if (submarine.transform.forward == target.transform.forward)
                        {
                            submarine.TransitionToState(submarine.chasingState,target);

                        }
                        else if (submarine.transform.forward != target.transform.forward)
                        {
                            Tweener rotateForward = submarine.transform.DORotateQuaternion(targetRotationAngle, rotateDuration);
                            yield return rotateForward.WaitForCompletion();
                            submarine.TransitionToState(submarine.chasingState,target);
                        }
                    }                           
                 }*/
                 else if (submarine.PreviousState == submarine.movingForwardState)
                 {
                     float distance = target.transform.position.x - submarine.transform.position.x;
                     if (submarine.CompareTag("Blue"))
                     {
                         if (submarine.transform.forward == target.transform.forward)
                         {
                             if (distance > 0)
                             {
                                 
                             }
                             else if (distance < 0)
                             {
                                 
                             }
                         }
                         else if (submarine.transform.forward != target.transform.forward)
                         {
                             if (distance > 0)
                             {
                                 
                             }
                             else if (distance < 0)
                             {
                                 
                             }
                         }
                     }
                     else if (submarine.CompareTag("Red"))
                     {
                         if (submarine.transform.forward == target.transform.forward)
                         {
                             if (distance > 0)
                             {
                                 
                             }
                             else if (distance < 0)
                             {
                                 
                             }
                         }
                         else if (submarine.transform.forward != target.transform.forward)
                         {
                             if (distance > 0)
                             {
                                 
                             }
                             else if (distance < 0)
                             {
                                 
                             }
                         }
                     }
                     //todo turn and after chase or chase directly   
                     /*Tweener rotateForward = submarine.transform.DORotateQuaternion(targetRotationAngle, rotateDuration);
                     yield return rotateForward.WaitForCompletion();*/
                     submarine.TransitionToState(submarine.chasingState,target);
                 }
                 else if (submarine.PreviousState == submarine.movingBackState)
                 {
                  //todo turn and after chase or chase directly   
                  /*Tweener rotateBack = submarine.transform.DORotateQuaternion(targetRotationAngle, rotateDuration);
                  yield return rotateBack.WaitForCompletion(); */     
                  submarine.TransitionToState(submarine.chasingState,target);
                 }
            }
        }
        public void FixedUpdate(SubmarineController submarine)
        {
           
           
        }

        public void OnTriggerEnter(SubmarineController submarine, Collider other)
        {
            /*if (other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts") && !other.CompareTag(submarine.tag))
            {
                distance = Vector3.Distance(submarine.transform.position ,other.transform.position);
                if (target == null)
                {
                    target = other.gameObject;

                }
                isInRange = true;
            }*/
        }

        public void OnTriggerStay(SubmarineController submarine, Collider other)
        {
            
        }

        public void OnTriggerExit(SubmarineController submarine, Collider other)
        {
            /*if (submarine.gameObject.layer == LayerMask.NameToLayer("Sea Crafts") && !other.CompareTag(submarine.tag))
            {
                if (other == target)
                {
                    target = null;
                }
            }*/
        }

        

        public void Enable(SubmarineController submarine)
        {
            throw new System.NotImplementedException();
        }
    }
}