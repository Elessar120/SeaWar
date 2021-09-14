using System;
using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarPlatformController : SeaWarElement
    {
        public Action onDestroy;
        private Collider platform;

        private void Start()
        {
            onDestroy += SetFreePlattform;

        }

        private void OnEnable()
        {
            Collider[] touchedColliders = Physics.OverlapSphere(transform.position, 0.25f);
            foreach (Collider touchedCollider in touchedColliders)
            {
//                Debug.Log("my name is" + touchedCollider.name);

                if (touchedCollider.transform.name == "Platform")
                { 
//                    Debug.Log("2- platform!!!!!!!!!!!!!");
                    platform = touchedCollider;
                    platform.GetComponent<SeaWarPlatformView>().onBuildingTime();
                    break;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }

        private void SetFreePlattform()
        {
            
                Debug.Log("3- platform!!!!!!!!!!!!!");

                
                    Debug.Log("4- platform!!!!!!!!!!!!!");

                    platform.GetComponent<SeaWarPlatformView>().onBuildingTime();
                    
                
            
        }
    }
}