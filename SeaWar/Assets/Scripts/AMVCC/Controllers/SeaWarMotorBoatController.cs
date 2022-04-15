using System;
using AMVCC.Views;
using UnityEngine;
using System.Collections.Generic;

namespace AMVCC.Controllers
{
    public class 
    SeaWarMotorBoatController : SeaWarElement
    {
        public List<GameObject> effectiveMagneticTowers;
        public Action <GameObject> onEffectedByMagneticTower;
        private float damage;
        [SerializeField] private SeaWarMotorBoatView motorBoatView;
        [SerializeField] private SeaWarSpeedController speedController;
        private float fireRate;
        private bool isAttackTime;
        private bool isStopTime;
        private Transform myTransform;
        [SerializeField] float currentSpeed;
        private void Awake()
        {
            

        }

        private void Start()
        {
            effectiveMagneticTowers = new List<GameObject>();
            onEffectedByMagneticTower += AddMagneticTowerToList;
            currentSpeed = motorBoatView.speed;
            damage = GetComponent<SeaWarMotorBoatView>().damage;
            fireRate = motorBoatView.fireRate;
            isAttackTime = GetComponent<SeaWarMotorBoatView>().isAttackTime;
            isStopTime = GetComponent<SeaWarMotorBoatView>().isStopTime;
            myTransform = GetComponent<Transform>();
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

            currentSpeed = motorBoatView.speed;
//            Debug.Log(effectiveMagneticTowers.Count);
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
            Debug.Log(effectiveMagneticTowers.Count);
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
                hit.collider.gameObject.GetComponentInParent<SeaWarHealthView>().TakeDamage(damage, gameObject);
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
//            Debug.Log(CalculateCurrentSpeed());
            myTransform.position += (myTransform.forward) * (CalculateCurrentSpeed()) * (Time.deltaTime);
        }

    }
}