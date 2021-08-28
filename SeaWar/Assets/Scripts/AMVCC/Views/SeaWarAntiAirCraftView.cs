using System;
using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarAntiAirCraftView : SeaWarElement
    {
        public float fireRate;
        public float damage;
        private void Awake()
        {
            fireRate = Application.model.antiAirCraftModel.fireRate;
            damage = Application.model.antiAirCraftModel.damage;
        }
    }
}