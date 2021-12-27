using System;
using System.Collections;
using System.Collections.Generic;
using AMVCC;
using UnityEngine;
using UnityEngine.Serialization;

namespace AMVCC.Models
{
    public class SeaWarMotorBoatModel : SeaWarElement
    {
        [FormerlySerializedAs("lenchData")] public Unit motorBoatData;
        public float health;
        public float fireRate;
        public float sightRange;
        public float costWithOil;
        public int upgradeCost;
        public float damage;
        public float speed;
        public float cost;
        private void Awake()
        {
            damage = motorBoatData.damage;
            speed = motorBoatData.movmentSpeed;
            health = motorBoatData.health;
            fireRate = motorBoatData.fireRate;
            sightRange = motorBoatData.sightRange;
            costWithOil = motorBoatData.costWithOil;
            upgradeCost = motorBoatData.upgradeCardsNeed;
            cost = motorBoatData.costWithOil;

        }
    }   
}

