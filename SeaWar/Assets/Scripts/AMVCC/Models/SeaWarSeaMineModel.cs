using System;
using UnityEngine;

namespace AMVCC.Models
{
    public class SeaWarSeaMineModel : SeaWarElement
    {
        public float damage;
        public Unit seaMineData;
        public float cost;
        private void Awake()
        {
            damage = seaMineData.damage;
            cost = seaMineData.costWithGold;
        }
    }
}