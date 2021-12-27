using System;
using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarRadioActiveTowerAttackController : SeaWarElement
    {
        private SeaWarPlatformView platformView;
        private bool isAttackTime;
        private float fireRate;
        [SerializeField] SeaWarRadioActiveTowerView radioActiveTowerView;

        private void Awake()
        {
            //Debug.Log(transform.parent.name);
        }

        private void Start()
        {
            //Debug.Log(transform.parent.name);
            //SetFireRate();
            fireRate = radioActiveTowerView.fireRate;
        }

        private void OnTriggerEnter(Collider other)
        {
            
            if (other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts") || other.gameObject.layer == LayerMask.NameToLayer("Air Crafts"))
                
            {
                //Debug.Log(transform.parent.name);
                //Debug.Log(other.gameObject.name);
                ////towerView.attackTargets.Add(other.gameObject);
                // Attack(other.gameObject);
               if (!other.gameObject.CompareTag(gameObject.tag) && other.name != "Battleship Missle(Clone)")
               {
                   //Debug.Log(GetComponent<SeaWarAttackView>().damage);
                   //other.gameObject.GetComponent<SeaWarHealthView>().TakeDamage(radioActiveTowerView.CalculateCurrentDamage(), gameObject);
                   //Debug.Log(radioActiveTowerView.CalculateCurrentDamage());
                   //isAttackTime = false;
               }

            }
            
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts") || other.gameObject.layer == LayerMask.NameToLayer("Air Crafts"))
            {
                if (!other.CompareTag(tag) && other.name != "Battleship Missle(Clone)")
                {
                    //Debug.Log(other.gameObject.name);

                    fireRate -= Time.deltaTime;
                    if (fireRate < 0)
                    {
                        fireRate = radioActiveTowerView.fireRate;
                        isAttackTime = true;
                    }
                    if (isAttackTime)
                    {
                        other.gameObject.GetComponent<SeaWarHealthView>().TakeDamage(radioActiveTowerView.CalculateCurrentDamage(), gameObject);
                       // Debug.Log(radioActiveTowerView.CalculateCurrentDamage());

                        isAttackTime = false;
                    }
                }
                /*if (other.GetComponent<SeaWarAttackView>() != null)
                {
                    other.GetComponent<SeaWarAttackView>().lastRecivedDamageTimeOfRadioactiveTower -= Time.deltaTime;
//                    Debug.Log("fireRate : "+ other.GetComponent<SeaWarAttackView>().lastRecivedDamageTimeOfRadioactiveTower);
                    
                    if (other.GetComponent<SeaWarAttackView>().lastRecivedDamageTimeOfRadioactiveTower <= 0)
                    {
                        //Attack(other.gameObject);
//                        Debug.Log(other.gameObject.name);

                        if (other.gameObject.GetComponent<SeaWarHealthView>())
                        {

                        }
                        //Debug.Log(GetComponent<SeaWarAttackView>().damage);
                        Debug.Log("Attack");
                        other.GetComponent<SeaWarAttackView>().lastRecivedDamageTimeOfRadioactiveTower =
                            Application.model.radioActiveTowerModel.fireRate;
                        //SetFireRate(other.gameObject);
                        // Debug.Log("fireRateSet : " + GetComponent<SeaWarAttackView>().fireRate);.
                        /*foreach (GameObject target in towerView.attackTargets)
                        {
                            Attack(target);
                            SetFireRate();
                        }#1#
                    }
                }*/

                
            }
            
        }

        private void Update()
        {
            
        }

        private void OnTriggerExit(Collider other)
        {
            //SetFireRate(other.gameObject);
        }

        private void SetFireRate(GameObject other)
        {
           //fireRate = towerView.fireRate;

        }

        private void Attack(GameObject other)
        {
           
        }

        private void OnDestroy()
      {
//          platformView.platformIsFull = false;
      }
    }
}