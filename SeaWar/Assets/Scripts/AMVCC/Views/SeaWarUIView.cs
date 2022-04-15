using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AMVCC;
using AMVCC.Models;
using AMVCC.Views;
using AMVCC.Controllers;

namespace AMVCC.Views
{
    public class SeaWarUIView : SeaWarElement
    {
       
       #region Singletone

   

   private static SeaWarUIView instance;

   public static SeaWarUIView Instance
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

   public bool isRoadsEnabled;
   public Button[] gamePlayButtons;
   public Button oilTankerButton;
   public Button submarineButton; 
   public float totalOilAmount; 
   public float totalGoldAmount;
   public Text oilAmountText;
   public Text goldAmountText;
   public Action onCheckButtonIsInteractableAction;
   public Action onExitMapAction;

   private void Awake()
   {
      oilTankerButton.interactable = false;
      //submarineButton.interactable = false;
      instance = this;
   }

   private void Start()
   {
      totalGoldAmount = 20000;

      Application.model.refineryModel.onOilProductionAction += SetNewOilAmount;
      Application.model.refineryModel.onOilProductionAction += SetNewOilAmountText;
      onExitMapAction += SetNewGoldAmount;
      onExitMapAction += SetNewGoldAmountText;
      goldAmountText.text = "" + totalGoldAmount;
   }

   private void Update()
   {
   }

   public void SetNewOilAmount()
   {
      totalOilAmount += Application.model.refineryModel.productionRate;
      //SetNewOilAmountText();
   }
   public void SetNewOilAmountText()
   {
      oilAmountText.text = "" + totalOilAmount;
   }
   
   public void SetNewGoldAmount()
   {
      totalGoldAmount += Application.model.oilTankerModel.oilTankerData.earnedMoney;
      onCheckButtonIsInteractableAction();
      //SetNewGoldAmountText();
   }

   public void SetNewGoldAmountText()
   {
      goldAmountText.text = "" + totalGoldAmount;

   }

   public void EnableRoads()
   {
      if (Application.model.uiModel.arrowForBlue1 != null)
      {
         Application.model.uiModel.arrowForBlue1.gameObject.SetActive(true);

      }

      if (Application.model.uiModel.arrowForBlue2 != null)
      {
         Application.model.uiModel.arrowForBlue2.gameObject.SetActive(true);

      }

      if (Application.model.uiModel.arrowForBlue3 != null)
      {
         Application.model.uiModel.arrowForBlue3.gameObject.SetActive(true);

      }

      if (Application.model.uiModel.arrowForRed1 != null)
      {
         Application.model.uiModel.arrowForRed1.gameObject.SetActive(true);

      }

      if (Application.model.uiModel.arrowForRed2 != null)
      {
         Application.model.uiModel.arrowForRed2.gameObject.SetActive(true);

      }

      if (Application.model.uiModel.arrowForRed3 != null)
      {
         Application.model.uiModel.arrowForRed3.gameObject.SetActive(true);

      }
      SetIsRoadsEnabledToTrue();

   }

   public void DisableRoads()
   {
      if (Application.model.uiModel.arrowForBlue1 != null)
      {
         Application.model.uiModel.arrowForBlue1.gameObject.SetActive(false);

      }

      if (Application.model.uiModel.arrowForBlue2 != null)
      {
         Application.model.uiModel.arrowForBlue2.gameObject.SetActive(false);

      }

      if (Application.model.uiModel.arrowForBlue3 != null)
      {
         Application.model.uiModel.arrowForBlue3.gameObject.SetActive(false);

      }

      if (Application.model.uiModel.arrowForRed1 != null)
      {
         Application.model.uiModel.arrowForRed1.gameObject.SetActive(false);

      }

      if (Application.model.uiModel.arrowForRed2 != null)
      {
         Application.model.uiModel.arrowForRed2.gameObject.SetActive(false);

      }

      if (Application.model.uiModel.arrowForRed3 != null)
      {
         Application.model.uiModel.arrowForRed3.gameObject.SetActive(false);

      }
      SetIsRoadsEnabledToFalse();

   }

   private void SetIsRoadsEnabledToTrue()
   {
      isRoadsEnabled = true;

   }

   private void SetIsRoadsEnabledToFalse()
   {
      isRoadsEnabled = false;

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

    }
