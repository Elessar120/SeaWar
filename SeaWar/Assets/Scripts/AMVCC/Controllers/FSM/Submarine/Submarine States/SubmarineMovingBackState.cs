using System;
using System.Collections;
using AMVCC.Views;
using UnityEngine;
using DG.Tweening;
namespace AMVCC.Controllers.FSM.Submarine.Submarine_States
{
    public class SubmarineMovingBackState : SubmarineBaseState
    {
        private Collider target;
        private Ease moveEase = Ease.Linear;
        private float distance;
        private SubmarineController submarine;
        public void EnterState(SubmarineController submarine)
        {
            this.submarine = submarine;
            Debug.Log(submarine.CurrentState);
            submarine.StartCoroutine(Move(submarine));
        }

        private IEnumerator Move(SubmarineController submarine)
        {
            float speed = submarine.GetComponent<SeaWarSubmarineView>().speed;
            Vector3 nextDestination = submarine.gameObject.GetComponent<SeaWarSubmarineView>().startPosition;
            Debug.Log((Vector3.Distance(submarine.transform.position,nextDestination))/speed);
            Tween myTween = submarine.transform.DOMoveX(nextDestination.x,(Vector3.Distance(submarine.transform.position,nextDestination))/speed).SetEase(moveEase).OnKill(SetNextState).OnComplete(Turning);
            //yield return new WaitForSeconds((Vector3.Distance(submarine.transform.position,nextDestination))/speed);
            yield return myTween.WaitForCompletion();
           

        }

        private void Turning()
        {
            submarine.TransitionToState(submarine.turningState);

        }
        public void Update(SubmarineController submarine)
        {
            /*submarine.transform.position = Vector3.MoveTowards(submarine.transform.position,submarine.gameObject.GetComponent<SeaWarSubmarineView>().startPosition, Time.deltaTime * submarine.Application.model.submarineModel.submarineData.movmentSpeed);
            if (Vector3.Distance(submarine.transform.position, submarine.GetComponent<SeaWarSubmarineView>().startPosition) <= 0f)
            {
                submarine.TransitionToState(submarine.turningState);
            }*/
        }

        public void OnTriggerEnter(SubmarineController submarine, Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts") && !other.gameObject.CompareTag(submarine.tag))
            {
                distance = Vector3.Distance(submarine.transform.position ,other.transform.position); 
                Debug.Log(distance);
                
                    if (target == null)
                    {
                        target = other;
                        //submarine.TransitionToState(submarine.turningState);
                    }
                    submarine.transform.DOKill();

                    /*else if (target != null)
                    {
                        throw new Exception("target is null!");
                    }*/
                    
            }
        }

        private void SetNextState()
        {
            if (distance < 0)
            {
                submarine.TransitionToState(submarine.turningState);

            }
            else if(distance > 0)
            {
                submarine.TransitionToState(submarine.chasingAndAttackingState);

            }
        }

        public void OnTriggerStay(SubmarineController submarine, Collider other)
        {
            
        }

        public void OnTriggerExit(SubmarineController submarine, Collider other)
        {
            
        }

        public void Start(SubmarineController submarine)
        {
            throw new System.NotImplementedException();
        }

        public void Enable(SubmarineController submarine)
        {
            throw new System.NotImplementedException();
        }
    }
}
