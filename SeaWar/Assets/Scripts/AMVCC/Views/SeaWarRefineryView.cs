using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarRefineryView : SeaWarElement
    {
        public float health;
        public float storedOil;
        public float productionRate;

        private void Awake()
        {
           

        }

        private void Start()
        {
            health = Application.model.refineryModel.health;
            productionRate = Application.model.refineryModel.productionRate;
            storedOil = Application.model.refineryModel.storedOil;
            Debug.Log("refineryview "+health);
           
          }   
        
    }
}