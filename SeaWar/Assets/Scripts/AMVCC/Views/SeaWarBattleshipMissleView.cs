using System;
using AMVCC.Controllers;
using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarBattleshipMissleView : SeaWarElement
    {
        public float health;
        public GameObject target;
        private void Awake()
        {
            health = Application.model.battleshipModel.missleHealth;

        }

        private void Start()
        {
            //target = GetComponentInParent<SeaWarBattleshipAttackController>().targets.Peek(); 
            gameObject.transform.SetParent(null);
        }
       
    }
}