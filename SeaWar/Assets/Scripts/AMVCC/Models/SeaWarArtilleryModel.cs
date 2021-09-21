using System;
using UnityEngine;

namespace AMVCC.Models
{
    public class SeaWarArtilleryModel : SeaWarElement
    {
        public float damage;
        public Unit artilleryData;
        public float fireRate;
        public float health;
        public float speed;
        public float cost;
    private void Awake()
        {
            damage = artilleryData.damage;
            speed = artilleryData.movmentSpeed;
            fireRate = artilleryData.fireRate;
            health = artilleryData.health;
            cost = artilleryData.costWithOil;
        }
    }
}