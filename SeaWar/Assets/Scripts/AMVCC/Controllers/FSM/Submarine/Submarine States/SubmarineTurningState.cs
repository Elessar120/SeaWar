using System.Collections;
using UnityEngine;
using AMVCC.Views;
using DG.Tweening;
namespace AMVCC.Controllers.FSM.Submarine.Submarine_States
{
    public class SubmarineTurningState : SubmarineBaseState
    {
        private float rotateDuration;
        public void Start(SubmarineController submarine)
        {
        }
        public void EnterState(SubmarineController submarine)
        {
            rotateDuration = .9f;
            Debug.Log(submarine.CurrentState);

           submarine.StartCoroutine(Rotate(submarine));


            

        }

        private IEnumerator Rotate(SubmarineController submarine)
        {
            Quaternion targetRotationAngle = Quaternion.LookRotation(submarine.transform.forward * -1 ,Vector3.up);

            if (submarine.PreviousState == submarine.movingForwardState || submarine.PreviousState == submarine.chasingAndAttackingState)
            {
                submarine.transform.DORotateQuaternion(targetRotationAngle, rotateDuration);
                yield return new WaitForSeconds(rotateDuration + 0.1f);
                submarine.TransitionToState(submarine.movingBackState);

            }

            else if (submarine.PreviousState == submarine.movingBackState)
            {
                submarine.transform.DORotateQuaternion(targetRotationAngle, rotateDuration);
                yield return new WaitForSeconds(rotateDuration + 0.1f);
                submarine.TransitionToState(submarine.movingForwardState);



            }

        }

        public void Update(SubmarineController submarine)
        {
           
           
        }

        public void OnTriggerEnter(SubmarineController submarine, Collider other)
        {
            
        }

        public void OnTriggerStay(SubmarineController submarine, Collider other)
        {
            
        }

        public void OnTriggerExit(SubmarineController submarine, Collider other)
        {
            
        }

        

        public void Enable(SubmarineController submarine)
        {
            throw new System.NotImplementedException();
        }
    }
}