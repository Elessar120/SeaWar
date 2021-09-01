using System;
using AMVCC.Controllers;
using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarBattleshipMissleView : SeaWarElement
    {
        public float health;
        public Collider target;
        private void Start()
        {
            health = Application.model.battleshipModel.missleHealth;
            target = (Collider)GetComponentInParent<SeaWarBattleshipAttackController>().targets.Peek();
        }
    }
}