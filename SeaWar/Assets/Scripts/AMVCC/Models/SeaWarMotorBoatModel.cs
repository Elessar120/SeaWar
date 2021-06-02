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
        private float health;
        private float fireRate;
        private float sightRange;
        private float costWithOil;
        private int upgradeCost;
        private float damage;
        private float speed;
        private void Awake()
        {
            damage = motorBoatData.damage;
            speed = motorBoatData.movmentSpeed;
            health = motorBoatData.health;
            fireRate = motorBoatData.fireRate;
            sightRange = motorBoatData.sightRange;
            costWithOil = motorBoatData.costWithOil;
            upgradeCost = motorBoatData.upgradeCardsNeed;
            
        }
    }   
}

