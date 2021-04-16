using System;
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
            if (Application.view.uiView.totalOilAmount >=Application.model.refineryModel.oilTankerData.costWithOil)
            {
                Application.view.uiView.oilTankerButton.interactable = true;
                  
            }
            else
            {    
                Application.view.uiView.oilTankerButton.interactable = false;
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