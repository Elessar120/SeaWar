using System;
using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarPlatformView : SeaWarElement
    {
        public bool platformIsFull;
        public bool hasTrench;
        //public static Action OnTrenchDestroyedAction;
        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Trench")
            {
                hasTrench = true;
                //OnTrenchDestroyedAction += SetHasTrenchToFalse;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.name == "Trench")
            {
                hasTrench = false;
            }
        }

        /*private void SetHasTrenchToFalse()
        {
            hasTrench = false;
        }*/
    }
}