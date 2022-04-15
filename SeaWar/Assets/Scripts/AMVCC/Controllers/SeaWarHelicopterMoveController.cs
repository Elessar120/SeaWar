using System;
using System.Collections;
using UnityEngine;
using AMVCC.Views;
using System.Collections.Generic;
namespace AMVCC.Controllers
{
    public class SeaWarHelicopterMoveController : SeaWarElement
    {
        public List<GameObject> effectiveMagneticTowers;
        public Action <GameObject> onEffectedByMagneticTower;
        [SerializeField] float currentSpeed;
        [SerializeField] bool isStopTime;
        public bool isStopForever;

        [SerializeField] private SeaWarHelicopterView helicopterView;
        //public Action moveAction;
        private void Start()
        {
            effectiveMagneticTowers = new List<GameObject>();
            onEffectedByMagneticTower += AddMagneticTowerToList;
            currentSpeed = helicopterView.speed;
            isStopTime = GetComponent<SeaWarHelicopterView>().isStopTime;
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

            currentSpeed = helicopterView.speed;
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

            if (!isStopTime)
            {
                Move();
            }
           
        }

      

      

       
        private void Move()
        {
//            Debug.Log(speed);
            if (CompareTag("Blue"))
            {
                transform.position += Vector3.right * CalculateCurrentSpeed() * Time.deltaTime;
                
            }
            else if (CompareTag("Red"))
            {
                transform.position += Vector3.left * CalculateCurrentSpeed() * Time.deltaTime;

            }
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
            StartCoroutine(nameof(Delay));
            
        }
      
        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(.1f);
//            Debug.Log("stopmoving");
            isStopTime = true;
        }

        /*private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Refinery"))
            {
                if (!other.CompareTag(tag))
                {
                    isStopForever = true;
                    StopMoving();
                }
            }
        }*/
    }
}