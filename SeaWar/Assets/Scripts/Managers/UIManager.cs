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

   public Button[] gamePlayButtons;
   public Button oilTankerButton;
   public Button submarineButton;
   [SerializeField] public float totalOilAmount;
   [SerializeField] public float totalGoldAmount;
   public Text oilAmountText;
   public Text goldAmountText;
   public Action onCheckButtonIsInteractableAction;
   private void Awake()
   {
      oilTankerButton.interactable = false;
      submarineButton.interactable = false;
      instance = this;
   }

   private void Start()
   {
      Refinery.onOilProductionAction += SetNewOilAmount;
      Refinery.onOilProductionAction += SetNewOilAmountText;
      OilTankerMovment.onExitMapAction += SetNewGoldAmount;
      OilTankerMovment.onExitMapAction += SetNewGoldAmountText;
      goldAmountText.text = "Gold: " + totalGoldAmount;
   }

   private void Update()
   {
   }

   public void SetNewOilAmount()
   {
      totalOilAmount += GameData.Instance.refinery.productionRate;
      //SetNewOilAmountText();
   }
   public void SetNewOilAmountText()
   {
      oilAmountText.text = "Oil: " + totalOilAmount.ToString();
   }

   public void SetNewGoldAmount()
   {
      totalGoldAmount += GameData.Instance.oilTanker.earnedMoney;
      onCheckButtonIsInteractableAction();
      //SetNewGoldAmountText();
   }

   public void SetNewGoldAmountText()
   {
      goldAmountText.text = "Gold: " + totalGoldAmount.ToString();

   }
   
   /*public void DeleteAction ()
   {
      OilTankerMovment.onoil -= UIManager.Instance.SetNewGoldAmountText;
   }

   public void AddAction()
   {
     
         OilTankerMovment.onExitOilTanker += SetNewGoldAmountText;
      
   }*/

}
