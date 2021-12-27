using System;
using UnityEngine;

namespace AMVCC.Models
{
    public class SeaWarElectricTowerModel : MonoBehaviour
    {
        public float damageIncreasedCoeffidency;
        public Unit electricTowerData;
        public float health;
        public float cost;
        private void Awake()
        {
            damageIncreasedCoeffidency = electricTowerData.increasedDamageCoefficient;
            health = electricTowerData.health;
            cost = electricTowerData.costWithGold;
        }
    }
}