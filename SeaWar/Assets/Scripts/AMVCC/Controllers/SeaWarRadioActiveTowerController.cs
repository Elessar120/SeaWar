using System;
using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarRadioActiveTowerController : SeaWarElement

    {
        private SeaWarPlatformView platformView;

        private void Awake()
        {
            //platformView = new SeaWarPlatformView();
        }

        private void Start()
        {

        }

        private void OnTriggerEnter(Collider other)
        {

        }

        private void OnTriggerStay(Collider other)
        {
            
        }

        private void OnTriggerExit(Collider other)
        {
            
        }

        private void OnDestroy()
        {
            platformView.platformIsFull = false;
        }
    }
}