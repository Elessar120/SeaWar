using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;

public class Refinery : MonoBehaviour
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
    private float costWithMoney;
    private float costWithOil;
    private float upgradeCardsNeed;
    private float upgradeGoldsNeed;
    private float supportDamageRate;
    private float productionRate;
    private float earnedMoney;
    #endregion
    public Unit refineryData;
    public Unit oilTankerData;
    [SerializeField] float storedOil;// just for watch each refinery production separately
    public static Action onOilProductionAction;
    private void Start()
    {
        #region setUnitData

        unitName = refineryData.unitName;
        model = refineryData.model;
        level = refineryData.level;
        movmentSpeed = refineryData.movmentSpeed;
        damage = refineryData.damage;
        health = refineryData.health;
        fireRate = refineryData.fireRate;
        sightRange = refineryData.sightRange;
        rotationSpeed = refineryData.rotationSpeed;
        costWithMoney = refineryData.costWithGold;
        costWithOil = refineryData.costWithOil;
        upgradeCardsNeed = refineryData.upgradeCardsNeed;
        upgradeGoldsNeed = refineryData.upgradeGoldsNeed;
        supportDamageRate = refineryData.supportDamageRate;
        productionRate = refineryData.productionRate;
        earnedMoney = refineryData.earnedMoney;

        #endregion
        InvokeRepeating("AddOilAmount",1f,1f);
    }   
    private void AddOilAmount ()
    {
        storedOil += productionRate;
        onOilProductionAction();
        if (UIManager.Instance.totalOilAmount >= oilTankerData.costWithOil)
        {
            UIManager.Instance.oilTankerButton.interactable = true;
            
        }
        else
        {    
            UIManager.Instance.oilTankerButton.interactable = false;
        }
       
       
    }

    private void TakeDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
        else
        {
            health = 0f;
            Death();

        }
    }

    private void Death()
    {
        
        Destroy(gameObject);
        

    }

    private void Update()
    {
       
    }
}
