using System;
using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarArtilleryView : SeaWarElement
    {
        public float fireRate;
        public float damage;
        public float speed;
        private void Awake()
        {
            fireRate = Application.model.artilleryModel.fireRate;
            damage = Application.model.artilleryModel.damage;
            speed = Application.model.artilleryModel.speed;
        }
    }
}