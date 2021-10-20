using System;
using System.Collections;
using AMVCC.Views;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using UnityEditor.VersionControl;
using UnityEngine.EventSystems;

namespace AMVCC.Controllers.FSM.Submarine.Submarine_States
{
    public class SubmarineChasingAndAttackingState : SubmarineBaseState
    {
        private Transform targetTransform;
        private GameObject target;
        private float distance;
        private Ease moveEase = Ease.Linear;
        private float damage;
        private float fireRate;
        private bool isInRange;
        public void EnterState(SubmarineController submarine, GameObject other)
        {
            isInRange = true;
            submarine.submarineView.isAttackTime = true;
            damage = submarine.submarineView.damage;
            fireRate = submarine.submarineView.fireRate;
            if (target == null)
            {
                target = other;
                targetTransform = other.transform;
            }
            //todo spawn a missile
            /*if (target != null)
            {
                SetFireRate(submarine,target);

            }*/
            /*else if (other == null)
            {
                
            }*/
            //submarine.StartCoroutine(Move(submarine));
            
            //submarine.GetComponent<SeaWarSubmarineView>().isChasing = true;
            
            Debug.Log(submarine.CurrentState + " " + submarine.tag);
        }

        private void SetNextState(SubmarineController submarine)
        {
            float distance = submarine.transform.position.x - submarine.submarineModel.middleMap.transform.position.x;
            if (distance <= 0)
            {
                if (submarine.tag == "Blue")
                {
                    if (submarine.PreviousState == submarine.movingForwardState)
                    {
                        Debug.Log("b1");
                        submarine.TransitionToState(submarine.movingForwardState);
                    }
                    else if (submarine.PreviousState == submarine.movingBackState)
                    {
                        Debug.Log("b2");

                        submarine.TransitionToState(submarine.movingBackState);
                    }
                }
                else if (submarine.tag == "Red")
                {
                    if (submarine.PreviousState == submarine.movingForwardState)
                    {
                        Debug.Log("r1");
                        submarine.TransitionToState(submarine.turningState);
                    }
                    else if (submarine.PreviousState == submarine.movingBackState)
                    {
                        Debug.Log("r2");

                        submarine.TransitionToState(submarine.movingBackState);
                    }
                }
                
            }
            else
            {
                if (submarine.tag == "Blue")
                {
                    if (submarine.PreviousState == submarine.movingForwardState)
                    {
                        Debug.Log("b3");

                        submarine.TransitionToState(submarine.turningState);
                    }
                    else if (submarine.PreviousState == submarine.movingBackState)
                    {
                        Debug.Log("b4");

                        submarine.TransitionToState(submarine.movingBackState);
                    }
                }
                else if (submarine.tag == "Red")
                {
                    if (submarine.PreviousState == submarine.movingForwardState)
                    {
                        Debug.Log("r3");

                        submarine.TransitionToState(submarine.movingForwardState);
                    }
                    else if (submarine.PreviousState == submarine.movingBackState)
                    {
                        Debug.Log("r4");

                        submarine.TransitionToState(submarine.movingBackState);
                    }
                }
                if (submarine.PreviousState == submarine.movingForwardState)
                {
                    Debug.Log("3");

                    submarine.TransitionToState(submarine.turningState);
                }
                else if (submarine.PreviousState == submarine.movingBackState)
                {
                    Debug.Log("4");

                    submarine.TransitionToState(submarine.movingBackState);
                }
            }
            
        }

        private IEnumerator Move(SubmarineController submarine)
        {
            float speed = submarine.GetComponent<SeaWarSubmarineView>().speed;

            Tween moveTween = submarine.transform.DOMoveX(targetTransform.position.x,
                Vector3.Distance(submarine.transform.position, targetTransform.position) / speed).SetEase(moveEase);
            yield return moveTween.WaitForCompletion();
        }

        public void Update(SubmarineController submarine)
        {
            if (target != null)
            {
                if (isInRange)
                {
                    if (submarine.submarineView.isAttackTime)
                    {
                        //Attack(submarine,submarine.submarineView.damage, target); 
                        submarine.submarineView.isAttackTime = false;
                    }
//                    Debug.Log("firerate 1 : " + fireRate);

                    fireRate -= Time.deltaTime;
                    //Debug.Log("firerate 2 : " + fireRate);

                    if (fireRate < 0)
                    {
                        //Debug.Log("firerate 2 : " + fireRate);

                        fireRate = submarine.submarineView.fireRate;
                        submarine.submarineView.isAttackTime = true;
                    }
                }
         
            } 
            if (target != null && !isInRange)
            {
               // Chase(submarine, target);
            } 
            if (target == null)
            {
                SetNextState(submarine);            
            }
        }

        public void OnTriggerEnter(SubmarineController submarine, Collider other)
        {
            if (other == target)
            {
                isInRange = true;
            }   
        }

        public void OnTriggerStay(SubmarineController submarine, Collider other)
        {
           
        }
        
        private void Chase(SubmarineController submarine, Collider enemyCollider)
        {
            //Debug.Log(submarine.tag+" is chasing");
           submarine.transform.position = Vector3.MoveTowards(submarine.transform.position,
                enemyCollider.transform.position,
                Time.deltaTime * submarine.submarineModel.submarineData.movmentSpeed);
        }

        private void Attack(SubmarineController submarine, float damage, Collider other)
        {
            if (other)
            {
                other.GetComponent<SeaWarHealthView>().TakeDamage(damage);

            }
            else
            {
                SetNextState(submarine);
            }
        }
      

       public void OnTriggerExit(SubmarineController submarine, Collider other)
        {
            
            if (other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts") && !other.CompareTag(submarine.tag))
            {
                if (other == target)
                {
                    isInRange = false;
                }
            }
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
