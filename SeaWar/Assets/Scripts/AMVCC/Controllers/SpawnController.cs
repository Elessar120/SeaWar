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
        private GameObject prefab;
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
                    if (!prefab.CompareTag("Tower"))
                    {
                        FindObjectOfType<SeaWarUIView>().EnableRoads();

                    }

                    //Spawner();

                }
            }
            else if (newUnit.costWithGold > 0)
            {
                if (SeaWarUIView.Instance.totalGoldAmount >= costWithGold)
                {
                    SeaWarUIView.Instance.totalGoldAmount -= costWithGold;
                    SeaWarUIView.Instance.SetNewGoldAmountText();

                    if (!prefab.CompareTag("Tower"))
                    {
                        FindObjectOfType<SeaWarUIView>().EnableRoads();

                    }
                    else if (prefab.CompareTag("Tower"))
                    {

                    }
                }
            }
        }

        public void FindProperSpawnPositionTowers(Collider hit)
        {
            Vector3 spawnPosition = hit.transform.position + new Vector3(0,1,0);

            if (hit.gameObject.layer == LayerMask.NameToLayer("Blue"))
            {
                prefab.layer = LayerMask.NameToLayer("Blue");
                Spawner(spawnPosition,hit.transform.rotation);
                Debug.Log("tower spawn");

            }
            if (hit.gameObject.layer == LayerMask.NameToLayer("Red"))
            {
                prefab.layer = LayerMask.NameToLayer("Red");
                Spawner(spawnPosition,hit.transform.rotation);
                Debug.Log("tower spawn");

            }
        }
        public void FindProperSpawnPosition(Collider hit)
        {
            if (!prefab.CompareTag("Tower"))
            {
                      if (hit.CompareTag("RefineryBlue1") || hit.CompareTag("RoadBlue1"))
            {
                //prefab.tag = "Blue";
                prefab.layer = LayerMask.NameToLayer("Blue");
               
                
                /*if (prefab.name == "SubmarineClone")
                {
                    Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,transform.rotation);

                }*/
                Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Application.model.spawnModel.spawnPointsForBlue1.transform.rotation);

            }
            else if (hit.CompareTag("RefineryBlue2") || hit.CompareTag("RoadBlue2"))
            {
                //prefab.tag = "Blue";
                prefab.layer = LayerMask.NameToLayer("Blue");

                /*if (prefab.name == "SubmarineClone")
                {
                    Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Quaternion.identity);

                }*/
                Spawner(Application.model.spawnModel.spawnPointsForBlue2.transform.position,Application.model.spawnModel.spawnPointsForBlue2.transform.rotation);

            }
            else if (hit.CompareTag("RefineryBlue3") || hit.CompareTag("RoadBlue3"))
            {
                //prefab.tag = "Blue";
                prefab.layer = LayerMask.NameToLayer("Blue");

                /*if (prefab.name == "SubmarineClone")
                {
                    Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Quaternion.identity);

                }*/
                Spawner(Application.model.spawnModel.spawnPointsForBlue3.transform.position,Application.model.spawnModel.spawnPointsForBlue3.transform.rotation);
                
            }
            if (hit.CompareTag("RefineryRed1") || hit.CompareTag("RoadRed1"))
            {
                //prefab.tag = "Red";
                prefab.layer = LayerMask.NameToLayer("Red");

                /*if (prefab.name == "SubmarineClone")
                {
                    Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Quaternion.Euler(0,180,0));

                }*/
                Spawner(Application.model.spawnModel.spawnPointsForRed1.transform.position,Application.model.spawnModel.spawnPointsForRed1.transform.rotation);

            }
            else if (hit.CompareTag("RefineryRed2") || hit.CompareTag("RoadRed2"))
            {
                //prefab.tag = "Red";
                prefab.layer = LayerMask.NameToLayer("Red");

                /*if (prefab.name == "SubmarineClone")
                {
                    Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Quaternion.Euler(0,180,0));

                }*/
                Spawner(Application.model.spawnModel.spawnPointsForRed2.transform.position,Application.model.spawnModel.spawnPointsForRed2.transform.rotation);

            }
            else if (hit.CompareTag("RefineryRed3") || hit.CompareTag("RoadRed3"))
            {
                //prefab.tag = "Red";
                prefab.layer = LayerMask.NameToLayer("Red");

                /*if (prefab.name == "SubmarineClone")
                {
                    Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Quaternion.Euler(0,180,0));

                }*/
                Spawner(Application.model.spawnModel.spawnPointsForRed3.transform.position,Application.model.spawnModel.spawnPointsForRed3.transform.rotation);
                
            }
            
            if (hit.gameObject.layer == LayerMask.NameToLayer("Blue"))
            {
                prefab.layer = LayerMask.NameToLayer("Blue");
                Spawner(hit.transform.position,hit.transform.rotation);
            }
            
            else if (hit.gameObject.layer == LayerMask.NameToLayer("Red"))
            {
                prefab.layer = LayerMask.NameToLayer("Red");
            }
            }
      
            
                
            
        }

        public void Spawner(Vector3 spawnPosition, Quaternion spawnRotation)
        {
            if (!prefab.CompareTag("Tower"))
            {
                if (FindObjectOfType<SeaWarUIView>().isRoadsEnabled)
                {
                    Instantiate(prefab, spawnPosition,spawnRotation);
                    FindObjectOfType<SeaWarUIView>().DisableRoads();
                }
            }
            else if (prefab.CompareTag("Tower"))
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
