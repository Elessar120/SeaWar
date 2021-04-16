using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "New Unit" , menuName = "Units")]
public class Unit : ScriptableObject
{
 public string unitName;
 public GameObject prefab;
 public int level;
 public float movmentSpeed;
 public float damage;
 public float health;
 public float fireRate;
 public float sightRange;
 public float rotationSpeed;
 public float costWithGold;
 public float costWithOil;
 public float upgradeCardsNeed;
 public float upgradeGoldsNeed;
 public float supportDamageRate;
 public float productionRate;
 public float earnedMoney;
 public GameObject spawnButton;
 public enum MovmentType
 {
     UnderWater, Air, WaterSurface
 }

 public string[] AttackTargets;
 
}  
