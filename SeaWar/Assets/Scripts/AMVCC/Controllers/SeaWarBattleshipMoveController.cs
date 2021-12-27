using UnityEngine;
using System;
using System.Linq;
using AMVCC.Views;
using System.Collections.Generic;


namespace AMVCC.Controllers
{

    public class SeaWarBattleshipMoveController : SeaWarElement
    {
        private bool isUnderBridge;
        private List<GameObject> effectiveMagneticTowers;
        public Action <GameObject> onEffectedByMagneticTower;
        [SerializeField] float currentSpeed;
        public bool isStopTime;
        public bool isStopTimeForEver;
        
        [SerializeField] private SeaWarBattleshipView battleshipView;
        private void Start()
        {
            effectiveMagneticTowers = new List<GameObject>();
            onEffectedByMagneticTower += AddMagneticTowerToList;
            currentSpeed = battleshipView.speed;
            isStopTime = GetComponent<SeaWarBattleshipView>().isStopTime;
            
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

            currentSpeed = battleshipView.speed;
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

            if (!isStopTime && !isStopTimeForEver)
            {
                Move();
            }
           
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(transform.tag))
            {
                
                 if (other.gameObject.layer == LayerMask.NameToLayer("Refinery"))
                 {
                     isStopTimeForEver = true;
                     Debug.Log("collide!"); 
                     isStopTime = true;
                 }
               
                
            }  
        }


       

        private void Move()
        {
//            Debug.Log(speed);
            transform.position += transform.forward * CalculateCurrentSpeed() * Time.deltaTime;
//            Debug.Log(speed);

        }

        
       
    }
}