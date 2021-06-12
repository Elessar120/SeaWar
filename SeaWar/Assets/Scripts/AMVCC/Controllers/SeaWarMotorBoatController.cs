using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarMotorBoatController : SeaWarElement
    {
        private float speed;
        private float damage;
        private float fireRate;
        private bool isAttackTime;
        private bool isStopTime;
        private void Awake()
        {
            speed = GetComponent<SeaWarMotorBoatView>().speed;
            damage = GetComponent<SeaWarMotorBoatView>().damage;
            fireRate = GetComponent<SeaWarMotorBoatView>().fireRate;
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
                Debug.Log("raycast");
                if (gameObject.layer == LayerMask.NameToLayer("Blue"))
                {
                    if (hit.collider.gameObject.CompareTag("RedRefinery"))
                    {
                        StopMoving();
                        Attack(hit);
                      
                    }
                }
                else if (gameObject.layer == LayerMask.NameToLayer("Red"))  
                {
                    if (hit.collider.gameObject.CompareTag("BlueRefinery"))
                    {
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
                fireRate = GetComponent<SeaWarMotorBoatView>().fireRate;
                isAttackTime = true;
            }

        }

        private void Move()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            
            
            
        }
    }
}