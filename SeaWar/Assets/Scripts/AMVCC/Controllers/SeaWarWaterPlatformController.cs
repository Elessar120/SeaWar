using UnityEngine;
using System;
using AMVCC.Views;

namespace AMVCC.Controllers
{
    public class SeaWarWaterPlatformController : SeaWarElement
    {
        public Action onDestroy;
        private Collider waterPlatform;

        private void Start()
        {
            onDestroy += SetFreePlattform;

        }

        private void OnEnable()
        {
            Collider[] touchedColliders = Physics.OverlapSphere(transform.position, .6f);
            foreach (Collider touchedCollider in touchedColliders)
            {
                Debug.Log("my name is" + touchedCollider.name);

                if (touchedCollider.transform.name == "Water 1" ||touchedCollider.transform.name == "Water 2" || touchedCollider.transform.name == "Water 3")
                {
                    waterPlatform = touchedCollider;
                    waterPlatform.GetComponent<SeaWarWaterPlatformView>().onBuildingTime();
                    break;
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position,.6f);
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }

        private void SetFreePlattform()
        {
            
            Debug.Log("3- platform!!!!!!!!!!!!!");

                
            Debug.Log("4- platform!!!!!!!!!!!!!");

            waterPlatform.GetComponent<SeaWarPlatformView>().onBuildingTime();
                    
                
            
        }
    }
}