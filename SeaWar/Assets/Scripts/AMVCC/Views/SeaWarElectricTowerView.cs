using System;
using System.Collections.Generic;
using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarElectricTowerView : SeaWarElement
    {
        public List<Collider> effectedTowers;

        private void Start()
        {
            effectedTowers = new List<Collider>();
        }
    }
}