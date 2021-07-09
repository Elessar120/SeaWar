using System;
using UnityEngine;

namespace AMVCC.Models
{
    public class SeaWarArtilleryModel : SeaWarElement
    {
        public float damage;
        public Unit artilleryData;

        private void Awake()
        {
            damage = artilleryData.damage;
        }
    }
}