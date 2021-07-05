using System;
using AMVCC.Controllers;
using UnityEngine;

namespace AMVCC.Models
{
    public class SeaWarRefineryModel : SeaWarElement
    {
        public Unit refineryData;
        public Unit oilTankerData;
        public float storedOil;// just for watch each refinery production separately
        public Action onOilProductionAction;
        public float health;
        public float productionRate;

        private void Awake()
        {
            health = refineryData.health;
            productionRate = refineryData.productionRate;
        }

        private void Start()
        {
//            Debug.Log(health);

        }
    }
    
}