using UnityEngine;
using AMVCC.Views;
using System;
using System.Collections.Generic;



namespace AMVCC.Controllers
{
    public class JetFighterMoveController : SeaWarElement
    
    {
        private List<GameObject> effectiveMagneticTowers;
        public Action <GameObject> onEffectedByMagneticTower;
        [SerializeField] float currentSpeed;
        [SerializeField] private SeaWarJetFighterView jetFighterView;
        private void Start()
        {
            effectiveMagneticTowers = new List<GameObject>();
            onEffectedByMagneticTower += AddMagneticTowerToList;
            currentSpeed = jetFighterView.speed;
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

            currentSpeed = jetFighterView.speed;
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
            Move();
        }

        private void Move()
        {
            transform.position += transform.forward * CalculateCurrentSpeed() * Time.deltaTime;
        }
   
  }
}