using System;
using AMVCC.Views;
using UnityEngine;
using System.Collections.Generic;
namespace AMVCC.Controllers
{
    public class SeaWarLenchController : SeaWarElement
    {
        public List<GameObject> effectiveMagneticTowers;
        public Action <GameObject> onEffectedByMagneticTower;
        [SerializeField] float currentSpeed;
        private float damage;
        [SerializeField] SeaWarLenchView lenchView;
        private float fireRate; 
        private bool isAttackTime;
        private bool isStopTime;
        private void Awake()
        {
            

        }

        private void Start()
        {
            effectiveMagneticTowers = new List<GameObject>();
            onEffectedByMagneticTower += AddMagneticTowerToList;
            currentSpeed = lenchView.speed;
            damage = GetComponent<SeaWarLenchView>().damage;
            fireRate = lenchView.fireRate;
            isAttackTime = GetComponent<SeaWarLenchView>().isAttackTime;
            isStopTime = GetComponent<SeaWarLenchView>().isStopTime;
        }
        private void AddMagneticTowerToList(GameObject magneticTower)
        {
            if (!effectiveMagneticTowers.Contains(magneticTower))
            {
                effectiveMagneticTowers.Add(magneticTower);

            }
            Debug.Log("lists count = " + effectiveMagneticTowers.Count + " " + magneticTower.name);
        }
        public float CalculateCurrentSpeed()
        {

            currentSpeed = lenchView.speed;
            Debug.Log(effectiveMagneticTowers.Count);
            for (int i = 0; i < effectiveMagneticTowers.Count; i++)
            {
                if (!effectiveMagneticTowers[i])
                {
                    effectiveMagneticTowers.RemoveAt(i);

                }
                else
                {
                    currentSpeed *= Application.model.magneticTowerModel.enemyCoenfficientSlowDown;

                }


            }

            return currentSpeed;
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
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Refinery"))
                    {
//                        Debug.Log("raycastHit " + hit.collider.name);

                        StopMoving();
                        Attack(hit);
                      
                    }
                } 
                
            }
        }

        private void StopMoving()
        {
           // Debug.Log("stopmoving");
            isStopTime = true;
        }

        private void Attack(RaycastHit hit)
        {
//            Debug.Log(isStopTime);

            if (isAttackTime)
            {
                hit.collider.gameObject.GetComponentInParent<SeaWarHealthView>().TakeDamage(damage, gameObject);
                isAttackTime = false;
            }
            
            fireRate -= Time.deltaTime;
            if (fireRate <= 0)
            {
                fireRate = GetComponent<SeaWarLenchView>().fireRate;
                isAttackTime = true;
            }

        }

        private void Move()
        {
            transform.position += transform.forward * CalculateCurrentSpeed() * Time.deltaTime;
        }

    }
}
