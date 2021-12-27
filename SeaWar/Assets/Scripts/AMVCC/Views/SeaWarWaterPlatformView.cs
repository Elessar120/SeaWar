using System;
using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarWaterPlatformView : SeaWarElement
    {
        public bool waterPlatformIsFull;

        public Action onBuildingTime;
        //public static Action OnTrenchDestroyedAction;
        private void Start()
        {
            waterPlatformIsFull = false;
            onBuildingTime += ChangePlatformState;
        }


        private void ChangePlatformState()
        {
            waterPlatformIsFull = !waterPlatformIsFull;

        }

      
    }
}