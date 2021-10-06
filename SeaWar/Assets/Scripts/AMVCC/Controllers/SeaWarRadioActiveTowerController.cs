using System;
using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarRadioActiveTowerController : SeaWarElement

    {

        private void Awake()
        {
        }

        private void Start()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("it is working!");

            if (!other.gameObject.CompareTag(gameObject.tag))
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
            //platformView.platformIsFull = false;
        }
    }
}