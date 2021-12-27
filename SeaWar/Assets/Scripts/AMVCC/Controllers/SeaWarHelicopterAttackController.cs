using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using AMVCC.Views;
namespace AMVCC.Controllers
{
    public class SeaWarHelicopterAttackController : SeaWarElement
    {
        [SerializeField]private bool isAttackTime;
        private float fireRate;
        private float damage;
        private Vector3 directionVector;
        public Queue targets = new Queue();
        public Queue targetsPosition = new Queue();
        private GameObject target;
        [SerializeField] private SeaWarHelicopterRotateController helicopterRotateController;
        [SerializeField] private SeaWarHelicopterMoveController helicopterMoveController;
        private void Start()
        {
            tag = transform.parent.tag;
            fireRate = Application.model.helicopterModel.fireRate;
            damage = GetComponent<SeaWarHelicopterView>().damage;
//            Debug.Log("fire rate is : " + fireRate);
            isAttackTime = true;
            
        }

        private void Update()
        {
            if (target == null)
            {
                helicopterRotateController.nullTargetAction();
                //todo after full rotate back call this
                Move();
            }
          //  SetTarget();
            if (!isAttackTime)
            {
                fireRate -= Time.deltaTime;
                if (fireRate <= 0)
                {
                    fireRate = GetComponent<SeaWarHelicopterView>().fireRate;
                    isAttackTime = true;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Buildings") || other.gameObject.layer == LayerMask.NameToLayer("Refinery"))
            {
                if (!other.CompareTag(tag))
                {
                    
                    GetComponentInParent<SeaWarHelicopterMoveController>().StopMoving();
                    Debug.Log("push it!");
                    //targets.Enqueue(other.gameObject);
                    //GetComponentInParent<SeaWarHelicopterRotateController>().reachEnemyAction(other);
                    if (target == null)
                    {
                        target = other.gameObject;

                        helicopterRotateController.newTargetAction(target);

                    }
                    if (other.gameObject.layer == LayerMask.NameToLayer("Refinery"))
                    {
                        helicopterMoveController.isStopForever = true;
                    }
                    //SetTarget();
                    
                    
                    //targetsPosition.Enqueue(other.transform.position);
                    //todo StartCoroutine("Rotator");

                    //Attack(other);
                    
                }
            }
     
        }

        

        private void OnTriggerStay(Collider other)
        {
//            Debug.Log(other.gameObject.name);
            if (other.gameObject.layer == LayerMask.NameToLayer("Buildings") || other.gameObject.layer == LayerMask.NameToLayer("Refinery"))
            {
                if (!other.CompareTag(tag))
                {
                    //GetComponentInParent<SeaWarHelicopterMoveController>().moveAction();
                        //todo StartCoroutine("Rotator");
                       // Debug.Log("targets count" + targets.Count);
                       if (target == null)
                       {
                           target = other.gameObject;
                           helicopterRotateController.newTargetAction(target);
                           helicopterMoveController.StopMoving();
                       }
                        if (target && helicopterRotateController.isRotationCompleted)
                        {
                            Attack(target);

                        }
                        
                }
            }
            
        }
      
        private void Attack(GameObject hit)
        {
           
            if (hit.transform.Find("Trench"))
            {
                if (isAttackTime)
                {
                    
                        var trench = hit.transform.Find("Trench");
                        bool isDead = trench.GetComponent<SeaWarHealthView>().TakeDamage(damage, gameObject);
                        isAttackTime = false;
                        if (isDead)
                        {
                            target = null;

                            helicopterRotateController.nullTargetAction();

                        }
                }
                //Debug.Log("has trench");
                isAttackTime = false;

            } 
            if(!hit.transform.Find("Trench"))
            {
//                Debug.Log("suck " + hit.name + "'s dick!");

                if (isAttackTime)
                {

                        bool isDead = hit.GetComponent<SeaWarHealthView>().TakeDamage(damage, gameObject);
                        isAttackTime = false; 
                        //Debug.Log("has not trench");
                        if (isDead)
                        {
                            target = null;

                            helicopterRotateController.nullTargetAction();
                            
                        }
                }
                
                isAttackTime = false;
            }

        }

     private void Move()
        {
            helicopterMoveController.Moving();

        }
        
    }
}