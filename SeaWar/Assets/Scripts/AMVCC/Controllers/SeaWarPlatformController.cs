using System;
using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarPlatformController : SeaWarElement
    {
        public Action onDestroy;
        private Collider[] touchedColliders;
        private void Start()
        {
            onDestroy += SetFreePlattform;
            touchedColliders = Physics.OverlapSphere(transform.position, 0.25f);
            foreach (Collider touchedCollider in touchedColliders)
            {
                Debug.Log("1- platform!!!!!!!!!!!!!");

                if (touchedCollider.transform.name == "Platform")
                { 
                    Debug.Log("2- platform!!!!!!!!!!!!!");

                    touchedCollider.GetComponent<SeaWarPlatformView>().onBuildingTime();
                }
            }
        }

        private void SetFreePlattform()
        {
            touchedColliders = null;
            touchedColliders = Physics.OverlapSphere(transform.position, 0.25f);
            foreach (Collider touchedCollider in touchedColliders)
            {
                Debug.Log("3- platform!!!!!!!!!!!!!");

                if (touchedCollider.transform.name == "Platform")
                { 
                    Debug.Log("4- platform!!!!!!!!!!!!!");

                    touchedCollider.GetComponent<SeaWarPlatformView>().onBuildingTime();
                    
                }
            }
        }
    }
}