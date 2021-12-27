using System;
using UnityEngine;

namespace AMVCC.Models
{
    public class SeaWarMagneticTowerModel : SeaWarElement
    {
        public float health;
        public float enemyCoenfficientSlowDown;
        public int cardsForUpgrade;
        public Unit magneticTowerData;
        public float cost;
        private void Awake()
        {
            health = magneticTowerData.health;
            enemyCoenfficientSlowDown = magneticTowerData.enemySlowDownCoefficient;
            cardsForUpgrade = magneticTowerData.upgradeCardsNeed;
            cost = magneticTowerData.costWithOil;
        }
    }
}