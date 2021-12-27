using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AMVCC;

namespace AMVCC.Views
{
    public class SeaWarMotorBoatView : SeaWarElement
    {
        public float damage;
        public float speed;
        public float fireRate;
        public float timer;
        public bool isAttackTime;
        public bool isStopTime;
        public float health;
        private void Awake()
        {
            damage = Application.model.motorBoatModel.damage;
            speed = Application.model.motorBoatModel.speed;
            fireRate = Application.model.motorBoatModel.fireRate;
            timer = Application.model.motorBoatModel.fireRate;
            health = Application.model.motorBoatModel.health;
            isAttackTime = true;
        }
    }
}

