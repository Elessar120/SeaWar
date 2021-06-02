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
        private void Awake()
        {
            damage = Application.model.motorBoatModel.motorBoatData.damage;
            speed = Application.model.motorBoatModel.motorBoatData.movmentSpeed;
            fireRate = Application.model.motorBoatModel.motorBoatData.fireRate;
            timer = Application.model.motorBoatModel.motorBoatData.fireRate;
            isAttackTime = true;
        }
    }
}

