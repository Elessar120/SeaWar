using UnityEngine;
using System;
using System.Collections;
using System.Linq;
using AMVCC.Views;
namespace AMVCC.Controllers
{
    public class SeaWarBattleshipAttackController : SeaWarElement
    {
        [SerializeField]private bool isAttackTime;
        private float fireRate;
        private float damage;
        private Vector3 directionVector;
        public Queue targets = new Queue();
        public Queue targetsPosition = new Queue();
        public Action onKillAction;
        private void Start()
        {
            fireRate = GetComponent<SeaWarBattleshipView>().fireRate;
            damage = GetComponent<SeaWarBattleshipView>().damage;
//            Debug.Log("fire rate is : " + fireRate);
            isAttackTime = true;
            onKillAction += RemoveQueue;
            onKillAction += CallActionInRotateClass;
            onKillAction += ChangeMovementStates;
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
                    targets.Enqueue(other);
                    GetComponentInChildren<SeaWarBattleshipRotateController>().reachEnemyAction(other);
                    
                    //targetsPosition.Enqueue(other.transform.position);

                    //Attack(other);
                }
                if (other.name == "Refinery 1" || other.name == "Refinery 2" || other.name == "Refinery 3")
                {
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
                        Attack((Collider)targets.Peek());

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

        private void Attack(Collider hit)
        {
            if (!hit.GetComponent<SeaWarHealthView>().attackers.Contains(gameObject))
            {
                hit.GetComponent<SeaWarHealthView>().attackers.Add(gameObject);     
            }
            Debug.Log("my name is : " + hit.name);
            //SeaWarHelicopterMoveController.moveAction();
            if (hit.transform.Find("Trench"))
            {
                if (isAttackTime)
                {
                    
                        var trench = hit.transform.Find("Trench");
                        trench.GetComponent<SeaWarHealthView>().TakeDamage(damage);
                        isAttackTime = false;
                }

                isAttackTime = false;

            }
            else if(!hit.transform.Find("Trench"))
            {
                if (isAttackTime)
                {
                    Debug.Log("suck " + hit.name + "'s dick!");

                        hit.GetComponent<SeaWarHealthView>().TakeDamage(damage);
                        isAttackTime = false; 
                }
                
                isAttackTime = false;
            }

        }

        private void RemoveQueue()
        {
            targets.Dequeue();

        }

        private void CallActionInRotateClass()
        {
            GetComponentInChildren<SeaWarBattleshipRotateController>().deadEnemyAction();                            

        }

        private void ChangeMovementStates()
        {
            if (targets.Count == 0)
            {
                GetComponentInParent<SeaWarBattleshipMoveController>().moveAction();

            }

        }
 
    }
}