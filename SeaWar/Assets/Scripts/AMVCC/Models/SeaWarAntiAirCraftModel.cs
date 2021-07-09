using System;
using UnityEngine;

namespace AMVCC.Models
{
    public class SeaWarAntiAirCraftModel : SeaWarElement
    {
        public float damage;
        public Unit antiAirCraftData;

        private void Awake()
        {
            damage = antiAirCraftData.damage;
        }
    }
}