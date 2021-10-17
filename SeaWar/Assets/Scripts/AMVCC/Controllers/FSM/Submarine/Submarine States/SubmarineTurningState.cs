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
        private SubmarineController submarine;
        public void Start(SubmarineController submarine)
        {
        }
        public void EnterState(SubmarineController submarine, Collider other)
        {
            this.submarine = submarine;
            rotateDuration = .9f;
            Debug.Log(submarine.CurrentState);

           submarine.StartCoroutine(Rotate(submarine));


            

        }

        private IEnumerator Rotate(SubmarineController submarine)
        {
            Quaternion targetRotationAngle = Quaternion.LookRotation(submarine.transform.forward * -1 ,Vector3.up);

            if (submarine.PreviousState == submarine.movingForwardState || submarine.PreviousState == submarine.chasingAndAttackingState)
            {
                Tweener rotateBack = submarine.transform.DORotateQuaternion(targetRotationAngle, rotateDuration).OnComplete(SetStateToAttack);
                yield return new WaitForSeconds(rotateDuration + 0.1f);
                submarine.TransitionToState(submarine.movingBackState);

            }

            else if (submarine.PreviousState == submarine.movingBackState)
            {
                Tweener rotateForward = submarine.transform.DORotateQuaternion(targetRotationAngle, rotateDuration).OnComplete(SetStateToAttack);
                yield return new WaitForSeconds(rotateDuration + 0.1f);
                submarine.TransitionToState(submarine.movingForwardState);



            }

        }

        private void SetStateToAttack()
        {
            if (isInRange)
            {
                submarine.TransitionToState(submarine.chasingAndAttackingState);
            }
        }

        public void Update(SubmarineController submarine)
        {
           
           
        }

        public void OnTriggerEnter(SubmarineController submarine, Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts") && !other.CompareTag(submarine.tag))
            {
                isInRange = true;
            }
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