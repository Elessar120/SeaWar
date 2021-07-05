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
                    if (prefab.name != "Radioactive Tower" && prefab.name != "Magnetic Tower" && prefab.name == "Electronic Tower")
                    {
                        FindObjectOfType<SeaWarUIView>().EnableRoads();

                    }
                }
            }
            else if (newUnit.costWithGold > 0)
            {
                if (SeaWarUIView.Instance.totalGoldAmount >= costWithGold)
                {
                    SeaWarUIView.Instance.totalGoldAmount -= costWithGold;
                    SeaWarUIView.Instance.SetNewGoldAmountText();

                    if (prefab.name == "Radioactive Tower" && prefab.name == "Magnetic Tower" && prefab.name == "Electronic Tower")
                    {
                        FindObjectOfType<SeaWarUIView>().EnableRoads();

                    }
                    else if (prefab.name == "Tower")
                    {

                    }
                }
            }
        }

        public void FindProperSpawnPositionTowers(Collider hit)
        {
            Vector3 spawnPosition = hit.transform.position + new Vector3(0,2,0);

            if (hit.gameObject.CompareTag("Blue"))
            {
                prefab.CompareTag("Blue");
                Spawner(spawnPosition,hit.transform.rotation);
//                Debug.Log("tower spawn");
            }
            if (hit.gameObject.CompareTag("Red"))
            {
                prefab.CompareTag("Red");
                Spawner(spawnPosition,hit.transform.rotation);
                Debug.Log("tower spawn");

            }
        }
        public void FindProperSpawnPosition(Collider hit)
        {
            if (prefab.name != ("Radioactive Tower") || prefab.name != "Magnetic Tower" || prefab.name != "Electronic Tower")
            {
                if (hit.name == "RefineryBlue1" || hit.name == "RoadBlue1")
                {
                    //prefab.tag = "Blue";
                    prefab.tag = "Blue";
               
                
                    /*if (prefab.name == "SubmarineClone")
                         {
                            Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,transform.rotation);

                         }*/
                    Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Application.model.spawnModel.spawnPointsForBlue1.transform.rotation);

                }
                
                else if (hit.name == "RefineryBlue2" || hit.name == "RoadBlue2")
                {
                     //prefab.tag = "Blue";
                      prefab.tag = "Blue";

                      /*if (prefab.name == "SubmarineClone")
                      {
                          Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Quaternion.identity);

                      }*/
                      Spawner(Application.model.spawnModel.spawnPointsForBlue2.transform.position,Application.model.spawnModel.spawnPointsForBlue2.transform.rotation);

                }
                else if (hit.CompareTag("RefineryBlue3") || hit.CompareTag("RoadBlue3"))
                {
                    //prefab.tag = "Blue";
                    prefab.tag = "Blue";

                    /*if (prefab.name == "SubmarineClone")
                    {
                          Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Quaternion.identity);

                     }*/
                    Spawner(Application.model.spawnModel.spawnPointsForBlue3.transform.position,Application.model.spawnModel.spawnPointsForBlue3.transform.rotation);
                
                }
                if (hit.name == "RefineryRed1" || hit.name == "RoadRed1")
                {
                    //prefab.tag = "Red";
                    prefab.tag = "Red";

                    /*if (prefab.name == "SubmarineClone")
                    {
                        Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Quaternion.Euler(0,180,0));
    
                    }*/
                    Spawner(Application.model.spawnModel.spawnPointsForRed1.transform.position,Application.model.spawnModel.spawnPointsForRed1.transform.rotation);

                }
                else if (hit.name == "RefineryRed2" || hit.name == "RoadRed2")
                {
                    //prefab.tag = "Red";
                    prefab.tag = "Red";

                    /*if (prefab.name == "SubmarineClone")
                    {
                        Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Quaternion.Euler(0,180,0));
    
                    }*/
                    Spawner(Application.model.spawnModel.spawnPointsForRed2.transform.position,Application.model.spawnModel.spawnPointsForRed2.transform.rotation);

                }
                else if (hit.name == "RefineryRed3" || hit.name == "RoadRed3")
                {
                    //prefab.tag = "Red";
                    prefab.tag = "Red";

                    /*if (prefab.name == "SubmarineClone")
                    {
                        Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Quaternion.Euler(0,180,0));
    
                    }*/
                    Spawner(Application.model.spawnModel.spawnPointsForRed3.transform.position,Application.model.spawnModel.spawnPointsForRed3.transform.rotation);
                
                }
            
                if (hit.gameObject.CompareTag("Blue"))
                {
                    prefab.tag = "Blue";
                    Spawner(hit.transform.position,hit.transform.rotation);
                }
            
                else if (hit.gameObject.CompareTag("Red"))
                {
                    prefab.tag = "Red";
                } 
            }
        }

        private void Spawner(Vector3 spawnPosition, Quaternion spawnRotation)
        {
            if (prefab.name == "Radioactive Tower" && prefab.name == "Magnetic Tower" && prefab.name == "Electronic Tower")
            {
                if (FindObjectOfType<SeaWarUIView>().isRoadsEnabled)
                {
                    Instantiate(prefab, spawnPosition,spawnRotation);
                    FindObjectOfType<SeaWarUIView>().DisableRoads();
                }
            }
            else if (prefab.name == "Radioactive Tower" || prefab.name == "Magnetic Tower" || prefab.name == "Electronic Tower")
            {
                Instantiate(prefab, spawnPosition,spawnRotation);
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
