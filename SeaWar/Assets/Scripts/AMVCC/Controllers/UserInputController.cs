using System;
using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class UserInputController : SeaWarElement
    {
        private SeaWarPlatformView platformView;

        private void Awake()
        {
            
            //platformView = new SeaWarPlatformView();
        }

        private void Update()
        {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                Application.model.userInputModel.clickedPosition = Input.touches[0].position; 
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Refinery")
                        || hit.collider.gameObject.layer == LayerMask.NameToLayer("Road"))
                        {
                            Application.controller.spawnController.FindProperSpawnPosition(hit.collider);
                        }
                        else if (hit.collider.gameObject.CompareTag("Platform") && !platformView.platformIsFull)
                        {
                            Application.controller.spawnController.FindProperSpawnPosition(hit.collider);

                        }
                    }
                }
            }
#if UNITY_EDITOR  
            if (Input.GetMouseButtonDown(0))
            {
                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Application.model.userInputModel.clickedPosition = Input.mousePosition; 
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {

                        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Refinery")
                            || hit.collider.gameObject.layer == LayerMask.NameToLayer("Road"))
                        {
                            FindObjectOfType<SpawnController>().FindProperSpawnPosition(hit.collider);
                        } 
                        if (hit.collider.gameObject.CompareTag("Platform") && !hit.collider.gameObject.GetComponent<SeaWarPlatformView>().platformIsFull)
                        {
                            Debug.Log("platform");
                            FindObjectOfType<SpawnController>().FindProperSpawnPositionTowers(hit.collider);
                            hit.collider.gameObject.GetComponent<SeaWarPlatformView>().platformIsFull = true;
                        }
                    }
                }
            }
#endif
      
        } 
    }
}