using System;
using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarMagneticTowerView : SeaWarElement
    {
        public float health;

        private void Start()
        {
            health = Application.model.submarineModel.health;
        }
    }
}