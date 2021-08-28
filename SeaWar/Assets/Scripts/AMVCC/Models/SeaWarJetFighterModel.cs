using System;
using UnityEngine;

namespace AMVCC.Models
{
    public class SeaWarJetFighterModel : SeaWarElement
    {
        public Unit jetFighterData;
        public float damage;
        public float fireRate;
        public float explosionArea;
        public float costWithGold;
        public float cardsForUpgrade;
        public float speed;
        public float health;
        private void Awake()
        {
            damage = jetFighterData.damage;
            fireRate = jetFighterData.fireRate;
            explosionArea = jetFighterData.explosionArea;
            costWithGold = jetFighterData.costWithGold;
            cardsForUpgrade = jetFighterData.upgradeCardsNeed;
            speed = jetFighterData.movmentSpeed;
            health = jetFighterData.health;
        }
    }
}