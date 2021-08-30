using AMVCC.Views;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
namespace AMVCC.Controllers
{
    public class SpawnController : SeaWarElement
    {
        #region unit Properties

    
        private string unitName;
        public GameObject prefab;
        private int level;
        private float movmentSpeed;
        private float damage;
        private float health;
        private float fireRate;
        private float sightRange;
        private float rotationSpeed;
        private float costWithGold;
        private float costWithOil;
        private float upgradeCardsNeed;
        private float upgradeGoldsNeed;
        private new string name;
        #endregion

        private enum PlayersColor
        {
            Blue,Red
        }

       
        private Button[] gamePlayButtons;
        private void Start()
        {
            gamePlayButtons = SeaWarUIView.Instance.gamePlayButtons;
            SeaWarUIView.Instance.onCheckButtonIsInteractableAction += SetButtonInteractableState;
        }

        public void SetProperties(Unit newUnit)
        {
            //todo
            #region SetPlayersColor

        

            #endregion
            costWithGold = newUnit.costWithGold;
            costWithOil = newUnit.costWithOil;
            prefab = newUnit.prefab;
            prefab.name = newUnit.unitName;
            
            Debug.Log(newUnit.unitName + prefab.name);
            if (FindObjectOfType<SeaWarUIView>().isRoadsEnabled)
            {
                FindObjectOfType<SeaWarUIView>().DisableRoads();

            }       
            CheckBuildingsCurrencyTypes(newUnit);
            
            
            //SeaWarUIView.Instance.onCheckButtonIsInteractableAction();

            //UIManager.Instance.totalOilAmount -= newUnit.costWithMoney;
        }

        private void CheckBuildingsCurrencyTypes(Unit newUnit) // to do refactor for single functionality
        {
            if (newUnit.costWithOil > 0)
            {
                if (SeaWarUIView.Instance.totalOilAmount >= costWithOil)
                {
                    SeaWarUIView.Instance.totalOilAmount -= costWithOil;
                    SeaWarUIView.Instance.SetNewOilAmountText();
                    if (prefab.name != "Radioactive Tower" && prefab.name != "Magnetic Tower" && prefab.name != "Electric Tower" && prefab.name != "Sea Mine" && prefab.name != "Artillery" && prefab.name != "Trench" && prefab.name !="Anti Air Craft")
                    {
                        FindObjectOfType<SeaWarUIView>().EnableRoads();

                    } 
                    
                    /*if (prefab.name == "Radioactive Tower" || prefab.name == "Magnetic Tower" || prefab.name == "Electric Tower" || prefab.name == "Sea Mine" || prefab.name == "Artillery" || prefab.name == "Trench")
                    {
                        if (FindObjectOfType<SeaWarUIView>().isRoadsEnabled)
                        {
                            FindObjectOfType<SeaWarUIView>().DisableRoads();

                        }

                    }*/
                }
            }
            else if (newUnit.costWithGold > 0)
            {
                if (SeaWarUIView.Instance.totalGoldAmount >= costWithGold)
                {
                    SeaWarUIView.Instance.totalGoldAmount -= costWithGold;
                    SeaWarUIView.Instance.SetNewGoldAmountText();

                    if (prefab.name != "Radioactive Tower" && prefab.name != "Magnetic Tower" && prefab.name != "Electric Tower" && prefab.name != "Sea Mine" && prefab.name != "Artillery" && prefab.name != "Trench" && prefab.name != "Anti Air Craft")
                    {
                        FindObjectOfType<SeaWarUIView>().EnableRoads();
                    } 
                    
                    /*if (prefab.name == "Radioactive Tower" || prefab.name == "Magnetic Tower" || prefab.name == "Electric Tower" || prefab.name == "Sea Mine" || prefab.name == "Artillery" || prefab.name == "Trench")
                    {
                        if (FindObjectOfType<SeaWarUIView>().isRoadsEnabled)
                        {
                            FindObjectOfType<SeaWarUIView>().DisableRoads();

                        }

                    }*/
                }
            }
        }

        public void FindProperSpawnPositionTowers(Collider hit)
        {
//            Debug.Log("before spawn");
            Vector3 spawnPosition = hit.transform.position + new Vector3(0,0,0);

            if (hit.gameObject.CompareTag("Blue"))
            {
                prefab.tag = "Blue";
                if (prefab.transform.parent)
                {
                    prefab.transform.parent.tag = "Blue";
                }
                if (prefab.transform.GetChild(0))
                {
                    prefab.transform.GetChild(0).tag = "Blue";
                }
                Spawner(spawnPosition,hit.transform.rotation,hit);
//                Debug.Log("tower spawn");
            }
            if (hit.gameObject.CompareTag("Red"))
            {
                prefab.tag = "Red";
                if (prefab.transform.parent)
                {
                    prefab.transform.parent.tag = "Red";
                }       
                if (prefab.transform.GetChild(0))
                {
                    prefab.transform.GetChild(0).tag = "Red";
                }
                Spawner(spawnPosition,hit.transform.rotation,hit);
//                Debug.Log("tower spawn");

            }
        }
        public void FindProperSpawnPositionTrench(Collider hit)
        {
//            Debug.Log("before spawn");
            Vector3 spawnPosition = hit.transform.position + new Vector3(0,2,0);

            if (hit.gameObject.CompareTag("Blue"))
            {
                prefab.tag = "Blue";
                Spawner(spawnPosition,hit.transform.rotation,hit);
//                Debug.Log("tower spawn");
            }
            if (hit.gameObject.CompareTag("Red"))
            {
                prefab.tag = "Red";

                Spawner(spawnPosition,hit.transform.rotation,hit);
//                Debug.Log("tower spawn");

            }
        }

        public void SetUnitTagToBlue()
        {
            prefab.tag = "Blue";
            if (prefab.transform.parent)
            {
                prefab.transform.parent.tag = "Blue";
            }
            if (prefab.transform.GetChild(0))
            {
                prefab.transform.GetChild(0).tag = "Blue";
            }
            
        }

        public void SetUnitTagToRed()
        {
            prefab.tag = "Red";
            if (prefab.transform.parent)
            {
                prefab.transform.parent.tag = "Red";
            }

            if (prefab.transform.GetChild(0))
            {
                prefab.transform.GetChild(0).tag = "Red";
            }
            
        }
        /*
        public void FindProperSpawnPosition(Collider hit)
        {
         // todo 
         // refinery 1,2,3
         // road 1,2,3
         //must be backed
                if (hit.CompareTag("Blue"))
                {
                    //prefab.tag = "Blue";
                    prefab.tag = "Blue";
               
                
                    /*if (prefab.name == "SubmarineClone")
                         {
                            Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,transform.rotation);

                         }#1#
                    Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Application.model.spawnModel.spawnPointsForBlue1.transform.rotation);

                }
                
                else if ((hit.name == "Refinery" || hit.name == "Road") && hit.CompareTag("Blue"))
                {
                     //prefab.tag = "Blue";
                      prefab.tag = "Blue";

                      /*if (prefab.name == "SubmarineClone")
                      {
                          Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Quaternion.identity);

                      }#1#
                      Spawner(Application.model.spawnModel.spawnPointsForBlue2.transform.position,Application.model.spawnModel.spawnPointsForBlue2.transform.rotation);

                }
                else if ((hit.name == "Refinery" || hit.name == "Road") && hit.CompareTag("Blue"))
                {
                    //prefab.tag = "Blue";
                    prefab.tag = "Blue";

                    /*if (prefab.name == "SubmarineClone")
                    {
                          Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Quaternion.identity);

                     }#1#
                    Spawner(Application.model.spawnModel.spawnPointsForBlue3.transform.position,Application.model.spawnModel.spawnPointsForBlue3.transform.rotation);
                
                }
                if ((hit.name == "Refinery" || hit.name == "Road") && hit.CompareTag("Red"))
                {
                    //prefab.tag = "Red";
                    prefab.tag = "Red";

                    /*if (prefab.name == "SubmarineClone")
                    {
                        Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Quaternion.Euler(0,180,0));
    
                    }#1#
                    Spawner(Application.model.spawnModel.spawnPointsForRed1.transform.position,Application.model.spawnModel.spawnPointsForRed1.transform.rotation);

                }
                else if ((hit.name == "Refinery" || hit.name == "Road") && hit.CompareTag("Red"))
                {
                    //prefab.tag = "Red";
                    prefab.tag = "Red";

                    /*if (prefab.name == "SubmarineClone")
                    {
                        Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Quaternion.Euler(0,180,0));
    
                    }#1#
                    Spawner(Application.model.spawnModel.spawnPointsForRed2.transform.position,Application.model.spawnModel.spawnPointsForRed2.transform.rotation);

                }
                else if ((hit.name == "Refinery" || hit.name == "Road") && hit.CompareTag("Red"))
                {
                    //prefab.tag = "Red";
                    prefab.tag = "Red";

                    /*if (prefab.name == "SubmarineClone")
                    {
                        Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Quaternion.Euler(0,180,0));
    
                    }#1#
                    Spawner(Application.model.spawnModel.spawnPointsForRed3.transform.position,Application.model.spawnModel.spawnPointsForRed3.transform.rotation);
                
                }
            
                /*if (hit.gameObject.CompareTag("Blue"))
                {
                    prefab.tag = "Blue";
                    Spawner(hit.transform.position,hit.transform.rotation);
                }
            
                else if (hit.gameObject.CompareTag("Red"))
                {
                    prefab.tag = "Red";
                } #1#
            
        }
        */

        public void Spawner(Vector3 spawnPosition, Quaternion spawnRotation, Collider hit)
        {
//            Debug.Log("spawner");
            if (prefab.name != "Radioactive Tower" && prefab.name != "Magnetic Tower" && prefab.name != "Electric Tower" && prefab.name != "Sea Mine" && prefab.name != "Artillery" && prefab.name != "Trench" && prefab.name != "Anti Air Craft")
            {
                if (FindObjectOfType<SeaWarUIView>().isRoadsEnabled)
                {
                     var unit = Instantiate(prefab, spawnPosition,spawnRotation);
                     unit.name = prefab.name;
                    FindObjectOfType<SeaWarUIView>().DisableRoads();
                }
            }
            else if (prefab.name == "Radioactive Tower" || prefab.name == "Magnetic Tower" || prefab.name == "Electronic Tower" || prefab.name != "Sea Mine" || prefab.name != "Artillery" || prefab.name != "Trench" || prefab.name != "Anti Air Craft")
            {
                
                var unit = Instantiate(prefab, spawnPosition,spawnRotation);
                unit.name = prefab.name;
                if (unit.name == "Trench")
                {
                    //Debug.Log("i am trench");
                    unit.transform.SetParent(hit.gameObject.transform);

                }
                //to do make tower spawner buttons intractable false after pushing and true after instantiating

            }
            

        }

        private void SetButtonInteractableState()//to do fix this bug
        {
            /*foreach (Button button in gamePlayButtons)
            {
                if (costWithOil != 0)
                {
                    if (SeaWarUIView.Instance.totalOilAmount >= costWithOil)
                        button.interactable = true;
                    button.interactable = false;
                }

                if (costWithGold != 0)
                {
                    if (SeaWarUIView.Instance.totalGoldAmount >= costWithGold)
                        button.interactable = true;
                    button.interactable = false;
                }
               
            }*/
                
               
            
        
            foreach (Button button in gamePlayButtons)
            {
                
            }

        }
    }
}
