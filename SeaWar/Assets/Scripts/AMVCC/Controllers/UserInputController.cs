using System;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class UserInputController : SeaWarElement
    {
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
                            GameObject.FindObjectOfType<SpawnController>().FindProperSpawnPosition(hit.collider);
                        }
                    }
                }
            }
#endif
      
        } 
    }
}