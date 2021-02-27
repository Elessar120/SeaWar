using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnManager : MonoBehaviour
{
    #region unit Properties

    
    private string unitName;
    private GameObject model;
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

    public Transform[] spawnPoint;
    private Button[] gamePlayButtons;
    private void Start()
    {
        gamePlayButtons = UIManager.Instance.gamePlayButtons;
        UIManager.Instance.onCheckButtonIsInteractableAction += SetButtonInteractableState;
    }

    public void SetProperties(Unit newUnit)
    {
        /*unitName = newUnit.unitName;
        level = newUnit.level;
        movmentSpeed = newUnit.movmentSpeed;
        damage = newUnit.damage;
        health = newUnit.health;
        fireRate = newUnit.fireRate;
        sightRange = newUnit.sightRange;
        rotationSpeed = newUnit.rotationSpeed;
        upgradeCardsNeed = newUnit.upgradeCardsNeed;
        upgradeGoldsNeed = newUnit.upgradeGoldsNeed;*/
        costWithGold = newUnit.costWithGold;
        costWithOil = newUnit.costWithOil;
        
        model = newUnit.model;
        if (newUnit.costWithOil > 0)    
        {
            if (UIManager.Instance.totalOilAmount >= costWithOil)
            {
                UIManager.Instance.totalOilAmount -= costWithOil;
                UIManager.Instance.SetNewOilAmountText();
                Spawner();

            }
        }
        else if (newUnit.costWithGold > 0)
        {
            if (UIManager.Instance.totalGoldAmount >= costWithGold)
            {
                UIManager.Instance.totalGoldAmount -= costWithGold;
                UIManager.Instance.SetNewGoldAmountText();
                Spawner();
            }
            else
            {
                //UIManager   
            }
        }
        UIManager.Instance.onCheckButtonIsInteractableAction();

        //UIManager.Instance.totalOilAmount -= newUnit.costWithMoney;
    }
    public void Spawner()
    {
        Instantiate(model, spawnPoint[0].position, spawnPoint[0].rotation);
        
    }

    private void SetButtonInteractableState()
    {
        foreach (Button button in gamePlayButtons)
        {
                if (UIManager.Instance.totalOilAmount >= costWithOil)
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
                if (UIManager.Instance.totalGoldAmount >= costWithGold)
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
