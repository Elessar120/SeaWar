using System;
using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class 
    SeaWarMotorBoatController : SeaWarElement
    {
        private float speed;
        private float damage;
        [SerializeField] private SeaWarMotorBoatView motorBoatView;
        private float fireRate;
        private bool isAttackTime;
        private bool isStopTime;
        private void Awake()
        {
            

        }

        private void Start()
        {
            speed = GetComponent<SeaWarAttackView>().speed;
            damage = GetComponent<SeaWarMotorBoatView>().damage;
            fireRate = motorBoatView.fireRate;
            isAttackTime = GetComponent<SeaWarMotorBoatView>().isAttackTime;
            isStopTime = GetComponent<SeaWarMotorBoatView>().isStopTime;
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
//                Debug.Log("raycast");
                if (!hit.collider.CompareTag(gameObject.tag))
                {
//                    Debug.Log("stop moving");
                    if (hit.collider.gameObject.name == "Refinery 1" || hit.collider.gameObject.name == "Refinery 2" || hit.collider.gameObject.name == "Refinery 3")
                    {
                        StopMoving();
                        Attack(hit);
                      
                    }
                }
                
            }
        }

        private void StopMoving()
        {
//            Debug.Log("stopmoving");
            isStopTime = true;
        }

        private void Attack(RaycastHit hit)
        {
//            Debug.Log(isStopTime);

            if (isAttackTime)
            {
                hit.collider.gameObject.GetComponentInParent<SeaWarHealthView>().TakeDamage(damage);
                isAttackTime = false;
            }
            
            fireRate -= Time.deltaTime;
            if (fireRate <= 0)
            {
                fireRate = GetComponent<SeaWarMotorBoatView>().fireRate;
                isAttackTime = true;
            }

        }
        private void Move()
        {
//            Debug.Log(speed);
            transform.position += transform.forward * speed * Time.deltaTime;
        }

    }
}