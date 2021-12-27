using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace AMVCC.Views
{
    public class SeaWarRadioActiveTowerView : SeaWarElement
    {
        private List<GameObject> effectiveElectricTowers;
        public Action <GameObject> onEffectedByElectricTower;
        public float health;
        public float damage;
        public float fireRate;
        [SerializeField]float currentDamage;

        //public List<GameObject> attackTargets;
        private void Awake()
        {
            health = Application.model.radioActiveTowerModel.health;
            damage = Application.model.radioActiveTowerModel.damage;
            fireRate = Application.model.radioActiveTowerModel.fireRate;
            //attackTargets = new List<GameObject>();
        }

        private void Start()
        {
            effectiveElectricTowers = new List<GameObject>();
            onEffectedByElectricTower += AddElectricTowerToList;
            currentDamage = damage;
        }
        private void AddElectricTowerToList(GameObject electricTower)
        {
            if (!effectiveElectricTowers.Contains(electricTower))
            {
                effectiveElectricTowers.Add(electricTower);

            }
            Debug.Log("lists count = " + effectiveElectricTowers.Count + " " + electricTower.name);
        }

        private void Update()
        {
           
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