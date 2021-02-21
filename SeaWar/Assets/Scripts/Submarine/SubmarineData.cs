using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineData : MonoBehaviour
{
    #region Singletone

    private SubmarineData instance;

    public SubmarineData Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("SubmarineData is empty");
            }

            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    #endregion
    
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

    #region Constructor

    public SubmarineData(Unit newUnit)
    {
        unitName = newUnit.unitName;
        model = newUnit.model;
        level = newUnit.level;
        movmentSpeed = newUnit.movmentSpeed;
        damage = newUnit.damage;
        health = newUnit.health;
        fireRate = newUnit.fireRate;
        sightRange = newUnit.sightRange;
        rotationSpeed = newUnit.rotationSpeed;
        costWithMoney = newUnit.costWithMoney;
        costWithOil = newUnit.costWithOil;
        upgradeCardsNeed = newUnit.upgradeCardsNeed;
        upgradeGoldsNeed = newUnit.upgradeGoldsNeed;
    }

    #endregion
    
    
}
