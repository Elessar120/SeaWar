using System;
using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarSeaMineView : SeaWarElement

    {
        public float damage;

        private void Awake()
        {
            damage = Application.model.seaMineModel.damage;
        }
    }
}