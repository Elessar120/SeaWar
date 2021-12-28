using System;
using System.Collections;
using AMVCC.Views;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using UnityEngine.EventSystems;

namespace AMVCC.Controllers.FSM.Submarine.Submarine_States
{
    public class SubmarineAttackingState : SubmarineBaseState
    {
        private SubmarineController submarine;
        private SpawnController spawnController;
        private Transform targetTransform;
        private GameObject target;
        private float distance;
        private Ease moveEase = Ease.Linear;
        private float damage;
        private float enemySpeed;
        //bool isInRange;
        public void EnterState(SubmarineController submarine, GameObject other)
        {
            //isInRange = true;
            spawnController = submarine.GetComponent<SubmarineController>().spawnController;
            this.submarine = submarine;
            //submarine.submarineView.isAttackTime = true;
            damage = submarine.submarineView.damage;
            if (target == null && other != null)
            {
                target = other;
                targetTransform = other.transform;
                enemySpeed = target.GetComponent<SeaWarSpeedController>().speed;
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
            
            Debug.Log(submarine.CurrentState + " " + submarine.tag + "target: " + target.name + " " + target.tag);
        }

        private IEnumerator Move(SubmarineController submarine)
        {
            float speed = submarine.GetComponent<SeaWarSubmarineView>().speed;

            Tween moveTween = submarine.transform.DOMoveX(targetTransform.position.x,
                Vector3.Distance(submarine.transform.position, targetTransform.position) / speed).SetEase(moveEase);
            yield return moveTween.WaitForCompletion();
        }

        public void FixedUpdate(SubmarineController submarine)
        {
            if (target != null)
            {
                distance = submarine.transform.position.x - target.transform.position.x;
                //Chase(submarine,target.GetComponent<Collider>());

                /*if (distance < 1 && distance > -1)
                {
                    StopMoving();
                }*/
                
                //Debug.Log(distance);
                if (submarine.CompareTag("Blue"))//todo each submarine forward direction like turning state
                {
                    if (distance > 4)//todo bool false and move update to chase statement
                    {
                        submarine.TransitionToState(submarine.turningState,target);
                        //Debug.Log( "1- target : "+ target.name);

                        //isInRange = false; 
                    }
                    
                    else if (distance < -4)//todo bool false
                    {
                        submarine.TransitionToState(submarine.chasingState, target);
                    }
                    else if (distance < 4 && distance > 1)
                    {
                        
                    }
                    else if (distance > -4 && distance < -1)
                    {
                        
                    }
                }
                else if (submarine.CompareTag("Red"))
                {
                    if (distance > 4)//todo bool false
                    {
                        submarine.TransitionToState(submarine.chasingState,target);
                        //isInRange = false; 
                    }
                    else if (distance < -4)//todo bool false
                    {
                        submarine.TransitionToState(submarine.turningState, target);
                        //Debug.Log( "2- target : "+ target.name);

                    }
                }
                
                if (submarine.submarineView.isAttackTime)//todo move to submarine controller
                {
                    //Debug.Log("attack time");
                    Attack(submarine, submarine.submarineView.damage, target);
                    submarine.submarineView.isAttackTime = false;
                }              
                
               
                
            }
            else if (target == null)//todo move to submarine controller(done)
            {
                //Debug.Log("target == null");
                SetTarget();
                if (target == null)
                {
                    submarine.TransitionToState(submarine.turningState,target);

                }

            }
            
        }

        private void StopMoving()
        {
            submarine.transform.position += Vector3.zero;
        }

        /*private void Chase(SubmarineController submarine, Collider enemyCollider)
        {
            //Debug.Log(submarine.tag+" is chasing");
           
            
            if (submarine.CompareTag("Blue"))
            {
                if (distance < 4 && distance > 1)
                {
                    submarine.transform.position = Vector3.MoveTowards(submarine.transform.position,
                        enemyCollider.transform.position,
                        Time.deltaTime * submarine.submarineModel.submarineData.movmentSpeed);
                }
                else if (distance > -4 && distance < -1)
                {
                        
                }
            }
            if (submarine.CompareTag("Red"))
            {
                if (distance < 4 && distance > 1)
                {
                    submarine.transform.position = Vector3.MoveTowards(submarine.transform.position,
                        enemyCollider.transform.position,
                        Time.deltaTime * submarine.submarineModel.submarineData.movmentSpeed);
                }
                else if (distance > -4 && distance < -1)
                {
                        
                }
            }
            
        }*/
        private void SetTarget()//todo move to submarine controller
        {
            //Debug.Log("1");
            if (submarine.gameObject.CompareTag("Blue") && spawnController.spawnedSeaCraftsRed.Count > 0)
            {
               // Debug.Log("2");

                if (target == null)
                {
                   // Debug.Log("3");
                    GameObject peekTarget = (GameObject)spawnController.spawnedSeaCraftsRed.Peek();
                    if (peekTarget != null)
                    {
                       // Debug.Log("4");

                      //  Debug.Log("set target Blue");

                        target = (GameObject)spawnController.spawnedSeaCraftsRed.Peek();
                      //  Debug.Log(spawnController.spawnedSeaCraftsRed.Count + "in submarine controller Red");
                        //TransitionToState(chasingState, target);    
                    }
                }
            }
            
            else if (submarine.gameObject.CompareTag("Red") && spawnController.spawnedSeaCraftsBlue.Count > 0)
            {
               // Debug.Log("6");

                if (target == null)
                {
                  //  Debug.Log("7");
                    GameObject peekTarget = (GameObject)spawnController.spawnedSeaCraftsBlue.Peek();
                    if (peekTarget != null)
                    {
                      //  Debug.Log("8");

                      //  Debug.Log("set target Red");

                        target = (GameObject)spawnController.spawnedSeaCraftsBlue.Peek();
                      //  Debug.Log(spawnController.spawnedSeaCraftsBlue.Count + "in spawn controller Blue");

                        //TransitionToState(chasingState, target);
                    }
                }
            }
        }
        private void Attack(SubmarineController submarine, float damage, GameObject other)//todo move to submarine controller
        {
           // Debug.Log("Attack To Enemy");
            if (other)
            {
                other.GetComponentInChildren<SeaWarHealthView>().TakeDamage(damage, submarine.gameObject);

            }
            else
            {
                //SetNextState(submarine);
            }
        }
        public void OnTriggerEnter(SubmarineController submarine, Collider other)
        {
            if (other.gameObject == target)
            {
                //isInRange = true;//todo move isInRange bool to update and depends to distance
            }   
        }
        public void OnTriggerStay(SubmarineController submarine, Collider other)
        {
           
        }
        
       
      

       public void OnTriggerExit(SubmarineController submarine, Collider other)
        {
            
            if (other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts") && !other.CompareTag(submarine.tag))
            {
                if (other.gameObject == target)
                {
                    //isInRange = false;
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
