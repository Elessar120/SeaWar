using System;
using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarRadioActiveTowerAttackController : SeaWarElement
    {
        private SeaWarPlatformView platformView;
        private SeaWarRadioActiveTowerView towerView;

        private void Awake()
        {
//            Debug.Log(transform.parent.name);
        }

        private void Start()
        {
          //  Debug.Log(transform.parent.name);
            //SetFireRate();
        }

        private void OnTriggerEnter(Collider other)
        {
            
            if (!other.gameObject.CompareTag(gameObject.tag))
            {
                //Debug.Log(transform.parent.name);
//                Debug.Log(other.gameObject.name);
                //towerView.attackTargets.Add(other.gameObject);
               // Attack(other.gameObject);
               if (other.GetComponent<SeaWarHealthView>() != null)
               {
                   //Debug.Log(GetComponent<SeaWarAttackView>().damage);
                   other.gameObject.GetComponent<SeaWarHealthView>().TakeDamage(GetComponent<SeaWarAttackView>().damage);

               }

            }
            
        }

        private void OnTriggerStay(Collider other)
        {
            if (!other.gameObject.CompareTag(gameObject.tag))
            {
                if (other.GetComponent<SeaWarAttackView>() != null)
                {
                    other.GetComponent<SeaWarAttackView>().lastRecivedDamageTimeOfRadioactiveTower -= Time.deltaTime;
//                    Debug.Log("fireRate : "+ other.GetComponent<SeaWarAttackView>().lastRecivedDamageTimeOfRadioactiveTower);
                    
                    if (other.GetComponent<SeaWarAttackView>().lastRecivedDamageTimeOfRadioactiveTower <= 0)
                    {
                        //Attack(other.gameObject);
//                        Debug.Log(other.gameObject.name);

                        if (other.gameObject.GetComponent<SeaWarHealthView>())
                        {
                            other.gameObject.GetComponent<SeaWarHealthView>().TakeDamage(GetComponent<SeaWarAttackView>().damage);

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
                        }*/
                    }
                }

                
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