using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class OilTankerMovment : MonoBehaviour,IMovementSystem
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
   private Transform outPoint;
   private GameObject middleMap;

   public Unit oilTankerData;
   private Animator rotationAnimator;
   private bool isGoingToMiddleMap;
   private int layerMask;
   private string animationName;

   public static Action onExitMapAction;
   /*private void SetNewGoldAmountText()
   {
      UIManager.Instance.goldAmountText.text = "Gold: " + UIManager.Instance.totalGoldAmount.ToString();
   }  */
   private void Awake()
   
   {
      rotationAnimator = GetComponent<Animator>();
   }

   private void Start()
   {
      #region setUnitData

      unitName = oilTankerData.unitName;
      model = oilTankerData.prefab;
      level = oilTankerData.level;
      movmentSpeed = oilTankerData.movmentSpeed;
      damage = oilTankerData.damage;
      health = oilTankerData.health;
      fireRate = oilTankerData.fireRate;
      sightRange = oilTankerData.sightRange;
      rotationSpeed = oilTankerData.rotationSpeed;
      costWithMoney = oilTankerData.costWithGold;
      costWithOil = oilTankerData.costWithOil;
      upgradeCardsNeed = oilTankerData.upgradeCardsNeed;
      upgradeGoldsNeed = oilTankerData.upgradeGoldsNeed;
      supportDamageRate = oilTankerData.supportDamageRate;
      productionRate = oilTankerData.productionRate;
      earnedMoney = oilTankerData.earnedMoney;

         #endregion
         layerMask = LayerMask.GetMask ("MiddleMap");
         middleMap = GameManager.Instance.middleMap;
         if (transform.position.x > 0)
         {
            outPoint = GameManager.Instance.rightOutPoint;
            animationName = "rotatingRight";
         }
         else if (transform.position.x < 0)
         {
            outPoint = GameManager.Instance.leftOutPoint;
            animationName = "rotatingLeft";
         }
         isGoingToMiddleMap = true;
         
   }

   public void Move()
   {
      if (!rotationAnimator.GetBool(animationName))
      {
         if (isGoingToMiddleMap)
         {
            transform.position = Vector3.MoveTowards(transform.position,new Vector3(middleMap.transform.position.x,transform.position.y,transform.position.z),Time.deltaTime * movmentSpeed);
         }
         else
         {
            transform.position = Vector3.MoveTowards(transform.position,outPoint.position, Time.deltaTime * movmentSpeed);
         }

      }
   }

  

   private void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.layer == LayerMask.NameToLayer("MiddleMap"))
      {
         rotationAnimator.SetBool(animationName,true);
         isGoingToMiddleMap = false;
      }
      if (other.gameObject.layer == LayerMask.NameToLayer("ExitPoint"))
      {
        // UIManager.Instance.SetNewGoldAmount();
         onExitMapAction();
         Destroy(gameObject);
         
      }

   }
   public void UncheckRotationAnimatorTrigger()
   {
      rotationAnimator.SetBool(animationName,false);
      
   }
   private void Update()
   {
      Move();
   }
}
