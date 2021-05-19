using System;
using System.Collections;
using System.Collections.Generic;
using AMVCC;
using UnityEngine;

namespace AMVCC.Models
{
    public class SeaWarMotorBoatModel : SeaWarElement
    {
        public Unit motorBoatData;
        private float health;
        private float fireRate;
        private float sightRange;
        private float costWithOil;
        private int upgradeCost;
        private void Awake()
        {
            health = motorBoatData.health;
            fireRate = motorBoatData.fireRate;
            sightRange = motorBoatData.sightRange;
            costWithOil = motorBoatData.costWithOil;
            upgradeCost = motorBoatData.upgradeCardsNeed;
        }
    }   
}

