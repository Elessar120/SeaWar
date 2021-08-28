using System;
using UnityEngine;

namespace AMVCC.Models
{
    public class SeaWarHelicopterModel : SeaWarElement
    {
        public Unit hilicopterData;
        public float fireRate;
        public float health;
        public float damage;
        public float speed;
        public float rotateSpeed;
        private void Awake()
        {
            fireRate = hilicopterData.fireRate;
            health = hilicopterData.health;
            damage = hilicopterData.damage;
            speed = hilicopterData.movmentSpeed;
            rotateSpeed = hilicopterData.rotateSpeed;
        }
    }
}