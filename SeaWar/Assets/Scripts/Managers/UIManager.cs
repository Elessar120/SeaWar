using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   #region Singletone

   

   private static UIManager instance;

   public static UIManager Instance
   {
      get
      {
         if (instance == null)
         {
            //instance = FindObjectOfType<UIManager>();
            Debug.LogError("UIManager instance is null");
         }

         return instance;
      }
   }


   #endregion
   public Button oilTankerButton;
   [SerializeField] public float totalOilAmount;
   [SerializeField] public float totalGoldAmount;
   public Text oilAmountText;
   public Text goldAmountText;
   private void Awake()
   {
      oilTankerButton.interactable = false;
      if (OilTankerMovment.OnExitOilTanker != null)
      {
         OilTankerMovment.OnExitOilTanker += SetNewGoldAmountText;

      }
      instance = this;
   }

   private void Update()
   {
      SetNewOilAmountText();
   }

   private void SetNewOilAmountText()
   {
      oilAmountText.text = "Oil: " + totalOilAmount.ToString();
   }

   private void SetNewGoldAmountText()
   {
      goldAmountText.text = "Gold: " + totalGoldAmount.ToString();
      OilTankerMovment.OnExitOilTanker -= SetNewGoldAmountText;
   }
  
}
