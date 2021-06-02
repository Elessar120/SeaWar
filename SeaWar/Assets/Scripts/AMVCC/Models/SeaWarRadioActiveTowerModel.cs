using System;
using UnityEngine;
using System.Collections.Generic;
namespace AMVCC.Models
{
    public class SeaWarRadioActiveTowerModel : SeaWarElement
    {
        public Unit radioactiveTowerData;
        public float damage;
        public float health;
        public float sightRange;
            

        private void Awake()
        {
            damage = radioactiveTowerData.damage;
            health = radioactiveTowerData.health;
            sightRange = radioactiveTowerData.sightRange;
        }
    }
}