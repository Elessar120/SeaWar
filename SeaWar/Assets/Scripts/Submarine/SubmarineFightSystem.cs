using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineFightSystem : MonoBehaviour,IFightSystem
{
    #region unitProperties
    
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

    [SerializeField] private Unit submarineData;
    public static bool hunting;
    private Transform enemyTransform;
    int shootableMask;
    

    private void Awake()
    {
        hunting = false;

    }

    private void Start()
    {
        #region setUnitData

        unitName = submarineData.unitName;
        model = submarineData.model;
        level = submarineData.level;
        movmentSpeed = submarineData.movmentSpeed;
        damage = submarineData.damage;
        health = submarineData.health;
        fireRate = submarineData.fireRate;
        sightRange = submarineData.sightRange;
        rotationSpeed = submarineData.rotationSpeed;
        costWithMoney = submarineData.costWithMoney;
        costWithOil = submarineData.costWithOil;
        upgradeCardsNeed = submarineData.upgradeCardsNeed;
        upgradeGoldsNeed = submarineData.upgradeGoldsNeed;
        supportDamageRate = submarineData.supportDamageRate;
        productionRate = submarineData.productionRate;
        earnedMoney = submarineData.earnedMoney;

            #endregion
            shootableMask = LayerMask.GetMask ( submarineData.AttackTargets);

    }

    public void TakeDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            
        }
        else
        {
            health = 0;
            Destroy(gameObject);
        }
    }

    public void Attack(float damage)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        Debug.Log(hunting);
        if (other.gameObject.layer == shootableMask)
        {
            hunting = true;
//            enemyTransform.position = other.transform.position;
            //var enemyScript = other.GetComponent<SubmarineData>().ta
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hunting = false;
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void Update()
    {
        if (hunting)
        {
            fireRate -= Time.time;
            if (fireRate < 0)
            {
                Attack(damage);
                fireRate = submarineData.fireRate;
            }
        }
        
    }
}
