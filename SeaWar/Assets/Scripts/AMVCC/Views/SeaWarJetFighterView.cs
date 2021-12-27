using System;
using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarJetFighterView : SeaWarElement
    {
        public float speed;
        public float health;
        public float fireRate;
        public float damage;
        private void Awake()
        {
            speed = Application.model.jetFighterModel.jetFighterData.movmentSpeed;
            health = Application.model.jetFighterModel.jetFighterData.health;
            fireRate = Application.model.jetFighterModel.fireRate;
            damage = Application.model.jetFighterModel.damage;
        }
    }
}