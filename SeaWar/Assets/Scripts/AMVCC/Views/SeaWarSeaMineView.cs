using System;
using UnityEngine;
using System.Collections.Generic;


namespace AMVCC.Views
{
    public class SeaWarSeaMineView : SeaWarElement

    {
        [SerializeField]float currentDamage;
        private List<GameObject> effectiveElectricTowers;
        public Action <GameObject> onEffectedByElectricTower;
        public float damage;

        private void Awake()
        {
            damage = Application.model.seaMineModel.damage;
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