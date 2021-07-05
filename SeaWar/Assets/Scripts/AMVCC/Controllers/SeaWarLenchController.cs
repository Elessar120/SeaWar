using System;
using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarLenchController : SeaWarElement
    {
        private float speed;
        private float damage;
        private float fireRate;
        private bool isAttackTime;
        private bool isStopTime;
        private void Awake()
        {
            

        }

        private void Start()
        {
            speed = GetComponent<SeaWarAttackView>().speed;
            damage = GetComponent<SeaWarLenchView>().damage;
            fireRate = GetComponent<SeaWarLenchView>().fireRate;
            isAttackTime = GetComponent<SeaWarLenchView>().isAttackTime;
            isStopTime = GetComponent<SeaWarLenchView>().isStopTime;
        }

        private void Update()
        {
            
            RayCastingAndSearchingEnemy();
            if (!isStopTime)
            {
                Move();

            }
        }

        private void RayCastingAndSearchingEnemy()
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position , gameObject.transform.forward);
            Debug.DrawRay(transform.position,gameObject.transform.forward * 2, Color.red);
            
            if (Physics.Raycast(ray,out hit, 2f))
            {
                if (!gameObject.CompareTag(hit.collider.tag))
                {
                    if (hit.collider.gameObject.name == "Refinery")
                    {
                        Debug.Log("raycastHit " + hit.collider.name);

                        StopMoving();
                        Attack(hit);
                      
                    }
                } 
                
                
            }
        }

        private void StopMoving()
        {
            Debug.Log("stopmoving");
            isStopTime = true;
        }

        private void Attack(RaycastHit hit)
        {
            Debug.Log(isStopTime);

            if (isAttackTime)
            {
                hit.collider.gameObject.GetComponentInParent<SeaWarRefineryController>().TakeDamage(damage);
                isAttackTime = false;
            }
            
            fireRate -= Time.time;
            if (fireRate <= 0)
            {
                fireRate = GetComponent<SeaWarLenchView>().fireRate;
                isAttackTime = true;
            }

        }

        private void Move()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

    }
}
