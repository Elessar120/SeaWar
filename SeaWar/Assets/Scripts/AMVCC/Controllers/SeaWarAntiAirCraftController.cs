using System;
using System.Collections;
using UnityEngine;
using AMVCC.Views;
using UnityEditor;
using DG.Tweening;
namespace AMVCC.Controllers
{
    public class SeaWarAntiAirCraftController : SeaWarElement
    {
        //public Action onKillAction;

        [SerializeField]private float fireRate;
        [SerializeField]private bool isAttackTime;
        [SerializeField] private SeaWarAntiAirCraftView antiAirCraftView;
        [SerializeField] private SeaWarAntiAirCraftRotationController antiAirCraftRotationController;
        private Queue targets = new Queue();

        private GameObject target;
        //private GameObject target;
        private float rotateDuration;
        private float timer;
        private double rotationDegree;
        private bool isRotateTime;

        private void Start()
        {
            rotateDuration = antiAirCraftView.rotateSpeed;
            isAttackTime = true;
            fireRate = antiAirCraftView.fireRate; 
           // onKillAction += RemoveQueue;
            //onKillAction += CallActionInRotateClass;
            
        }

        private void Update()
        {
            if (!target)
            {
                antiAirCraftRotationController.nullTargetAction();
                //todo after full rotate back call this
            }
            if (!isAttackTime)
            {
                float t = Time.time - timer;
//                Debug.Log("fire rate : " + t);

                //fireRate -= Time.deltaTime;
                if (t >= fireRate)
                {
                    isAttackTime = true;
                    timer = Time.time;
//                    Debug.Log("fire rate full : " + t);
                }
                    
            }

            /*if (target)
            {
                Vector3 directionVector = target.transform.position - parentTransform.transform.position; 
                rotationDegree = Mathf.Atan(directionVector.y / directionVector.x) * Mathf.Rad2Deg;
                Rotate(directionVector, rotationDegree);
            }*/
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Air Crafts"))

            {
                //Debug.Log(transform.parent.name);
                Debug.Log(other.gameObject.name);
                ////towerView.attackTargets.Add(other.gameObject);
                // Attack(other.gameObject);
                if (!other.gameObject.CompareTag(gameObject.tag))
                {
                    if (target == null)
                    {
                        target = other.gameObject;

                        antiAirCraftRotationController.newTargetAction(target);

                    }
                    //AddTarget(other.gameObject);
                    //target = (GameObject)targets.Peek();

                    //Debug.Log( "on trigger enter "+ targets.Count + " " + targets.Peek());
                   // StartCoroutine(nameof(Rotate));

                   
                    //Debug.Log(GetComponent<SeaWarAttackView>().damage);
                    /*if (target != null)
                    {
                        if (!other.GetComponent<SeaWarHealthView>().attackers.Contains(gameObject))
                        {
                            other.GetComponent<SeaWarHealthView>().attackers.Add(gameObject);     
                        }

                        Attack();
                        
                    }*/
                   
                }

            }
            /*if (!other.CompareTag(gameObject.tag))
            {

                if (other.gameObject.layer == LayerMask.NameToLayer("Air Crafts"))

                {

//todo                    StartCoroutine("Rotator");
                   Attack(other);
                    InvokeRepeating("FindingEnemy",0,0.1f);

                }
                
            }*/
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Air Crafts"))
            {
                if (!other.CompareTag(tag))
                {
                    // fireRate -= Time.deltaTime;
                    // if (fireRate < 0)
                    // {
                    //     fireRate = antiAirCraftView.fireRate;
                    //     Debug.Log("fire rate full : " + fireRate);
                    //
                    //     isAttackTime = true;
                    // }
                    
                    //Rotate(directionVector, rotationDegree);
                    if (target == null)
                    {
                        target = other.gameObject;
                        antiAirCraftRotationController.newTargetAction(target);
                    }
                    if (target && antiAirCraftRotationController.isRotationCompleted)
                    {
                        Attack(target);

                    }
                    
                }
            }

        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Air Crafts"))
            {
                if (!other.CompareTag(tag))
                {
                    if (other == target.GetComponent<Collider>())
                    {
                        target = null;
                        antiAirCraftRotationController.nullTargetAction();
                        Debug.Log(other.name + " exit from : " + transform.name);
                        //Debug.Log("queue count is : " + targets.Count);
                        //isRotateTime = false;
                    }
                }
            }

           
        }
        private void Attack(GameObject hit)
        {
            if (isAttackTime)
            {
               bool isDead = hit.GetComponent<SeaWarHealthView>().TakeDamage(antiAirCraftView.CalculateCurrentDamage(), gameObject);
                isAttackTime = false;
                timer = Time.time;

                if (isDead)
                {
                    target = null;

                    antiAirCraftRotationController.nullTargetAction();

                }      
            }
        }

        
    }
}