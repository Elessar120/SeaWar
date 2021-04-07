using UnityEngine;

namespace AMVCC
{
    public class SeaWarRefineryController : SeaWarElement
    {
        private void AddOilAmount ()
        {
            Application.model.refineryModel.storedOil += Application.model.refineryModel.refineryData.productionRate;
            Application.model.refineryModel.onOilProductionAction();
            if (UIManager.Instance.totalOilAmount >=Application.model.refineryModel.oilTankerData.costWithOil)
            {
                UIManager.Instance.oilTankerButton.interactable = true;
                  
            }
            else
            {    
                UIManager.Instance.oilTankerButton.interactable = false;
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