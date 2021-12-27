using System;
using UnityEngine;
using System.Collections.Generic;
namespace AMVCC.Views
{
    public class SeaWarArtilleryView : SeaWarElement
    {
        private List<GameObject> effectiveElectricTowers;
        [SerializeField]float currentDamage;
        public Action <GameObject> onEffectedByElectricTower;
        public float fireRate;
        public float damage;
        public float speed;
        public float rotateSpeed;
        private void Awake()
        {
            fireRate = Application.model.artilleryModel.fireRate;
            damage = Application.model.artilleryModel.damage;
            speed = Application.model.artilleryModel.speed;
            rotateSpeed = Application.model.artilleryModel.rotateSpeed;
        }

        private void Start()
        {
            effectiveElectricTowers = new List<GameObject>();
            onEffectedByElectricTower += AddElectricTowerToList;
        }
        private void AddElectricTowerToList(GameObject electricTower)
        {
            if (!effectiveElectricTowers.Contains(electricTower))
            {
                effectiveElectricTowers.Add(electricTower);

            }
            Debug.Log("lists count = " + effectiveElectricTowers.Count + " " + electricTower.name);
        }
        public float CalculateCurrentDamage()
        {

            currentDamage = damage;
            Debug.Log(effectiveElectricTowers.Count);
            for (int i = 0; i < effectiveElectricTowers.Count; i++)
            {
                if (!effectiveElectricTowers[i])
                {
                    effectiveElectricTowers.RemoveAt(i);

                }
                else
                {
                    currentDamage *= Application.model.electricTowerModel.damageIncreasedCoeffidency;
                }


            }

            return currentDamage;
        }
    }
}