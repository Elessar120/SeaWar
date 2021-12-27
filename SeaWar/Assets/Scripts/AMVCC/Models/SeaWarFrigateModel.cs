using System;
using UnityEngine;

namespace AMVCC.Models
{
    public class SeaWarFrigateModel : SeaWarElement
    {
        public Unit frigateData;
        public float health;
        public float fireRate;
        public float damage;
        public float speed;
        public float rotateSpeed;
        public float cost;
        private void Awake()
        {
            health = frigateData.health;
            fireRate = frigateData.fireRate;
            damage = frigateData.damage;
            speed = frigateData.movmentSpeed;
            rotateSpeed = frigateData.rotateSpeed;
            cost = frigateData.costWithGold;
        }
    }
}