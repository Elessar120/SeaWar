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
        private float fireRate;
        public Queue<GameObject> targets = new Queue<GameObject>();
        private List<GameObject> launchedMissles = new List<GameObject>(); 
        public Action<GameObject> onKillAction;
        public Action<GameObject> onMissleDestroyed;
        private void Start()
        {
            fireRate = GetComponent<SeaWarBattleshipView>().fireRate;
            isAttackTime = true;
            onKillAction += RemoveQueue;
            //onKillAction += CallActionInRotateClass;
            onKillAction += ChangeMovementStates;
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
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(transform.parent.tag))
            {
                if (other.gameObject.name == "Radioactive Tower" || other.gameObject.name == "Magnetic Tower" || other.gameObject.name == "Electric Tower" || other.gameObject.name == "Trench" || other.gameObject.name == "Anti Air Craft" || other.gameObject.name == "Artillery")
                {
                    GetComponentInParent<SeaWarBattleshipMoveController>().StopMoving();

                    Debug.Log("push it!");
                    targets.Enqueue(other.gameObject);
                    //GetComponentInChildren<SeaWarBattleshipRotateController>().reachEnemyAction(other);
                    
                    //targetsPosition.Enqueue(other.transform.position);

                    //Attack(other);
                }
                if (other.name == "Refinery 1" || other.name == "Refinery 2" || other.name == "Refinery 3")
                {
                    isStoppedForEver = true;
                    Debug.Log("collide!");
                    GetComponentInParent<SeaWarBattleshipMoveController>().moveAction();
                }
                
            }
        }
        
        private void OnTriggerStay(Collider other)
        {
//            Debug.Log(other.gameObject.name);
            if (!other.CompareTag(transform.parent.tag))
            {
                    if (other.gameObject.name == "Radioactive Tower" || other.gameObject.name == "Magnetic Tower" || other.gameObject.name == "Electric Tower" || other.gameObject.name == "Trench" || other.gameObject.name == "Anti Air Craft" || other.gameObject.name == "Artillery") 
                    {
                        //GetComponentInParent<SeaWarHelicopterMoveController>().moveAction();
                        //todo StartCoroutine("Rotator");
                        if (targets.Count != 0)
                        {
                            Launch(targets.Peek());

                        }
                    }
               
                
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

        private void Launch(GameObject hit)
        {
            if (!hit.GetComponent<SeaWarHealthView>().attackers.Contains(gameObject))
            {
                hit.GetComponent<SeaWarHealthView>().attackers.Add(gameObject);     
            }
            Debug.Log("my name is : " + hit.name);
            //SeaWarHelicopterMoveController.moveAction();
            
                if (isAttackTime)
                {
                    
                        //trench.GetComponent<SeaWarHealthView>().TakeDamage(damage);
                        MissleSpawner();
                        isAttackTime = false;
                }
        }

        private void MissleSpawner()
        {
            GameObject spawnedMissle = Instantiate(missle,missleLauncher.position,missleLauncher.transform.rotation * Quaternion.Euler(-90,0,0));
            spawnedMissle.GetComponent<SeaWarBattleshipMissleMoveController>().target = targets.Peek();
            spawnedMissle.tag = gameObject.transform.parent.tag;
            //spawnedMissle.GetComponentInChildren<SeaWarBattleshipMissleAttackController>().motherBattleship =
              //  spawnedMissle;
            //launchedMissles.Add(spawnedMissle);
            //spawnedMissle.transform.SetParent(transform);    
        }

        private void RemoveQueue(GameObject removedtarget)
        {
            /*foreach (var VARIABLE in targets)
            {
                Debug.Log("targets : " + VARIABLE.name);
            }*/
            targets = new Queue<GameObject>(targets.Where(removedtarget => !targets.Contains(removedtarget)));
            /*foreach (var VARIABLE in targets)
            {
                Debug.Log("targets : " + VARIABLE.name);
            }*/

        }

        /*private void CallActionInRotateClass(GameObject target)
        {
            GetComponentInChildren<SeaWarBattleshipRotateController>().deadEnemyAction();                            

        }*/

        private void ChangeMovementStates(GameObject target)
        {
            if (targets.Count == 0 && !isStoppedForEver)
            {
                
                GetComponentInParent<SeaWarBattleshipMoveController>().moveAction();

            }

        }

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