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
        
        private void Awake()
        {
            health = magneticTowerData.health;
            enemyCoenfficientSlowDown = magneticTowerData.enemySlowDownCoefficient;
            cardsForUpgrade = magneticTowerData.upgradeCardsNeed;
        }
    }
}