using System;
using AMVCC.Models;
using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarJetFighterAttckController : SeaWarElement
    {
        [SerializeField] bool isAttackTime;
        [SerializeField] float fireRate;
        private bool hasTrench;
        private void Start()
        {
            fireRate = GetComponent<SeaWarJetFighterView>().fireRate;
            Debug.Log("fire rate is : " + fireRate);
            isAttackTime = true;
        }

        private void Update()
        {
            if (!isAttackTime)
            {
                fireRate -= Time.deltaTime;
                if (fireRate <= 0)
                {
                    fireRate = GetComponent<SeaWarJetFighterView>().fireRate;
                    isAttackTime = true;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {

            if (!other.CompareTag(transform.parent.tag))
            {

                if (other.gameObject.layer == LayerMask.NameToLayer("Buildings") || other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts") || other.gameObject.layer == LayerMask.NameToLayer("Refinery"))

                {
                    Debug.Log("cumiiiiiiiiiing! to " + other.name + " pussy! it is so good!");

                    //StopMoving();
                    Attack(other);
                }
            }
        }
        private void OnTriggerStay(Collider other)    
        {
            if (!other.CompareTag(transform.parent.tag))
            {
                if (other.gameObject.layer == LayerMask.NameToLayer("Buildings") || other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts") || other.gameObject.layer == LayerMask.NameToLayer("Refinery"))

                {
                    Debug.Log("cumiiiiiiiiiing! to " + other.name + " pussy! it is so good!");

                    //StopMoving();
                    Attack(other);
                }
            }
        }

        private void Attack(Collider hit)
        {
            if (hit.name == "Water 1" || hit.name == "Water 2" || hit.name == "Water 3")
            {
                
            }

            if (hit.transform.Find("Trench"))
            {
                if (isAttackTime)
                {
                    var trench = hit.transform.Find("Trench");
                    hasTrench = true;
                    trench.GetComponent<SeaWarHealthView>().TakeDamage(GetComponent<SeaWarAttackView>().damage);
                }

                isAttackTime = false;

            }
            else if(!hit.transform.Find("Trench"))
            {
                if (isAttackTime)
                {
                    hit.GetComponent<SeaWarHealthView>().TakeDamage(GetComponent<SeaWarAttackView>().damage);

                }

                isAttackTime = false;
            }

            /*if (isAttackTime)
            {
                if (hit.gameObject.GetComponent<SeaWarHealthView>())
                {
                    hit.gameObject.GetComponent<SeaWarHealthView>().TakeDamage(GetComponent<SeaWarAttackView>().damage);
                    Debug.Log("Air Attack hited to : " + hit.name);

                } 
                isAttackTime = false;
            }*/
            
            
            
            /*if(hit.gameObject.GetComponentInParent<SeaWarHealthView>())
            {
                hit.gameObject.GetComponentInParent<SeaWarHealthView>().TakeDamage(GetComponent<SeaWarAttackView>().damage);

            }*/
            
        }
    }
}