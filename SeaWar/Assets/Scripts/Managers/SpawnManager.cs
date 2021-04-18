using System;
using System.Collections;
using System.Collections.Generic;
using AMVCC;
using AMVCC.Views;
using UnityEngine;
using UnityEngine.UI;
public class SpawnManager : SeaWarElement
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

    public Transform[] spawnPoint;
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
                //Spawner();

            }
        }
        else if (newUnit.costWithGold > 0)
        {
            if (SeaWarUIView.Instance.totalGoldAmount >= costWithGold)
            {
                SeaWarUIView.Instance.totalGoldAmount -= costWithGold;
                SeaWarUIView.Instance.SetNewGoldAmountText();
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
    public void Spawner()
    {
        Instantiate(prefab, spawnPoint[0].position, spawnPoint[0].rotation);
        
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
