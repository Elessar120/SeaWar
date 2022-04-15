using System;
using System.Diagnostics;
using AMVCC.Models;
using AMVCC.Views;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace AMVCC.Controllers
{
    public class UserInputController : SeaWarElement
    {
        private SeaWarPlatformView platformView;
        [SerializeField] private UserInputModel userInputModel;
        private void Awake()
        {
            
            //platformView = new SeaWarPlatformView();
        }

        private void Update()
        {
            if ((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                userInputModel.clickedPosition = Input.touches[0].position; 
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    /*if (hit.collider != null && hit.collider.gameObject.layer != LayerMask.NameToLayer("UI"))
                    {
                        if (FindObjectOfType<SpawnController>().prefab != null)
                        {
                            Debug.Log(hit.collider.gameObject.name);

                            //Application.model.spawnModel.prefab = FindObjectOfType<SpawnController>().prefab;

                            if (!FindObjectOfType<SeaWarUIView>().isRoadsEnabled)
                            {
                                if (hit.collider.gameObject.name == "Platform" && !hit.collider.gameObject.GetComponent<SeaWarPlatformView>().platformIsFull
                                                                               && !SeaWarUIView.Instance.isRoadsEnabled)
                                {
                                    Debug.Log("platform");
                                    FindObjectOfType<SpawnController>().FindProperSpawnPositionTowers(hit.collider);
                                    //hit.collider.gameObject.GetComponent<SeaWarPlatformView>().onBuildingTime();
                                }
                                else if (hit.collider.gameObject.name == "Bridge Platform" && FindObjectOfType<SpawnController>().prefab.name != "Trench" && FindObjectOfType<SpawnController>().prefab.name != "Sea Mine" && !hit.collider.gameObject.GetComponent<SeaWarPlatformView>().platformIsFull)
                                {
                                    Debug.Log("Bridge Platform");
                                    FindObjectOfType<SpawnController>().FindProperSpawnPositionTowers(hit.collider);
                                }
                            }
                            else if (SeaWarUIView.Instance.isRoadsEnabled) 
                            {
                                if (hit.collider.name == "Refinery 1" || hit.collider.name == "Road 1")
                                {
                                    if (hit.collider.CompareTag("Blue"))
                                    {
                                        var spawnController = FindObjectOfType<SpawnController>();
                                        spawnController.SetUnitTagToBlue();
                                        spawnController.Spawner(
                                            Application.model.spawnModel.waterSpawnPointsForBlue1.transform.position,
                                            Application.model.spawnModel.waterSpawnPointsForBlue1.transform.rotation,hit.collider);

                                    }

                                    else if (hit.collider.CompareTag("Red"))
                                    {
                                        var spawnController = FindObjectOfType<SpawnController>();
                                        spawnController.SetUnitTagToRed();
                                        spawnController.Spawner(
                                            Application.model.spawnModel.waterSpawnPointsForRed1.transform.position,
                                            Application.model.spawnModel.waterSpawnPointsForRed1.transform.rotation,hit.collider);
                                    }
                                }
                                else if (hit.collider.name == "Refinery 2" || hit.collider.name == "Road 2")
                                {
                                    Debug.Log("2");

                                    if (hit.collider.CompareTag("Blue"))
                                    {
                                        var spawnController = FindObjectOfType<SpawnController>();
                                        spawnController.SetUnitTagToBlue();
                                        spawnController.Spawner(Application.model.spawnModel.waterSpawnPointsForBlue2.transform.position,Application.model.spawnModel.waterSpawnPointsForBlue2.transform.rotation,hit.collider);
                                    }
                                    
                                    else if (hit.collider.CompareTag("Red"))
                                    {
                                        var spawnController = FindObjectOfType<SpawnController>();
                                        spawnController.SetUnitTagToRed();
                                        spawnController.Spawner(Application.model.spawnModel.waterSpawnPointsForRed2.transform.position,Application.model.spawnModel.waterSpawnPointsForRed2.transform.rotation,hit.collider);
                                    
                                    }
                                }
                            
                                else if (hit.collider.name == "Refinery 3" || hit.collider.name == "Road 3")
                                {
                                    Debug.Log("3");
                                    if (hit.collider.CompareTag("Blue"))
                                    {
                                        var spawnController = FindObjectOfType<SpawnController>();
                                        spawnController.SetUnitTagToBlue();
                                        spawnController.Spawner(Application.model.spawnModel.waterSpawnPointsForBlue3.transform.position,Application.model.spawnModel.waterSpawnPointsForBlue3.transform.rotation,hit.collider);
                                    }
                                    
                                    else if (hit.collider.CompareTag("Red")) 
                                    {
                                        var spawnController = FindObjectOfType<SpawnController>();
                                        spawnController.SetUnitTagToRed();
                                        spawnController.Spawner(Application.model.spawnModel.waterSpawnPointsForRed3.transform.position,Application.model.spawnModel.waterSpawnPointsForRed3.transform.rotation,hit.collider);
                                        
                                    } 
                                }
                                

                            } 
                            
                        }
                        /*if (Application.model.spawnModel.prefab.name == "Sea Mine" || Application.model.spawnModel.prefab.name == "Electric Tower" || Application.model.spawnModel.prefab.name == "Magnetic Tower" || Application.model.spawnModel.prefab.name == "Radioactive Tower" || Application.model.spawnModel.prefab.name == "Artillery" || Application.model.spawnModel.prefab.name == "Anti Air Craft" || Application.model.spawnModel.prefab.name == "Trench")
                        {
                         
                        }#1#
                         
                       
                    }*/
                    if (hit.collider != null && hit.collider.gameObject.layer != LayerMask.NameToLayer("UI"))
                    {
                        SpawnController instance = FindObjectOfType<SpawnController>();
                        if (instance.prefab != null)
                        {
                            //Debug.Log(hit.collider.gameObject.name);
                            //Application.model.spawnModel.prefab = FindObjectOfType<SpawnController>().prefab;

                            if (!FindObjectOfType<SeaWarUIView>().isRoadsEnabled)
                            {
                                Debug.Log(hit.collider.name);
                                if (hit.collider.gameObject.name == "Platform" && FindObjectOfType<SpawnController>().prefab.name != "Trench" && FindObjectOfType<SpawnController>().prefab.name != "Sea Mine" && !hit.collider.gameObject.GetComponent<SeaWarPlatformView>().platformIsFull)
                                
                                {
                                    Debug.Log("platform");
                                    instance.FindProperSpawnPositionTowers(hit.collider);
                                    //Debug.Log(hit.collider.gameObject.name);
                                   // hit.collider.gameObject.GetComponent<SeaWarPlatformView>().onBuildingTime();
                                }
                                else if (hit.collider.gameObject.name == "Bridge Platform" && instance.prefab.name != "Trench" && instance.prefab.name != "Sea Mine" && !hit.collider.gameObject.GetComponent<SeaWarPlatformView>().platformIsFull)
                                {
                                    Debug.Log("Bridge Platform : "+ hit.collider.name);
                                    instance.FindProperSpawnPositionTowers(hit.collider);
                                }
                                else if ((hit.collider.gameObject.name == "Radioactive Tower" || hit.collider.gameObject.name == "Magnetic Tower" || hit.collider.gameObject.name == "Electric Tower" || hit.collider.gameObject.name == "Anti Air Craft" || hit.collider.gameObject.name == "Artillery") && instance.prefab.name == "Trench") 
                                {
                                    // spawn trench
                                    Debug.Log(hit.collider.gameObject.name);
                                    if (!hit.transform.Find("Trench"))
                                    {
                                        Debug.Log("trench spawn");
                                        instance.FindProperSpawnPositionTrench(hit.collider.gameObject);

                                    }
                                    else if (hit.transform.Find("Trench"))
                                    {
                                        Debug.Log("You can't Build a Trench on Another Trench!");
                                    }
                                }
                                
                                else if (hit.collider.name == "Water 1" || hit.collider.name == "Water 2" || hit.collider.name == "Water 3")
                                {
                                    //Debug.Log(FindObjectOfType<SpawnController>().prefab.name == "Sea Mine");
                                    //Debug.Log(hit.collider.gameObject.GetComponent<SeaWarWaterPlatformView>().hasMine);
                                        

                                    if (instance.prefab.name == "Sea Mine" && !hit.collider.gameObject.GetComponent<SeaWarWaterPlatformView>().waterPlatformIsFull)
                                    {
                                        Debug.Log(hit.collider.gameObject.name);

                                        instance.FindProperSpawnPositionTowers(hit.collider);
                                        //hit.collider.gameObject.GetComponent<SeaWarWaterPlatformView>().hasMine = true;
                                        
                                    }
                                    
                                }
                            }
                            else if (SeaWarUIView.Instance.isRoadsEnabled) 
                            {
                                if (hit.collider.name == "Refinery 1" || hit.collider.name == "Water 1")
                                {
                                    if (hit.collider.CompareTag("Blue"))
                                    {
                                        if (instance.prefab.name == "Jet Fighter" || instance.prefab.name == "Helicopter")
                                        {
                                            //var spawnController = FindObjectOfType<SpawnController>();
                                            instance.SetUnitTagToBlue();
                                            instance.Spawner(
                                                Application.model.spawnModel.airSpawnPointsForBlue1.transform.position,
                                                 Application.model.spawnModel.airSpawnPointsForBlue1.transform.rotation,hit.collider);
                                        } 
                                        
                                        else
                                        {
                                            if (instance.prefab.name == "Submarine")
                                            {
                                                instance.SetUnitTagToBlue();
                                                instance.Spawner(
                                                    Application.model.spawnModel.submarineSpawnPointsForBlue1.transform.position,
                                                    Application.model.spawnModel.submarineSpawnPointsForBlue1.transform.rotation,hit.collider);
                                            }
                                            else
                                            {
                                                //var spawnController = FindObjectOfType<SpawnController>();
                                                instance.SetUnitTagToBlue();
                                                instance.Spawner(
                                                    Application.model.spawnModel.waterSpawnPointsForBlue1.transform.position,
                                                    Application.model.spawnModel.waterSpawnPointsForBlue1.transform.rotation,hit.collider);
                                            }
                                            
                                        }
                                        

                                    }

                                    else if (hit.collider.CompareTag("Red"))
                                    {
                                        if (instance.prefab.name == "Jet Fighter" || instance.prefab.name == "Helicopter")
                                        {
                                            //var spawnController = FindObjectOfType<SpawnController>();
                                            instance.SetUnitTagToRed();
                                            instance.Spawner(
                                                Application.model.spawnModel.airSpawnPointsForRed1.transform.position,
                                                Application.model.spawnModel.airSpawnPointsForRed1.transform.rotation,hit.collider);
                                        } 
                                        
                                        else
                                        {
                                            if (instance.prefab.name == "Submarine")
                                            {
                                                instance.SetUnitTagToRed();
                                                instance.Spawner(
                                                    Application.model.spawnModel.submarineSpawnPointsForRed1.transform.position,
                                                    Application.model.spawnModel.submarineSpawnPointsForRed1.transform.rotation,hit.collider);
                                            }
                                            else
                                            {
                                                //var spawnController = FindObjectOfType<SpawnController>();
                                                instance.SetUnitTagToRed();
                                                instance.Spawner(
                                                    Application.model.spawnModel.waterSpawnPointsForRed1.transform.position,
                                                    Application.model.spawnModel.waterSpawnPointsForRed1.transform.rotation,hit.collider);
                                            }
                                            
                                        }
                                    }
                                }
                                else if (hit.collider.name == "Refinery 2" || hit.collider.name == "Water 2")
                                {
                                    Debug.Log("2");

                                    if (hit.collider.CompareTag("Blue"))
                                    {
                                        if (instance.prefab.name == "Jet Fighter" || instance.prefab.name == "Helicopter")
                                        {
                                            //var spawnController = FindObjectOfType<SpawnController>();
                                            instance.SetUnitTagToBlue();
                                            instance.Spawner(
                                                Application.model.spawnModel.airSpawnPointsForBlue2.transform.position,
                                                Application.model.spawnModel.airSpawnPointsForBlue2.transform.rotation,hit.collider);
                                        }
                                       
                                        else
                                        {
                                            if (instance.prefab.name == "Submarine")
                                            {
                                                instance.SetUnitTagToBlue();
                                                instance.Spawner(
                                                    Application.model.spawnModel.submarineSpawnPointsForBlue2.transform.position,
                                                    Application.model.spawnModel.submarineSpawnPointsForBlue2.transform.rotation,hit.collider);
                                            }
                                            else
                                            {
                                                //var spawnController = FindObjectOfType<SpawnController>();
                                                instance.SetUnitTagToBlue();
                                                instance.Spawner(
                                                    Application.model.spawnModel.waterSpawnPointsForBlue2.transform.position,
                                                    Application.model.spawnModel.waterSpawnPointsForBlue2.transform.rotation,hit.collider);
                                            }
                                            
                                        }
                                    }
                                    
                                    else if (hit.collider.CompareTag("Red"))
                                    {
                                        if (instance.prefab.name == "Jet Fighter"  || instance.prefab.name == "Helicopter")
                                        {
                                            //var spawnController = FindObjectOfType<SpawnController>();
                                            instance.SetUnitTagToRed();
                                            instance.Spawner(
                                                Application.model.spawnModel.airSpawnPointsForRed2.transform.position,
                                                Application.model.spawnModel.airSpawnPointsForRed2.transform.rotation,hit.collider);
                                        } 
                                        
                                        else
                                        {
                                            if (instance.prefab.name == "Submarine")
                                            {
                                                instance.SetUnitTagToRed();
                                                instance.Spawner(
                                                    Application.model.spawnModel.submarineSpawnPointsForRed2.transform.position,
                                                    Application.model.spawnModel.submarineSpawnPointsForRed2.transform.rotation,hit.collider);
                                            }
                                            else
                                            {
                                                //var spawnController = FindObjectOfType<SpawnController>();
                                                instance.SetUnitTagToRed();
                                                instance.Spawner(
                                                    Application.model.spawnModel.waterSpawnPointsForRed2.transform.position,
                                                    Application.model.spawnModel.waterSpawnPointsForRed2.transform.rotation,hit.collider);
                                            }
                                            
                                        }
                                    
                                    }
                                }
                            
                                else if (hit.collider.name == "Refinery 3" || hit.collider.name == "Water 3")
                                {
                                    Debug.Log("3");
                                    if (hit.collider.CompareTag("Blue"))
                                    {
                                        if (instance.prefab.name == "Jet Fighter"  || instance.prefab.name == "Helicopter")
                                        {
                                            //var spawnController = FindObjectOfType<SpawnController>();
                                            instance.SetUnitTagToBlue();
                                            instance.Spawner(
                                                Application.model.spawnModel.airSpawnPointsForBlue3.transform.position,
                                                Application.model.spawnModel.airSpawnPointsForBlue3.transform.rotation,hit.collider);
                                        } 
                                       
                                        else
                                        {
                                            if (instance.prefab.name == "Submarine")
                                            {
                                                instance.SetUnitTagToBlue();
                                                instance.Spawner(
                                                    Application.model.spawnModel.submarineSpawnPointsForBlue3.transform.position,
                                                    Application.model.spawnModel.submarineSpawnPointsForBlue3.transform.rotation,hit.collider);
                                            }
                                            else
                                            {
                                                //var spawnController = FindObjectOfType<SpawnController>();
                                                instance.SetUnitTagToBlue();
                                                instance.Spawner(
                                                    Application.model.spawnModel.waterSpawnPointsForBlue3.transform.position,
                                                    Application.model.spawnModel.waterSpawnPointsForBlue3.transform.rotation,hit.collider);
                                            }
                                            
                                        }
                                    }
                                    
                                    else if (hit.collider.CompareTag("Red")) 
                                    {
                                        if (instance.prefab.name == "Jet Fighter"  || instance.prefab.name == "Helicopter")
                                        {
                                            //var spawnController = FindObjectOfType<SpawnController>();
                                            instance.SetUnitTagToRed();
                                            instance.Spawner(
                                                Application.model.spawnModel.airSpawnPointsForRed3.transform.position,
                                                Application.model.spawnModel.airSpawnPointsForRed3.transform.rotation,hit.collider);
                                        } 
                                        
                                        else
                                        {
                                            if (instance.prefab.name == "Submarine")
                                            {
                                                instance.SetUnitTagToRed();
                                                instance.Spawner(
                                                    Application.model.spawnModel.submarineSpawnPointsForRed3.transform.position,
                                                    Application.model.spawnModel.submarineSpawnPointsForRed3.transform.rotation,hit.collider);
                                            }
                                            else
                                            {
                                                //var spawnController = FindObjectOfType<SpawnController>();
                                                instance.SetUnitTagToRed();
                                                instance.Spawner(
                                                    Application.model.spawnModel.waterSpawnPointsForRed3.transform.position,
                                                    Application.model.spawnModel.waterSpawnPointsForRed3.transform.rotation,hit.collider);
                                            }
                                            
                                        }
                                        
                                    } 
                                }
                                

                            } 
                            
                        }
                        /*if (Application.model.spawnModel.prefab.name == "Sea Mine" || Application.model.spawnModel.prefab.name == "Electric Tower" || Application.model.spawnModel.prefab.name == "Magnetic Tower" || Application.model.spawnModel.prefab.name == "Radioactive Tower" || Application.model.spawnModel.prefab.name == "Artillery" || Application.model.spawnModel.prefab.name == "Anti Air Craft" || Application.model.spawnModel.prefab.name == "Trench")
                        {
                         
                        }*/
                         
                       
                    }
                }
            }
//#if UNITY_EDITOR  
            if (Input.GetMouseButtonDown(0))
            {
                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                userInputModel.clickedPosition = Input.mousePosition; 
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null && hit.collider.gameObject.layer != LayerMask.NameToLayer("UI"))
                    {
                        SpawnController instance = FindObjectOfType<SpawnController>();

                        if (instance.prefab != null)
                        {
                            //Debug.Log(hit.collider.gameObject.name);
                            //Application.model.spawnModel.prefab = FindObjectOfType<SpawnController>().prefab;

                            if (!FindObjectOfType<SeaWarUIView>().isRoadsEnabled)
                            {
//                                Debug.Log(hit.collider.name);
                                if (hit.collider.gameObject.name == "Platform" && instance.prefab.name != "Trench" && instance.prefab.name != "Sea Mine" && !hit.collider.gameObject.GetComponent<SeaWarPlatformView>().platformIsFull)
                                
                                {
                                    Debug.Log("platform");
                                    instance.FindProperSpawnPositionTowers(hit.collider);
                                    //Debug.Log(hit.collider.gameObject.name);
                                   // hit.collider.gameObject.GetComponent<SeaWarPlatformView>().onBuildingTime();
                                }
                                else if (hit.collider.gameObject.name == "Bridge Platform" && instance.prefab.name != "Trench" && instance.prefab.name != "Sea Mine" && !hit.collider.gameObject.GetComponent<SeaWarPlatformView>().platformIsFull)
                                {
                                    Debug.Log("Bridge Platform : "+ hit.collider.name);
                                    instance.FindProperSpawnPositionTowers(hit.collider);
                                }
                                else if ((hit.collider.gameObject.name == "Radioactive Tower" || hit.collider.gameObject.name == "Magnetic Tower" || hit.collider.gameObject.name == "Electric Tower" || hit.collider.gameObject.name == "Anti Air Craft" || hit.collider.gameObject.name == "Artillery") && instance.prefab.name == "Trench") 
                                {
                                    // spawn trench
                                    Debug.Log(hit.collider.gameObject.name);
                                    if (!hit.transform.Find("Trench"))
                                    {
                                        Debug.Log("trench spawn");
                                        instance.FindProperSpawnPositionTrench(hit.collider.gameObject);

                                    }
                                    else if (hit.transform.Find("Trench"))
                                    {
                                        Debug.Log("You can't Build a Trench on Another Trench!");
                                    }
                                }
                                
                                else if (hit.collider.name == "Water 1" || hit.collider.name == "Water 2" || hit.collider.name == "Water 3")
                                {
                                    //Debug.Log(FindObjectOfType<SpawnController>().prefab.name == "Sea Mine");
                                    //Debug.Log(hit.collider.gameObject.GetComponent<SeaWarWaterPlatformView>().hasMine);
                                        

                                    if (instance.prefab.name == "Sea Mine" && !hit.collider.gameObject.GetComponent<SeaWarWaterPlatformView>().waterPlatformIsFull)
                                    {
                                        Debug.Log(hit.collider.gameObject.name);

                                        instance.FindProperSpawnPositionTowers(hit.collider);
                                        //hit.collider.gameObject.GetComponent<SeaWarWaterPlatformView>().hasMine = true;
                                        
                                    }
                                    
                                }
                            }
                            else if (SeaWarUIView.Instance.isRoadsEnabled) 
                            {
                                if ((hit.collider.name == "Refinery 1" || hit.collider.name == "Water 1") && Application.model.uiModel.arrowForBlue1)
                                {
                                    if (hit.collider.CompareTag("Blue"))
                                    {
                                        if (instance.prefab.name == "Jet Fighter" || instance.prefab.name == "Helicopter")
                                        {
                                            //var spawnController = FindObjectOfType<SpawnController>();
                                            instance.SetUnitTagToBlue();
                                            instance.Spawner(
                                                Application.model.spawnModel.airSpawnPointsForBlue1.transform.position,
                                                 Application.model.spawnModel.airSpawnPointsForBlue1.transform.rotation,hit.collider);
                                        }
                                        else if (instance.prefab.name == "Submarine")
                                        {
                                            instance.SetUnitTagToBlue();
                                            instance.Spawner(
                                                Application.model.spawnModel.submarineSpawnPointsForBlue1.transform.position,
                                                Application.model.spawnModel.submarineSpawnPointsForBlue1.transform.rotation,hit.collider);
                                        }
                                        else
                                        {
                                            //var spawnController = FindObjectOfType<SpawnController>();
                                            instance.SetUnitTagToBlue();
                                            instance.Spawner(
                                                Application.model.spawnModel.waterSpawnPointsForBlue1.transform.position,
                                                Application.model.spawnModel.waterSpawnPointsForBlue1.transform.rotation,hit.collider);
                                        }
                                        

                                    }

                                    else if (hit.collider.CompareTag("Red"))
                                    {
                                        if (instance.prefab.name == "Jet Fighter" || instance.prefab.name == "Helicopter")
                                        {
                                            //var spawnController = FindObjectOfType<SpawnController>();
                                            instance.SetUnitTagToRed();
                                            instance.Spawner(
                                                Application.model.spawnModel.airSpawnPointsForRed1.transform.position,
                                                Application.model.spawnModel.airSpawnPointsForRed1.transform.rotation,hit.collider);
                                        }
                                        else if (instance.prefab.name == "Submarine")
                                        {
                                            instance.SetUnitTagToRed();
                                            instance.Spawner(
                                                Application.model.spawnModel.submarineSpawnPointsForRed1.transform.position,
                                                Application.model.spawnModel.submarineSpawnPointsForRed1.transform.rotation,hit.collider);
                                        }
                                        else
                                        {
                                            //var spawnController = FindObjectOfType<SpawnController>();
                                            instance.SetUnitTagToRed();
                                            instance.Spawner(
                                                Application.model.spawnModel.waterSpawnPointsForRed1.transform.position,
                                                Application.model.spawnModel.waterSpawnPointsForRed1.transform.rotation,hit.collider);
                                        }
                                    }
                                }
                                else if ((hit.collider.name == "Refinery 2" || hit.collider.name == "Water 2") && Application.model.uiModel.arrowForBlue2)
                                {
//                                    Debug.Log("2");

                                    if (hit.collider.CompareTag("Blue"))
                                    {
                                        if (instance.prefab.name == "Jet Fighter" || instance.prefab.name == "Helicopter")
                                        {
                                            //var spawnController = FindObjectOfType<SpawnController>();
                                            instance.SetUnitTagToBlue();
                                            instance.Spawner(
                                                Application.model.spawnModel.airSpawnPointsForBlue2.transform.position,
                                                Application.model.spawnModel.airSpawnPointsForBlue2.transform.rotation,hit.collider);
                                        }
                                        else if (instance.prefab.name == "Submarine")
                                        {
                                            instance.SetUnitTagToBlue();
                                            instance.Spawner(
                                                Application.model.spawnModel.submarineSpawnPointsForBlue2.transform.position,
                                                Application.model.spawnModel.submarineSpawnPointsForBlue2.transform.rotation,hit.collider);
                                        }
                                        else
                                        {
                                            //var spawnController = FindObjectOfType<SpawnController>();
                                            instance.SetUnitTagToBlue();
                                            instance.Spawner(
                                                Application.model.spawnModel.waterSpawnPointsForBlue2.transform.position,
                                                Application.model.spawnModel.waterSpawnPointsForBlue2.transform.rotation,hit.collider);
                                        }
                                    }
                                    
                                    else if (hit.collider.CompareTag("Red"))
                                    {
                                        if (instance.prefab.name == "Jet Fighter"  || instance.prefab.name == "Helicopter")
                                        {
                                            //var spawnController = FindObjectOfType<SpawnController>();
                                            instance.SetUnitTagToRed();
                                            instance.Spawner(
                                                Application.model.spawnModel.airSpawnPointsForRed2.transform.position,
                                                Application.model.spawnModel.airSpawnPointsForRed2.transform.rotation,hit.collider);
                                        }
                                        else if (instance.prefab.name == "Submarine")
                                        {
                                            instance.SetUnitTagToRed();
                                            instance.Spawner(
                                                Application.model.spawnModel.submarineSpawnPointsForRed2.transform.position,
                                                Application.model.spawnModel.submarineSpawnPointsForRed2.transform.rotation,hit.collider);
                                        }
                                        else
                                        {
                                            //var spawnController = FindObjectOfType<SpawnController>();
                                            instance.SetUnitTagToRed();
                                            instance.Spawner(
                                                Application.model.spawnModel.waterSpawnPointsForRed2.transform.position,
                                                Application.model.spawnModel.waterSpawnPointsForRed2.transform.rotation,hit.collider);
                                        }
                                    
                                    }
                                }
                            
                                else if ((hit.collider.name == "Refinery 3" || hit.collider.name == "Water 3") && Application.model.uiModel.arrowForBlue3)
                                {
                                    Debug.Log("3");
                                    if (hit.collider.CompareTag("Blue"))
                                    {
                                        if (instance.prefab.name == "Jet Fighter"  || instance.prefab.name == "Helicopter")
                                        {
                                            //var spawnController = FindObjectOfType<SpawnController>();
                                            instance.SetUnitTagToBlue();
                                            instance.Spawner(
                                                Application.model.spawnModel.airSpawnPointsForBlue3.transform.position,
                                                Application.model.spawnModel.airSpawnPointsForBlue3.transform.rotation,hit.collider);
                                        }
                                        else if (instance.prefab.name == "Submarine")
                                        {
                                            instance.SetUnitTagToBlue();
                                            instance.Spawner(
                                                Application.model.spawnModel.submarineSpawnPointsForBlue3.transform.position,
                                                Application.model.spawnModel.submarineSpawnPointsForBlue3.transform.rotation,hit.collider);
                                        }
                                        else
                                        {
                                           // var spawnController = FindObjectOfType<SpawnController>();
                                           instance.SetUnitTagToBlue();
                                           instance.Spawner(
                                                Application.model.spawnModel.waterSpawnPointsForBlue3.transform.position,
                                                Application.model.spawnModel.waterSpawnPointsForBlue3.transform.rotation,hit.collider);
                                        }
                                    }
                                    
                                    else if (hit.collider.CompareTag("Red")) 
                                    {
                                        if (instance.prefab.name == "Jet Fighter"  || instance.prefab.name == "Helicopter")
                                        {
                                            //var spawnController = FindObjectOfType<SpawnController>();
                                            instance.SetUnitTagToRed();
                                            instance.Spawner(
                                                Application.model.spawnModel.airSpawnPointsForRed3.transform.position,
                                                Application.model.spawnModel.airSpawnPointsForRed3.transform.rotation,hit.collider);
                                        }
                                        else if (instance.prefab.name == "Submarine")
                                        {
                                            instance.SetUnitTagToRed();
                                            instance.Spawner(
                                                Application.model.spawnModel.submarineSpawnPointsForRed3.transform.position,
                                                Application.model.spawnModel.submarineSpawnPointsForRed3.transform.rotation,hit.collider);
                                        }
                                        else
                                        {
                                            //var spawnController = FindObjectOfType<SpawnController>();
                                            instance.SetUnitTagToRed();
                                            instance.Spawner(
                                                Application.model.spawnModel.waterSpawnPointsForRed3.transform.position,
                                                Application.model.spawnModel.waterSpawnPointsForRed3.transform.rotation,hit.collider);
                                        }
                                        
                                    } 
                                }
                                

                            } 
                            
                        }
                        /*if (Application.model.spawnModel.prefab.name == "Sea Mine" || Application.model.spawnModel.prefab.name == "Electric Tower" || Application.model.spawnModel.prefab.name == "Magnetic Tower" || Application.model.spawnModel.prefab.name == "Radioactive Tower" || Application.model.spawnModel.prefab.name == "Artillery" || Application.model.spawnModel.prefab.name == "Anti Air Craft" || Application.model.spawnModel.prefab.name == "Trench")
                        {
                         
                        }*/
                         
                       
                    }
                }       
            }
//#endif
      
        } 
    }
}