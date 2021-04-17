using System;
using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarRefineryController : SeaWarElement
    {
    
        private void Start()
        {
            
            InvokeRepeating("AddOilAmount",1f,1f);

        }

        private void AddOilAmount ()
        {
            Application.model.refineryModel.onOilProductionAction();
            if (SeaWarUIView.Instance.totalOilAmount >= Application.model.oilTankerModel.oilTankerData.costWithOil)
            {
//                Debug.Log("we have money!");
                SeaWarUIView.Instance.oilTankerButton.interactable = true;
                  
            }
            else
            {    
               // Debug.Log("we don't have money!");

                SeaWarUIView.Instance.oilTankerButton.interactable = false;
            }
             
             
        }
      
        private void TakeDamage(float damage)
        {
            if (Application.model.refineryModel.health > 0)
            {
                Application.model.refineryModel.health -= damage;
            }
            else
            {
                Application.model.refineryModel.health = 0f;
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
}