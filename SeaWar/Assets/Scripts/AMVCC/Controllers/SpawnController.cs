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
            if (newUnit.costWithOil > 0)    
            {
                if (SeaWarUIView.Instance.totalOilAmount >= costWithOil)
                {
                    SeaWarUIView.Instance.totalOilAmount -= costWithOil;
                    SeaWarUIView.Instance.SetNewOilAmountText();
                    GameObject.FindObjectOfType<SeaWarUIView>().EnableRoads();
                    //Spawner();

                }
            }
            else if (newUnit.costWithGold > 0)
            {
                if (SeaWarUIView.Instance.totalGoldAmount >= costWithGold)
                {
                    SeaWarUIView.Instance.totalGoldAmount -= costWithGold;
                    SeaWarUIView.Instance.SetNewGoldAmountText();
                    GameObject.FindObjectOfType<SeaWarUIView>().EnableRoads();

                    //Spawner();
                }
                else
                {
                    //UIManager   
                }
            }
            SeaWarUIView.Instance.onCheckButtonIsInteractableAction();

            //UIManager.Instance.totalOilAmount -= newUnit.costWithMoney;
        }
        public void FindProperSpawnPosition(Collider hit)
        {
            if (hit.CompareTag("RefineryBlue1") || hit.CompareTag("RoadBlue1"))
            {
                prefab.tag = "Blue";
                /*if (prefab.name == "SubmarineClone")
                {
                    Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,transform.rotation);

                }*/
                Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Application.model.spawnModel.spawnPointsForBlue1.transform.rotation);

            }
            else if (hit.CompareTag("RefineryBlue2") || hit.CompareTag("RoadBlue2"))
            {
                prefab.tag = "Blue";
                /*if (prefab.name == "SubmarineClone")
                {
                    Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Quaternion.identity);

                }*/
                Spawner(Application.model.spawnModel.spawnPointsForBlue2.transform.position,Application.model.spawnModel.spawnPointsForBlue2.transform.rotation);

            }
            else if (hit.CompareTag("RefineryBlue3") || hit.CompareTag("RoadBlue3"))
            {
                prefab.tag = "Blue";
                /*if (prefab.name == "SubmarineClone")
                {
                    Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Quaternion.identity);

                }*/
                Spawner(Application.model.spawnModel.spawnPointsForBlue3.transform.position,Application.model.spawnModel.spawnPointsForBlue3.transform.rotation);
                
            }
            if (hit.CompareTag("RefineryRed1") || hit.CompareTag("RoadRed1"))
            {
                prefab.tag = "Red";
                /*if (prefab.name == "SubmarineClone")
                {
                    Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Quaternion.Euler(0,180,0));

                }*/
                Spawner(Application.model.spawnModel.spawnPointsForRed1.transform.position,Application.model.spawnModel.spawnPointsForRed1.transform.rotation);

            }
            else if (hit.CompareTag("RefineryRed2") || hit.CompareTag("RoadRed2"))
            {
                prefab.tag = "Red";
                /*if (prefab.name == "SubmarineClone")
                {
                    Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Quaternion.Euler(0,180,0));

                }*/
                Spawner(Application.model.spawnModel.spawnPointsForRed2.transform.position,Application.model.spawnModel.spawnPointsForRed2.transform.rotation);

            }
            else if (hit.CompareTag("RefineryRed3") || hit.CompareTag("RoadRed3"))
            {
                prefab.tag = "Red";
                /*if (prefab.name == "SubmarineClone")
                {
                    Spawner(Application.model.spawnModel.spawnPointsForBlue1.transform.position,Quaternion.Euler(0,180,0));

                }*/
                Spawner(Application.model.spawnModel.spawnPointsForRed3.transform.position,Application.model.spawnModel.spawnPointsForRed3.transform.rotation);
                
            }
        }

        public void Spawner(Vector3 spawnPosition, Quaternion spawnRotation)
        {
            if (FindObjectOfType<SeaWarUIView>().isRoadsEnabled)
            {
             
                Instantiate(prefab, spawnPosition,spawnRotation);
                GameObject.FindObjectOfType<SeaWarUIView>().DisableRoads();
            }

        }

        private void SetButtonInteractableState()
        {
            foreach (Button button in gamePlayButtons)
            {
                if (SeaWarUIView.Instance.totalOilAmount >= costWithOil)    
                {
                    button.interactable = true;

                }
                else
                {
                    button.interactable = false;

                } 
            }
        
            foreach (Button button in gamePlayButtons)
            {
                if (SeaWarUIView.Instance.totalGoldAmount >= costWithGold)
                {
                    button.interactable = true;

                }
                else
                {
                    button.interactable = false;

                }
            }

        }
    }
}
