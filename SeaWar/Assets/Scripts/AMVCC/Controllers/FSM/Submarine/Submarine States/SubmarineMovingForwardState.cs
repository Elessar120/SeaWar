using System;
using System.Collections;
using UnityEngine;
using AMVCC.Views;
using AMVCC.Models;
using DG.Tweening;
using UnityEditor.VersionControl;

namespace AMVCC.Controllers.FSM.Submarine.Submarine_States
{
    public class SubmarineMovingForwardState : SubmarineBaseState
    {
        private Collider target;
        private Ease moveEase = Ease.Linear;
        private float fireRate;
        private float distance;
        private SubmarineController submarine;
        public void Start(SubmarineController submarine)
        {
        }
        public void Enable(SubmarineController submarine)
        {
            //this.submarine = submarine;
        }

        
        public void EnterState(SubmarineController submarine, Collider other)
        {
            this.submarine = submarine;
            Debug.Log(submarine.CurrentState);
            submarine.StartCoroutine(Move(submarine));
            //submarine.TransitionToState(submarine.turningState);

        }

        private IEnumerator Move(SubmarineController submarine)
        {
            float speed = submarine.GetComponent<SeaWarSubmarineView>().speed;
            Vector3 nextDestination = submarine.Application.model.submarineModel.middleMap.transform.position;
            Tween myTween = submarine.transform.DOMoveX(nextDestination.x,Vector3.Distance(submarine.transform.position,nextDestination)/speed).SetEase(moveEase).OnKill(SetNextState).OnComplete(Turning);
            //yield return new WaitForSeconds((Vector3.Distance(submarine.transform.position,nextDestination))/speed);
            yield return myTween.WaitForCompletion();

        }

        private void SetNextState()
        {
            if (distance < 0)
            {
                submarine.TransitionToState(submarine.turningState);

            }
            else if (distance > 0)
            {
                submarine.TransitionToState(submarine.chasingAndAttackingState);
            }
            
        }

        private void Turning()
        {
            submarine.TransitionToState(submarine.turningState);

        }
        public void Update(SubmarineController submarine)
        {
            
            //submarine.transform.position = Vector3.MoveTowards(submarine.gameObject.transform.position,new Vector3(submarine.Application.model.submarineModel.middleMap.transform.position.x,submarine.transform.position.y,submarine.transform.position.z),Time.deltaTime * submarine.Application.model.submarineModel.submarineData.movmentSpeed);
//            Debug.Log(Vector3.Distance(submarine.transform.position, submarine.Application.model.submarineModel.middleMap.transform.position));
           // if (Vector3.Distance(submarine.transform.position, submarine.Application.model.submarineModel.middleMap.transform.position) <= 6.5f)
           // {
                //Debug.Log("turning!");
                /*if (submarine.GetComponent<SeaWarSubmarineView>().middleMapPassed)
                {
                    submarine.GetComponent<SeaWarSubmarineView>().middleMapPassed = false;

                }
                else if(!submarine.GetComponent<SeaWarSubmarineView>().middleMapPassed)
                {
                    submarine.GetComponent<SeaWarSubmarineView>().middleMapPassed = true;

                }*/

              //  submarine.TransitionToState(submarine.turningState);
                
           // }
            //RaycastHit hit;
            //Ray ray = new Ray(submarine.GetComponent<SeaWarSubmarineView>().rayCastingPoint.transform.position , submarine.transform.right);
           // Debug.DrawRay(submarine.GetComponent<SeaWarSubmarineView>().rayCastingPoint.transform.position,submarine.transform.right * 3, Color.red);
//            Debug.Log("update");
            /*if (Physics.Raycast(ray,out hit, 3f))
            {
                if (!hit.collider.CompareTag(submarine.GetComponent<SeaWarSubmarineView>().tag) &&
                    (hit.collider.name == "Submarine(Clone)" || hit.collider.name == "OilTanker(Clone)" ||
                     hit.collider.name == "BattleShip(Clone)" || hit.collider.name == "SmallBattleship(Clone)" ||
                     hit.collider.name == "MotorBoat(Clone)" ))
                {
                    Debug.Log(hit.collider.name + hit.collider.tag);
                    submarine.TransitionToState(submarine.chasingAndAttackingState);
                    //Chase(submarine,hit.collider);
                    //SetFireRate(submarine,hit.collider);
                }

               
            } */
            /*else 
            {
                if (submarine.GetComponent<SeaWarSubmarineView>().isChasing)
                {
                    submarine.GetComponent<SeaWarSubmarineView>().enemyCollider = null;
                    submarine.TransitionToState(submarine.turningState);
                }
                
            }*/
          

        }

       public void OnTriggerEnter(SubmarineController submarine, Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts") && !other.gameObject.CompareTag(submarine.tag))
            {
               //submarine.TransitionToState(submarine.chasingAndAttackingState);
               distance = Vector3.Distance(submarine.transform.position ,other.transform.position);
                Debug.Log(distance);
                   
                   if (target == null)
                   {
                       target = other;
                   }
                   submarine.transform.DOKill();

                   /*else if (target != null)
                   {
                       throw new Exception("target is null!");
                   }*/
            }

            
            /*if (!submarine.GetComponent<SeaWarSubmarineView>().isChasing)
            {
                submarine.TransitionToState(submarine.turningState);

            }*/
            //submarine.TransitionToState(submarine.chasingAndAttackingState);
            /*Debug.Log("ontriggerenter");
            Debug.Log(other.tag);
            if (other.CompareTag("MiddleMap"))
            {
                Debug.Log("in middle map");
            
                
            }*/
        }

        public void OnTriggerStay(SubmarineController submarine, Collider other)
        {
            
           // submarine.TransitionToState(submarine.chasingAndAttackingState);
        }

        public void OnTriggerExit(SubmarineController submarine, Collider other)
        {
        }
    }
}
