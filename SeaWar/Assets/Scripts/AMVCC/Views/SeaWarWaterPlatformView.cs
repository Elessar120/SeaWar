using System;
using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarWaterPlatformView : SeaWarElement
    {
        //public bool platformIsFull;
        public bool hasMine;
        //public static Action OnTrenchDestroyedAction;
        private void Start()
        {
            
        }
    

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Sea Mine")
            {
                hasMine = true;
                Debug.Log(other.name);
                //OnTrenchDestroyedAction += SetHasTrenchToFalse;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.name == "Sea Mine")
            {
                hasMine = false;
            }
        }

        
    }
}