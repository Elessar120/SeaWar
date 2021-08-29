using System;
using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarArtilleryView : SeaWarElement
    {
        public float fireRate;

        private void Awake()
        {
            fireRate = Application.model.artilleryModel.fireRate;
        }
    }
}