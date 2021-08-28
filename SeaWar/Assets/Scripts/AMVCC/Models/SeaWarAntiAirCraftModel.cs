using System;
using UnityEngine;

namespace AMVCC.Models
{
    public class SeaWarAntiAirCraftModel : SeaWarElement
    {        
        public Unit antiAirCraftData;
        public float damage;
        public float health;
        public float fireRate;
        public float rotateSpeed;
        
        private void Awake()
        {
            damage = antiAirCraftData.damage;
            health = antiAirCraftData.health;
        }
    }
}