using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AMVCC.Views;
namespace AMVCC.Controllers
{
    public class SeaWarBattleshipAttackController : SeaWarElement
    {
        [SerializeField] bool isUnderBridge;
        private GameObject target;
        [SerializeField]private bool isAttackTime;
        private bool isStoppedForEver;
        [SerializeField] private GameObject missle;
        [SerializeField] private Transform missleLauncher; 
        public SeaWarBattleshipMoveController battleshipMoveController;
        private float fireRate;
        public Queue<GameObject> targets = new Queue<GameObject>();
        private List<GameObject> launchedMissles = new List<GameObject>(); 
        private void Start()
        {
            tag = GetComponentInParent<Transform>().tag;
            fireRate = GetComponent<SeaWarBattleshipView>().fireRate;
            isAttackTime = true;
        }

        /*private void UpdateMissilsTarget(GameObject target)
        {
            foreach (Transform child in transform)
            {
                if (child.name == "Battleship Missle(Clone)")
                {
                    child.GetComponent<SeaWarBattleshipMissleMoveController>().noEnemyAction();
                }
            }
            
        }*/

        private void DeleteDestroyedMissleFromList(GameObject destroyedmissle)
        {
            launchedMissles.Remove(destroyedmissle);
        }
        private void Update()
        {
            RaycastHit hit;
            if (Physics.Raycast(missleLauncher.position,Vector3.up, out hit, 2))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Bridge"))
                {
                    if (!isUnderBridge)
                    {
                        isUnderBridge = true;

                    }
                }
                
            }
            else 
            {
                Debug.Log("I am else");
                if (isUnderBridge)
                {
                    isUnderBridge = false;

                }
            }
                
            if (target == null)
            {
                battleshipMoveController.isStopTime = false;

            }
            if (!isAttackTime)
            {
                fireRate -= Time.deltaTime;
                if (fireRate <= 0)
                {
                    fireRate = GetComponent<SeaWarBattleshipView>().fireRate;
                    isAttackTime = true;
                }
            }
//            Debug.Log("targets count : " + targets.Count);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(transform.parent.tag))
            {
                if (other.gameObject.layer == LayerMask.NameToLayer("Buildings"))
                {
                    if (!isUnderBridge)
                    {
                        if (!battleshipMoveController.isStopTime)
                        {
                            battleshipMoveController.isStopTime = true;
                        }

                    }                   
                    if (target == null)
                    {
                        target = other.gameObject;
                    }
//                    Debug.Log("push it!");
                    //targets.Enqueue(other.gameObject);
                    //GetComponentInChildren<SeaWarBattleshipRotateController>().reachEnemyAction(other);
                    
                    //targetsPosition.Enqueue(other.transform.position);

                    //Attack(other);
                }
                /*else if (other.gameObject.layer == LayerMask.NameToLayer("Refinery"))
                {
                    battleshipMoveController.isStopTimeForEver = true;
                    Debug.Log("collide!"); 
                    battleshipMoveController.isStopTime = true;
                }*/
               
                
            }
        }
        
        private void OnTriggerStay(Collider other)
        {
            
//            Debug.Log(other.gameObject.name);
            if (!other.CompareTag(transform.parent.tag))
            {
                if ( other.gameObject.layer == LayerMask.NameToLayer("Buildings"))
                {
                    
                    if (target == null)
                    {
                        target = other.gameObject;
                        /*if (!isUnderBridge)
                        {
                            battleshipMoveController.isStopTime = true;

                        }
                        else if (isUnderBridge)
                        {
                            while (!isUnderBridge)
                            {
                                
                            }
                        }*/
                        //battleshipMoveController.isStopTime = true;
                    }
                    /*if (!other.GetComponent<SeaWarHealthView>().attackers.Contains(gameObject))
                    {
                        other.GetComponent<SeaWarHealthView>().attackers.Add(gameObject);     
                    }*/

                    if (target)
                    {
                        if (!isUnderBridge)
                        {
                            if (!battleshipMoveController.isStopTime)
                            {
                                battleshipMoveController.isStopTime = true;

                            }
                            Launch(other);

                        }
                        /*else if (isUnderBridge)
                        {
                            while (!isUnderBridge)
                            {
                                if (battleshipMoveController.isStopTime)
                                {
                                    battleshipMoveController.isStopTime = false;
                                }
                            }
                        }*/
                       
                    }

                    
                    
                }
                    //todo StartCoroutine("Rotator");
                    
                   
            }
           
        }

       private void Launch(Collider hit)
        {
           
                if (isAttackTime && !isUnderBridge)
                {
                    
                        //trench.GetComponent<SeaWarHealthView>().TakeDamage(damage);
                        MissleSpawner(hit);
                        isAttackTime = false;
                }
        }

        private void MissleSpawner(Collider other)
        {
            GameObject spawnedMissle = Instantiate(missle,missleLauncher.position,missleLauncher.transform.rotation * Quaternion.Euler(-90,0,0));
            spawnedMissle.GetComponent<SeaWarBattleshipMissleMoveController>().target = target;
            
            spawnedMissle.tag = gameObject.transform.parent.tag;
           
        }

    }
}