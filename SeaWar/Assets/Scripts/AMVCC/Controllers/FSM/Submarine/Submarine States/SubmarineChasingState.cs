using System;
using UnityEngine;
using System.Collections;
using UnityEngine;
using AMVCC.Views;
using DG.Tweening;
namespace AMVCC.Controllers.FSM.Submarine.Submarine_States
{
        
        public class SubmarineChasingState : SubmarineBaseState
        {
               
                private GameObject target;
                private float targetSpeed;
                private float ballanceSpeed;
                private SubmarineController submarineControllerInstance;
                private float distance;
                private Tween rotationTween;
                private int delay;

                private bool isRotating;
                //private bool isInFireRange;
                //private bool isInFront;
                public void EnterState(SubmarineController submarine, GameObject other)
                {
                        delay = 0;
                        Debug.Log(submarine.CurrentState + " " + submarine.tag);

                        if (!target)
                        { 
                                target = other;
                                if (target.name != "Oil Tanker")
                                {
                                        //targetSpeed = target.GetComponent<SeaWarSpeedController>().speed;

                                }
                        }

                        distance = target.transform.position.x - submarine.transform.position.x;
                        //submarine.StartCoroutine(RotationCheck(submarine));
                                
                        //ChooseProperState(submarine, distance);
                        /*if (targetSpeed < submarine.submarineView.speed);
                        {
                                ballanceSpeed = targetSpeed;
                        }*/

                        //Attack(submarine, submarine.submarineView.damage, target);
                        /*if (submarine.PreviousState == submarine.attackingState)
                        {
                                distance = submarine.transform.position.x - target.transform.position.x;

                                if (submarine.LastStateBeforeChase == submarine.movingForwardState)
                                {
                                        if (submarine.CompareTag("Blue"))
                                        {
                                                if (distance > 0)
                                                {
                                                        submarine.TransitionToState(submarine.turningState,target);
                                                }
                                                else if (distance < 0)
                                                {
                                                        submarine.TransitionToState(submarine.chasingState, target);
                                                }
                                        }
                                        else if (submarine.CompareTag("Red"))
                                        {
                                                if (distance > 0)
                                                {
                                                        submarine.TransitionToState(submarine.chasingState, target);

                                                }
                                                else if (distance < 0)
                                                {
                                                        submarine.TransitionToState(submarine.turningState,target);

                                                }
                                        }
                                }
                                else if (submarine.LastStateBeforeChase == submarine.movingBackState)
                                {
                                        if (submarine.CompareTag("Blue"))
                                        {
                                                if (distance > 0)
                                                {
                                                        submarine.TransitionToState(submarine.chasingState,target);
                                                }
                                                else if (distance < 0)
                                                {
                                                        submarine.TransitionToState(submarine.turningState, target);
                                                }
                                        }
                                        else if (submarine.CompareTag("Red"))
                                        {
                                                if (distance > 0)
                                                {
                                                        submarine.TransitionToState(submarine.turningState, target);

                                                }
                                                else if (distance < 0)
                                                {
                                                        submarine.TransitionToState(submarine.chasingState,target);

                                                }
                                        } 
                                }
                        }*/
                }
                private IEnumerator RotationCheck(SubmarineController submarine)
                {
                        isRotating = true;
                        rotationTween = submarine.transform.DODynamicLookAt(target.transform.position, submarine.submarineView.speed / submarine.CalculateCurrentSpeed());
                        yield return new DOTweenCYInstruction.WaitForCompletion(rotationTween);
                        isRotating = false;
                }

                public void FixedUpdate(SubmarineController submarine)
                {
                                
                        if (target)
                        {
                                delay = 0; 
                                float distance = target.transform.position.x - submarine.transform.position.x;
                                if (target.name != "Oil Tanker")
                                {
                                        ChooseProperState(submarine, distance);
                                        if (!isRotating)
                                        {
                                                //submarine.StartCoroutine(RotationCheck(submarine));
                                                Chase(submarine,distance, submarine.submarineView.speed);

                                        }
                                        /*if (Vector3.Distance(submarine.transform.position, target.transform.position) < .5f)
                                       { 
                                               RaycastHit hit;
                                               if (Physics.Raycast(submarine.rayCastingPoint.transform.position, submarine.transform.forward * -1, out hit, 2))
                                               {
                                                       if (hit.collider == target.GetComponent<Collider>())
                                                       {
                                                               submarine.StartCoroutine(RotationCheck(submarine));
                                                       }
                                               }

                                       }
                                      if (Physics.Raycast())
                                       {
                                               
                                       }*/
                                        /*if (Mathf.Abs(distance) < .5)
                                        {
                                                submarine.StartCoroutine(RotationCheck(submarine));
                                        }*/
                                        
                                }
                                        
                                
                                /*if (distance < 4 && distance > -4)
                                {
                                        //submarine.isAttackState = true;
                                       // StopMoving(submarine,target.GetComponent<Collider>());
        
                                        submarine.TransitionToState(submarine.attackingState,target);
                                        /*if (distance < 2 || distance > -2)
                                        {
                                                StopMoving(submarine,target.GetComponent<Collider>());
                                        }#1#
                                        
                                }*/
                                /*else
                                {
                                        submarine.isAttackState = true;
                                }*/
                                //todo add  distance statements from attack state here
                               
                                
                        }
                       
                        else if (!target)
                        {
                                delay++;
                                Debug.Log("delay = " + delay);
                                if (delay == 2)
                                {
                                        delay = 0;
                                        submarine.TransitionToState(submarine.turningState,target);

                                }

                                        //submarine.StartCoroutine(Delay(submarine));
                                
                                //float timer = delayTime 

                        }
                       
                }

               
                private IEnumerator Delay(SubmarineController submarine)
                {

                        yield return new WaitForSeconds(1);


                }
                private void ChooseProperState(SubmarineController submarine, float distance)
                {
                        if (submarine.CompareTag("Blue"))
                        {
                                if (submarine.transform.forward == Vector3.right)
                                {
                                        if (distance < 0 )
                                        {
                                                submarine.StartCoroutine(RotationCheck(submarine));
                                        }
                                } 
                                else if (submarine.transform.forward == Vector3.left)
                                {
                                        if (distance > 0)
                                        {
                                                submarine.StartCoroutine(RotationCheck(submarine));
                                        }
                                }
                        }
                        else if (submarine.CompareTag("Red"))
                        {
                                if (submarine.transform.forward == Vector3.right)
                                {
                                        if (distance < 0)
                                        {
                                                submarine.StartCoroutine(RotationCheck(submarine));
                                        }
                                }

                                if (submarine.transform.forward == Vector3.left)
                                {
                                        if (distance > 0)
                                        {
                                                submarine.StartCoroutine(RotationCheck(submarine));
                                        }
                                }
                        }
                       
                        /*if (submarine.CompareTag("Blue"))
                        {
                                if (submarine.turningState.BeforeTurningState == submarine.movingForwardState)
                                {
                                        Debug.Log(target.transform.forward + " vs " + submarine.transform.forward);
                                        if (submarine.transform.forward == target.transform.forward)
                                        {
                                                Debug.Log("==");

                                                if (distance < 0)
                                                {
                                                        Debug.Log("B F == < 0");
                                                        //isInFront = false;
                                                        submarine.TransitionToState(submarine.turningState, target);
                                                        if (submarine.turningState.BeforeTurningState == submarine.chasingState && submarine.PreviousState == submarine.turningState)
                                                        {
                                                                submarine.TransitionToState(submarine.turningState,target);
                                                        }
                                                }
                                                else if (distance > 0)
                                                {
                                                        Debug.Log("B F == > 0");

                                                        // do nothing
                                                        //isInFront = true;
                                                }
                                        }
                                        else if (submarine.transform.forward != target.transform.forward)
                                        {
                                                Debug.Log("!=");
                                                if (distance < 0)
                                                {
                                                        Debug.Log("B F != < 0");

                                                        //isInFront = false;
                                                        submarine.TransitionToState(submarine.turningState, target);
                                                }
                                                else if (distance > 0)
                                                { 
                                                        Debug.Log("B F != > 0");

                                                        //do nothing
                                                       // isInFront = true;

                                                }  
                                        }
                                }
                                if (submarine.turningState.BeforeTurningState == submarine.movingBackState)
                                {
                                        if (submarine.transform.forward == target.transform.forward)
                                        {
                                                Debug.Log("==");
                                                if (distance < 0)
                                                {
                                                        Debug.Log("B B == < 0");

                                                        //do nothing
                                                        //isInFront = true;


                                                }
                                                else if (distance > 0)
                                                {
                                                        Debug.Log("B B == > 0");

                                                        //isInFront = false;
                                                        submarine.TransitionToState(submarine.turningState, target);

                                                }
                                        }
                                        else if (submarine.transform.forward != target.transform.forward)
                                        {
                                                Debug.Log("!=");
                                                if (distance < 0)
                                                {
                                                        Debug.Log("B B != < 0");

                                                        //do nothing
                                                        //isInFront = true;


                                                }
                                                else if (distance > 0)
                                                {
                                                        Debug.Log("B B != > 0");

                                                        //isInFront = false;
                                                        submarine.TransitionToState(submarine.turningState, target);
  
                                                }
                                        }
                                }

                                if (submarine.turningState.BeforeTurningState == submarine.chasingState)
                                {
                                        if (submarine.transform.forward == target.transform.forward)
                                        {
                                                if (distance < 0)
                                                {
                                                        Debug.Log("R B == < 0");

                                                        //isInFront = false;
                                                        //submarine.TransitionToState(submarine.turningState, target);
  
                                                }
                                                else if (distance > 0)
                                                {
                                                        Debug.Log("R B == > 0");

                                                        //do nothing
                                                        //isInFront = true;


                                                }
                                        }
                                        else if (submarine.transform.forward != target.transform.forward)
                                        {
                                                if (distance < 0)
                                                {
                                                        Debug.Log("R B != < 0");

                                                        //isInFront = false;
                                                        submarine.TransitionToState(submarine.turningState, target);

                                                }
                                                else if (distance > 0)
                                                {
                                                        Debug.Log("R B != > 0");

                                                        //do nothing
                                                        //isInFront = true;
                                                        submarine.TransitionToState(submarine.turningState, target);


                                                }
                                        }
                                }
                        }
                        else if (submarine.CompareTag("Red"))
                        {
                                if (submarine.turningState.BeforeTurningState == submarine.movingForwardState)
                                {
                                        if (submarine.transform.forward == target.transform.forward)
                                        {
                                                if (distance < 0)
                                                {
                                                        Debug.Log("R F == < 0");

                                                        //do nothing
                                                        //isInFront = true;


                                                }
                                                else if (distance > 0)
                                                {
                                                        Debug.Log("R F == > 0");

                                                        //isInFront = false;
                                                        submarine.TransitionToState(submarine.turningState, target);
 
                                                }
                                        }
                                        else if (submarine.transform.forward != target.transform.forward)
                                        {
                                                if (distance < 0)
                                                {
                                                        Debug.Log("R F != < 0");

                                                        //do nothing
                                                        //isInFront = true;


                                                }
                                                else if (distance > 0)
                                                {
                                                        Debug.Log("R F != > 0");

                                                        //isInFront = false;
                                                        submarine.TransitionToState(submarine.turningState, target);

                                                }  
                                        }
                                }
                                if (submarine.turningState.BeforeTurningState == submarine.movingBackState)
                                {
                                        if (submarine.transform.forward == target.transform.forward)
                                        {
                                                if (distance < 0)
                                                {
                                                        Debug.Log("R B == < 0");

                                                        //isInFront = false;
                                                        submarine.TransitionToState(submarine.turningState, target);
  
                                                }
                                                else if (distance > 0)
                                                {
                                                        Debug.Log("R B == > 0");

                                                        //do nothing
                                                        //isInFront = true;


                                                }
                                        }
                                        else if (submarine.transform.forward != target.transform.forward)
                                        {
                                                if (distance < 0)
                                                {
                                                        Debug.Log("R B != < 0");

                                                        //isInFront = false;
                                                        submarine.TransitionToState(submarine.turningState, target);

                                                }
                                                else if (distance > 0)
                                                {
                                                        Debug.Log("R B != > 0");

                                                        //do nothing
                                                        //isInFront = true;


                                                }
                                        }
                                }    
                                if (submarine.turningState.BeforeTurningState == submarine.chasingState)
                                {
                                        if (submarine.transform.forward == target.transform.forward)
                                        {
                                                if (distance < 0)
                                                {
                                                        Debug.Log("R B == < 0");

                                                        //isInFront = false;
                                                        //submarine.TransitionToState(submarine.turningState, target);
  
                                                }
                                                else if (distance > 0)
                                                {
                                                        Debug.Log("R B == > 0");

                                                        //do nothing
                                                        //isInFront = true;


                                                }
                                        }
                                        else if (submarine.transform.forward != target.transform.forward)
                                        {
                                                if (distance < 0)
                                                {
                                                        Debug.Log("R B != < 0");

                                                        //isInFront = false;
                                                        submarine.TransitionToState(submarine.turningState, target);

                                                }
                                                else if (distance > 0)
                                                {
                                                        Debug.Log("R B != > 0");
                                                        submarine.TransitionToState(submarine.turningState, target);

                                                        //do nothing
                                                        //isInFront = true;


                                                }
                                        }
                                }
                        }
                        */
                       
                }
                private void Attack(SubmarineController submarine, float damage, GameObject other)
                {
                        
                        // Debug.Log("Attack To Enemy");
                        if (other && !isRotating)
                        {
                                other.GetComponentInChildren<SeaWarHealthView>().TakeDamage(damage, submarine.gameObject);

                        }
                        else
                        {
                                //SetNextState(submarine);
                        }
                }
                private void StopMoving(SubmarineController submarine, Collider enemyCollider)
                {
                        submarine.transform.position += Vector3.zero;
                                
                }

                private void Chase(SubmarineController submarine, float distanceToEnemy, float speed)
                {
                        
                        /*if (targetSpeed < submarine.submarineView.speed)
                        {
                                ballanceSpeed = targetSpeed;
                                submarine.transform.position = Vector3.MoveTowards(submarine.transform.position,
                                        target.transform.position,
                                        Time.deltaTime * ballanceSpeed);
                        }*/
                       // else
                       // {
                       if (Mathf.Abs(distanceToEnemy) > 4)
                       {
                               submarine.transform.position = Vector3.MoveTowards(submarine.transform.position,
                                       target.transform.position,
                                       Time.deltaTime * submarine.CalculateCurrentSpeed());
                       }
                               
                       // }
                        
                }
                public void OnTriggerEnter(SubmarineController submarine, Collider other)
                {
                        /*if (other == target.GetComponent<Collider>())
                        {
                                Ray ray = new Ray()
                        }*/
                }

                public void OnTriggerStay(SubmarineController submarine, Collider other)
                {
                        
                        if (target)
                        {
                                if (other == target.GetComponent<Collider>())//todo isinfront isnt true 
                                {
                                        //isInFireRange = true;
                                        //Debug.Log("target == other");
                                        if (submarine.submarineView.isAttackTime)
                                        {
                                                //Debug.Log("attack time");
                                                submarine.onAttackAction(target);                                                //Attack(submarine, submarine.submarineView.damage, target);
                                                submarine.submarineView.isAttackTime = false;
                                        }      
                                } 
                        }
                        else if (!target)
                        {
                                if (other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts"))
                                {
                                        if (!other.gameObject.CompareTag(submarine.tag))
                                        {
                                                target = other.gameObject;
                                                //submarine.StartCoroutine(RotationCheck(submarine));

                                        }
                                }
                        }
                        
                }
                
                public void OnTriggerExit(SubmarineController submarine, Collider other)
                {
                        
                }

                public void Start(SubmarineController submarine)
                {
                }

                public void Enable(SubmarineController submarine)
                {
                }
        }
        
}