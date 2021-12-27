using System;
using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarBattleshipView : SeaWarElement
    {
        public float health;
        public float speed;
        public float fireRate;
        public bool isStopTime;
        public float damage;
        private void Awake()
        {
            health = Application.model.battleshipModel.health;
            speed = Application.model.battleshipModel.speed;
            fireRate = Application.model.battleshipModel.fireRate;
            damage = Application.model.battleshipModel.damage;
        }
    }
}