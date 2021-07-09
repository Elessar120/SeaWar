using System;
using UnityEngine;

namespace AMVCC.Models
{
    public class SeaWarSeaMineModel : SeaWarElement
    {
        public float damage;
        public Unit seaMineData;
        private void Awake()
        {
            damage = seaMineData.damage;
        }
    }
}