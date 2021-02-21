using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private float costWithMoney;
    private float costWithOil;
    private float upgradeCardsNeed;
    private float upgradeGoldsNeed;
    
    #endregion

    public Transform[] spawnPoint;
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
        costWithMoney = newUnit.costWithMoney;
        costWithOil = newUnit.costWithOil;
        upgradeCardsNeed = newUnit.upgradeCardsNeed;
        upgradeGoldsNeed = newUnit.upgradeGoldsNeed;*/
        model = newUnit.model;
        Spawner();
        UIManager.Instance.totalOilAmount -= newUnit.costWithOil;
        //UIManager.Instance.totalOilAmount -= newUnit.costWithMoney;
    }
    public void Spawner()
    {
        Instantiate(model, spawnPoint[0].position, spawnPoint[0].rotation);
        
    }
}
