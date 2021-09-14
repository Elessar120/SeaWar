using System;
using System.Collections;
using UnityEngine;
using AMVCC.Views;
using UnityEditor;

namespace AMVCC.Controllers
{
    public class SeaWarAntiAirCraftController : SeaWarElement
    {
        [SerializeField]private float fireRate;
        [SerializeField]private bool isAttackTime;
        [SerializeField] private SeaWarAttackView attackView;
        private void Start()
        {
            isAttackTime = true;
            fireRate = attackView.fireRate;
        }

        private void Update()
        {
            if (!isAttackTime)
            {
                fireRate -= Time.deltaTime;
                if (fireRate <= 0)
                {
                    isAttackTime = true;
                    fireRate = GetComponent<SeaWarAttackView>().fireRate;
                }
                    
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(gameObject.tag))
            {

                if (other.gameObject.layer == LayerMask.NameToLayer("Air Crafts"))

                {

//todo                    StartCoroutine("Rotator");
                   Attack(other);
                    InvokeRepeating("FindingEnemy",0,0.1f);

                }
                
            }
        }

        private void FindingEnemy()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 5);
            foreach (Collider other in colliders)
            {
                if (!other.CompareTag(gameObject.tag))
                {

                    if (other.gameObject.layer == LayerMask.NameToLayer("Air Crafts"))

                    {
                        Attack(other);
                    

                    }
                
                }
                
            }
            
        }

        //private void OnDrawGizmos()
        /*{
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position,5);
        }*/

        /*todo private IEnumerator Rotator()
        {
            yield return new WaitForSeconds(1);
        }*/
        private void Attack(Collider hit)
        {

            if (isAttackTime)
            {
                hit.GetComponent<SeaWarHealthView>().TakeDamage(GetComponent<SeaWarAntiAirCraftView>().damage);
                Debug.Log("AHHHH! " + hit.name + "is in me! it's damage is : " + GetComponent<SeaWarAttackView>().damage);

            }

            isAttackTime = false;

        }

       
    }
}