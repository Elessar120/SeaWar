﻿using System;
using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarPlatformView : SeaWarElement
    {
        public bool platformIsFull;

        public Action onBuildingTime;
        //public static Action OnTrenchDestroyedAction;
        private void Start()
        {
            onBuildingTime += ChangePlatformState;
        }


        private void ChangePlatformState()
        {

            platformIsFull = !platformIsFull;
        }
    }
}