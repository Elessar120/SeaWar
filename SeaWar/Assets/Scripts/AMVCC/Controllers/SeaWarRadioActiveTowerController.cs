﻿using System;
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
            Debug.Log("it is working!");

            if (other.gameObject.layer != gameObject.layer)
            {
                Debug.Log("it is working!");
            }
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