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
        private float distance;
        private Collider target;
        private SubmarineController submarine;
        public void Start(SubmarineController submarine)
        {
        }
        public void EnterState(SubmarineController submarine, GameObject other)
        {
            this.submarine = submarine;
            rotateDuration = .9f;
            Debug.Log(submarine.CurrentState + " " + submarine.tag);

           submarine.StartCoroutine(Rotate(submarine));


            

        }

        private IEnumerator Rotate(SubmarineController submarine)
        {
            Quaternion targetRotationAngle = Quaternion.LookRotation(submarine.transform.forward * -1 ,Vector3.up);

            if (submarine.PreviousState == submarine.movingForwardState || submarine.PreviousState == submarine.chasingAndAttackingState)
            {
                Tweener rotateBack = submarine.transform.DORotateQuaternion(targetRotationAngle, rotateDuration);
                yield return rotateBack.WaitForCompletion();                
                if (isInRange)
                {
                    Debug.Log("is in range");
                    if (distance < 0)
                    {
                        submarine.TransitionToState(submarine.chasingAndAttackingState);

                    }
                    else if (distance > 0)
                    {
                        submarine.TransitionToState(submarine.turningState);

                    }
                }
                else
                {
                    submarine.TransitionToState(submarine.movingBackState);

                }
            }

            else if (submarine.PreviousState == submarine.movingBackState)
            {
                Tweener rotateForward = submarine.transform.DORotateQuaternion(targetRotationAngle, rotateDuration);
                yield return rotateForward.WaitForCompletion();
                if (isInRange)
                {
                    Debug.Log("is in range");

                    if (distance < 0)
                    {
                        submarine.TransitionToState(submarine.turningState);

                    }
                    else if (distance > 0)
                    {
                        submarine.TransitionToState(submarine.chasingAndAttackingState);


                    }
                }
                else
                {
                    submarine.TransitionToState(submarine.movingForwardState);
                }
            }
            else if (submarine.PreviousState == submarine.turningState)
            {
                Tweener rotateBack = submarine.transform.DORotateQuaternion(targetRotationAngle, rotateDuration);
                yield return rotateBack.WaitForCompletion();
                if (target == null)
                {
                    if (submarine.PreviousPreviousState == submarine.movingForwardState)
                    {
                        submarine.TransitionToState(submarine.movingForwardState);
                    }
                    else if (submarine.PreviousPreviousState == submarine.movingBackState)
                    {
                        submarine.TransitionToState(submarine.movingBackState);  
                    }
                }
            }

        }
        public void Update(SubmarineController submarine)
        {
           
           
        }

        public void OnTriggerEnter(SubmarineController submarine, Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts") && !other.CompareTag(submarine.tag))
            {
                distance = Vector3.Distance(submarine.transform.position ,other.transform.position);
                if (target == null)
                {
                    target = other;

                }
                isInRange = true;
            }
        }

        public void OnTriggerStay(SubmarineController submarine, Collider other)
        {
            
        }

        public void OnTriggerExit(SubmarineController submarine, Collider other)
        {
            if (submarine.gameObject.layer == LayerMask.NameToLayer("Sea Crafts") && !other.CompareTag(submarine.tag))
            {
                if (other == target)
                {
                    target = null;
                }
            }
        }

        

        public void Enable(SubmarineController submarine)
        {
            throw new System.NotImplementedException();
        }
    }
}