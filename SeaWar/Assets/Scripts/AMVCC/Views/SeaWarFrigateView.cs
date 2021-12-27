using System;
using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarFrigateView : SeaWarElement
    {
        private float health;
        public float damage;
        public float speed;
        public bool isStopTime;
        public float fireRate;
        private void Awake()
        {
            health = Application.model.seaWarFrigateModel.health;
            damage = Application.model.seaWarFrigateModel.damage;
            speed = Application.model.seaWarFrigateModel.speed;
            fireRate = Application.model.seaWarFrigateModel.fireRate;
        }
    }
}