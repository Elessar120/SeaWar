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
        [SerializeField]private bool isAttackTime;
        private bool isStoppedForEver;
        [SerializeField] private GameObject missle;
        [SerializeField] private Transform missleLauncher; 
        public SeaWarBattleshipMoveController battleshipMoveController;
        private float fireRate;
        public Queue<GameObject> targets = new Queue<GameObject>();
        private List<GameObject> launchedMissles = new List<GameObject>(); 
        public Action onKillAction;
        public Action<GameObject> onMissleDestroyed;
        private void Start()
        {
            fireRate = GetComponent<SeaWarBattleshipView>().fireRate;
            isAttackTime = true;
            //onKillAction += RemoveQueue;
            //onKillAction += CallActionInRotateClass;
            //onKillAction += ChangeMovementStates;
            //onKillAction += UpdateMissilsTarget;
            onMissleDestroyed += DeleteDestroyedMissleFromList;
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
                    battleshipMoveController.isStopTime = true;

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
                    if (other)
                    { 
                        Launch(other);

                    }
                }
                    //GetComponentInParent<SeaWarHelicopterMoveController>().moveAction();
                    //todo StartCoroutine("Rotator");
                    
                   
            }
           
        }

        /*private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag(transform.parent.tag))
            {
                if (other.gameObject.name == "Radioactive Tower" || other.gameObject.name == "Magnetic Tower" || other.gameObject.name == "Electric Tower" || other.gameObject.name == "Trench" || other.gameObject.name == "Anti Air Craft" || other.gameObject.name == "Artillery" || other.gameObject.name == "Refinery 1" || other.gameObject.name == "Refinery 2" || other.gameObject.name == "Refinery 3")
                {
                    GetComponentInParent<SeaWarHelicopterMoveController>().moveAction();
                    
                }
                
            }
        }*/

        private void Launch(Collider hit)
        {
            if (!hit.GetComponent<SeaWarHealthView>().attackers.Contains(gameObject))
            {
                hit.GetComponent<SeaWarHealthView>().attackers.Add(gameObject);     
            }
//            Debug.Log("my name is : " + hit.name);
            //SeaWarHelicopterMoveController.moveAction();
            
                if (isAttackTime)
                {
                    
                        //trench.GetComponent<SeaWarHealthView>().TakeDamage(damage);
                        MissleSpawner(hit);
                        isAttackTime = false;
                }
        }

        private void MissleSpawner(Collider other)
        {
            GameObject spawnedMissle = Instantiate(missle,missleLauncher.position,missleLauncher.transform.rotation * Quaternion.Euler(-90,0,0));
            spawnedMissle.GetComponent<SeaWarBattleshipMissleMoveController>().target = other.gameObject;
            
            spawnedMissle.tag = gameObject.transform.parent.tag;
            //spawnedMissle.GetComponentInChildren<SeaWarBattleshipMissleAttackController>().motherBattleship =
              //  spawnedMissle;
            //launchedMissles.Add(spawnedMissle);
            //spawnedMissle.transform.SetParent(transform);    
        }

        private void RemoveQueue(GameObject removedtarget)
        {
            targets.Dequeue();
            /*foreach (var VARIABLE in targets)
            {
                Debug.Log("targets : " + VARIABLE.name);
            }*/
            //targets = new Queue<GameObject>(targets.Where(removedtarget => !targets.Contains(removedtarget)));
            /*foreach (var VARIABLE in targets)
            {
                Debug.Log("targets : " + VARIABLE.name);
            }*/

        }

        /*private void CallActionInRotateClass(GameObject target)
        {
            GetComponentInChildren<SeaWarBattleshipRotateController>().deadEnemyAction();                            

        }*/

        /*private void ChangeMovementStates()
        {
            if (/*targets.Count == 0 &&#1# !isStoppedForEver)
            {
                
                GetComponentInParent<SeaWarBattleshipMoveController>().onMoveAction();

            }

        }*/

        private void OnDestroy()
        {
            foreach (Transform child in transform)
            {
                if (child.name == "Battleship Missle(Clone)")
                {
                    child.transform.SetParent(null);
                        
                }
            }
        }
    }
}