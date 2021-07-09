using System;
using UnityEngine;
using System.Collections.Generic;
namespace AMVCC.Views
{
    public class SeaWarRadioActiveTowerView : SeaWarElement
    {
        public float health;
        public float damage;
        public float fireRate;
        //public List<GameObject> attackTargets;
        private void Awake()
        {
            health = Application.model.radioActiveTowerModel.health;
            damage = Application.model.radioActiveTowerModel.damage;
            fireRate = Application.model.radioActiveTowerModel.fireRate;
            //attackTargets = new List<GameObject>();
        }

       
    }
}