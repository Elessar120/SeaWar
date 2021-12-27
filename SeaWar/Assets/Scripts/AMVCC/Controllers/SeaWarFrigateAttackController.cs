using UnityEngine;
using AMVCC.Views;
using System;
using System.Collections;

namespace AMVCC.Controllers
{
    public class SeaWarFrigateAttackController : SeaWarElement
    {
        [SerializeField] private GameObject cannon;
        [SerializeField] private Transform cannonLauncher;
        [SerializeField]private bool isAttackTime;
        [SerializeField] private SeaWarFrigateRotateController frigateRotateController;
        [SerializeField] private SeaWarFrigateMoveController frigateMoveController;
        private float fireRate;
        private float damage;
        private Vector3 directionVector;
        public Queue targets = new Queue();
        private GameObject target;
        public Queue targetsPosition = new Queue();
        private bool isStopForever;
        [SerializeField]private bool isRotationCompleted;

       
        private void Start()
        {
            tag = frigateMoveController.gameObject.tag;
            fireRate = GetComponent<SeaWarFrigateView>().fireRate;
            damage = GetComponent<SeaWarFrigateView>().damage;
            isAttackTime = true;
            
        }

        private void Update()
        {
            if (target == null)
            {
                frigateRotateController.nullTargetAction();
               
                    Move();
//                    Debug.Log("update");

                
            }
            if (!isAttackTime)
            {
                fireRate -= Time.deltaTime;
                if (fireRate <= 0)
                {
                    fireRate = GetComponent<SeaWarFrigateView>().fireRate;
                    isAttackTime = true;
                }
            }
        }
        private void Move()
        {
            frigateMoveController.Moving();

        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Buildings"))
            {
                if (!other.CompareTag(tag))
                {
                    frigateMoveController.StopMoving();

                    Debug.Log("push it!");
                    if (target == null)
                    {
                        Debug.Log("ontriggerEnter");

                        target = other.gameObject;

                        frigateRotateController.newTargetAction(target);

                    }
                    
                    //targetsPosition.Enqueue(other.transform.position);

                    //Attack(other);
                }
               
                
            }
           
        }
        
        private void OnTriggerStay(Collider other)
        {
//            Debug.Log(other.gameObject.name);
            if (other.gameObject.layer == LayerMask.NameToLayer("Buildings"))
            {
                if (!other.CompareTag(tag))
                {
                    //GetComponentInParent<SeaWarHelicopterMoveController>().moveAction();
                    //todo StartCoroutine("Rotator");
                    if (target == null)
                    {
                        target = other.gameObject;

                        frigateRotateController.newTargetAction(target);
                        frigateMoveController.StopMoving();

                        Debug.Log("ontriggerstay");
                            
                    }
                    if (target && frigateRotateController.isRotationCompleted)
                    {
                        Launch(target);
                    }
                }
               
                
            }
        }
        private void Launch(GameObject target)
        {
           
            if (isAttackTime)
            {
                    
                //trench.GetComponent<SeaWarHealthView>().TakeDamage(damage);
                CannonballSpawner(target);
                isAttackTime = false;
            }
        }
        private void CannonballSpawner(GameObject target)
        {
            GameObject spawnedBall = Instantiate(cannon,cannonLauncher.position,cannonLauncher.rotation * Quaternion.Euler(-90,0,0));
            spawnedBall.GetComponent<SeaWarFrigateCannonMoveController>().target = target;
            spawnedBall.GetComponent<SeaWarFrigateCannonAttackController>().target = target;
           
        }

        private void Attack(GameObject hit)
        {
          
            Debug.Log("my name is : " + hit.name);
            if (hit.transform.Find("Trench"))
            {
                if (isAttackTime)
                {
                    
                        var trench = hit.transform.Find("Trench");
                        bool isDead = trench.GetComponent<SeaWarHealthView>().TakeDamage(damage, gameObject);
                        isAttackTime = false;
                        if (isDead)
                        {                
                            frigateRotateController.nullTargetAction();

                            target = null;


                        }
                }

                isAttackTime = false;

            }
            else if(!hit.transform.Find("Trench"))
            {
                if (isAttackTime)
                {
                    Debug.Log("suck " + hit.name + "'s dick!");

                        bool isDead = hit.GetComponent<SeaWarHealthView>().TakeDamage(damage, gameObject);
                        isAttackTime = false; 
                        if (isDead)
                        {
                            frigateRotateController.nullTargetAction();

                            target = null;


                        }
                }
                
                isAttackTime = false;
            }

        }
       }
}