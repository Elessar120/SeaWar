using System;
using UnityEngine;

namespace AMVCC.Models
{
    public class SeaWarTrenchModel : SeaWarElement
    {
        public float health;
        public Unit trenchData;
        private void Awake()
        {
            health = trenchData.health;
        }
    }
}