using System;
using UnityEngine;

namespace AMVCC.Models
{
    public class SeaWarBattleshipModel : SeaWarElement
    {
        public Unit battleshipData;
        public float missleSpeed;
        public float speed;
        public float health;
        public float missleHealth;
        public float damage;
        public float fireRate;
        public float rotateSpeed;
        public float cost;
        private void Awake()
        {
            missleSpeed = battleshipData.missleSpeed;
            speed = battleshipData.movmentSpeed;
            health = battleshipData.health;
            missleHealth = battleshipData.missleHealth;
            damage = battleshipData.damage;
            fireRate = battleshipData.fireRate;
            rotateSpeed = battleshipData.rotateSpeed;
            cost = battleshipData.costWithGold;
        }
    }
}