using System;
using AMVCC.Models;
using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarJetFighterAttckController : SeaWarElement
    {
        [SerializeField] private GameObject bomb;
        [SerializeField] private Transform bombLauncher;
        [SerializeField] private SeaWarJetFighterView jetFighterView;
        [SerializeField] bool isAttackTime;
        [SerializeField] float fireRate;
        private bool hasTrench;
        private void Start()
        {
            tag = GetComponentInParent<Transform>().tag;
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
            Launch();

        }

        private void OnTriggerEnter(Collider other)
        {

            /*if (!other.CompareTag(tag))
            {

                if (other.gameObject.layer == LayerMask.NameToLayer("Buildings") || other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts") || other.gameObject.layer == LayerMask.NameToLayer("Refinery"))

                {
                    Debug.Log("cumiiiiiiiiiing! to " + other.name + " pussy! it is so good!");

                    //StopMoving();
                    Attack(other);
                }
            }*/
        }
        private void OnTriggerStay(Collider other)    
        {
            if (!other.CompareTag(tag))
            {
                if (other.gameObject.layer == LayerMask.NameToLayer("Buildings") || other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts") || other.gameObject.layer == LayerMask.NameToLayer("Refinery"))

                {
                    //Debug.Log("cumiiiiiiiiiing! to " + other.name + " pussy! it is so good!");

                    //StopMoving();
                }
            }
        }
        private void Launch()
        {
           
            if (isAttackTime)
            {
                    
                //trench.GetComponent<SeaWarHealthView>().TakeDamage(damage);
                BombSpawner();
                isAttackTime = false;
            }
        }
        private void BombSpawner()
        {
            GameObject spawnedBomb = Instantiate(bomb,bombLauncher.position,bombLauncher.rotation);
            spawnedBomb.tag = transform.parent.tag;
            //spawnedBomb.GetComponent<SeaWarJetFighterBombMoveController>().target = target;
            //spawnedBomb.GetComponent<SeaWarJetFighterBombAttackController>().target = target;

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
                    trench.GetComponent<SeaWarHealthView>().TakeDamage(jetFighterView.damage, gameObject);
                }

                isAttackTime = false;

            }
            else if(!hit.transform.Find("Trench"))
            {
                if (isAttackTime)
                {
                    hit.GetComponent<SeaWarHealthView>().TakeDamage(jetFighterView.damage, gameObject);

                }

                isAttackTime = false;
            }

        }
    }
}