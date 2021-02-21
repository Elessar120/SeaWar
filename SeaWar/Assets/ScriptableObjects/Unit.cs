using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "New Unit" , menuName = "Units")]
public class Unit : ScriptableObject
{
 public string unitName;
 public GameObject model;
 public int level;
 public float movmentSpeed;
 public float damage;
 public float health;
 public float fireRate;
 public float sightRange;
 public float rotationSpeed;
 public float costWithMoney;
 public float costWithOil;
 public float upgradeCardsNeed;
 public float upgradeGoldsNeed;
 public float supportDamageRate;
 public float productionRate;
 public float earnedMoney;
 public enum MovmentType
 {
     UnderWater, Air, WaterSurface
 }

 public string[] AttackTargets;
 
}  
