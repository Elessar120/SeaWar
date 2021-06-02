using System;
using UnityEngine;
using System.Collections.Generic;
namespace AMVCC.Views
{
    public class SeaWarRadioActiveTowerView : SeaWarElement
    {
        public float health;
        public List<GameObject> attackTargets;
        private void Awake()
        {
            health = Application.model.radioActiveTowerModel.health;
            attackTargets = new List<GameObject>();
        }
    }
}