using System;
using AMVCC.Models;
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
                    if (hit.collider != null && hit.collider.gameObject.layer != LayerMask.NameToLayer("UI"))
                    {
                        if (FindObjectOfType<SpawnController>().prefab != null)
                        { 
                            Application.model.spawnModel.prefab = FindObjectOfType<SpawnController>().prefab;
                        }
                        if (Application.model.spawnModel.prefab.name == "Sea Mine" || Application.model.spawnModel.prefab.name == "Electronic Tower" || Application.model.spawnModel.prefab.name == "Magnetic Tower" || Application.model.spawnModel.prefab.name == "Radioactive Tower" || Application.model.spawnModel.prefab.name == "Artillery" || Application.model.spawnModel.prefab.name == "Anti Air Craft" || Application.model.spawnModel.prefab.name == "Trench")
                        {
                            if (hit.collider.gameObject.name == "Platform" && !hit.collider.gameObject.GetComponent<SeaWarPlatformView>().platformIsFull
                                                                           && !SeaWarUIView.Instance.isRoadsEnabled)
                            {
//                            Debug.Log("platform");
                                FindObjectOfType<SpawnController>().FindProperSpawnPositionTowers(hit.collider);
                                hit.collider.gameObject.GetComponent<SeaWarPlatformView>().platformIsFull = true;
                            }
                        }
                        else if (SeaWarUIView.Instance.isRoadsEnabled && (hit.collider.gameObject.name == "Refinery"
                                                                          || hit.collider.gameObject.name == "Road"))
                        {
                            FindObjectOfType<SpawnController>().FindProperSpawnPosition(hit.collider);
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
                    if (hit.collider != null && hit.collider.gameObject.layer != LayerMask.NameToLayer("UI"))
                    {
                        if (FindObjectOfType<SpawnController>().prefab != null)
                        { 
                            Application.model.spawnModel.prefab = FindObjectOfType<SpawnController>().prefab;
                        }
                        if (Application.model.spawnModel.prefab.name == "Sea Mine" || Application.model.spawnModel.prefab.name == "Electronic Tower" || Application.model.spawnModel.prefab.name == "Magnetic Tower" || Application.model.spawnModel.prefab.name == "Radioactive Tower" || Application.model.spawnModel.prefab.name == "Artillery" || Application.model.spawnModel.prefab.name == "Anti Air Craft" || Application.model.spawnModel.prefab.name == "Trench")
                        {
                            if (hit.collider.gameObject.name == "Platform" && !hit.collider.gameObject.GetComponent<SeaWarPlatformView>().platformIsFull
                                                                               && !SeaWarUIView.Instance.isRoadsEnabled)
                            {
//                            Debug.Log("platform");
                                FindObjectOfType<SpawnController>().FindProperSpawnPositionTowers(hit.collider);
                                hit.collider.gameObject.GetComponent<SeaWarPlatformView>().platformIsFull = true;
                            }
                        }
                        else if (SeaWarUIView.Instance.isRoadsEnabled && (hit.collider.gameObject.name == "Refinery"
                            || hit.collider.gameObject.name == "Road"))
                        {
                            FindObjectOfType<SpawnController>().FindProperSpawnPosition(hit.collider);
                        } 
                       
                    }
                }
            }
#endif
      
        } 
    }
}