using System;
using System.Collections;
using UnityEngine;
using AMVCC.Views;
using System.Collections.Generic;

namespace AMVCC.Controllers
{
    public class SeaWarFrigateMoveController : SeaWarElement
    {
        private List<GameObject> effectiveMagneticTowers;
        public Action <GameObject> onEffectedByMagneticTower;
        [SerializeField] float currentSpeed;
        [SerializeField] private SeaWarFrigateView frigateView;
        [SerializeField] bool isStopTime;

        private bool isStopForever;

        // public Action moveAction;//todo like helicopter
        private void Start()
        {
            effectiveMagneticTowers = new List<GameObject>();
            onEffectedByMagneticTower += AddMagneticTowerToList;
            currentSpeed = frigateView.speed;
            isStopTime = GetComponent<SeaWarFrigateView>().isStopTime;
            //moveAction += SetMoveState;
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

            currentSpeed = frigateView.speed;
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
//            Debug.Log(isStopTime);

            if (!isStopTime)
            {
                Move();
            }
           
        }
        private void Move()
        {
//            Debug.Log(speed);
            transform.position += transform.forward * CalculateCurrentSpeed() * Time.deltaTime;
//            Debug.Log(speed);

        }
        public void Moving()
        {
            if (!isStopForever)
            {
                isStopTime = false;

            }

        }
        public void StopMoving()
        {
            isStopTime = true;

           // StartCoroutine(nameof(Delay));
            
        }
      
        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(.1f);
//            Debug.Log("stopmoving");
            isStopTime = true;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Refinery"))
            {
                if (!other.CompareTag(tag))
                {
                    Debug.Log("collide!");
                    isStopForever = true;
                    StopMoving();
                }
               
            }            
        }


       

       

        
       
        
    }
}