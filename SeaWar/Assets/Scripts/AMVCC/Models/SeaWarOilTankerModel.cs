using System;
using UnityEngine;

namespace AMVCC.Models
{
    public class SeaWarOilTankerModel : SeaWarElement
    {
        
        public GameObject middleMap;
        public Transform rightOutPoint;
        public Transform leftOutPoint;
        public float movmentSpeed;

        public Unit oilTankerData;
        public int layerMask;

        public Action onExitMapAction;

        private void Awake()
        {
            movmentSpeed = oilTankerData.movmentSpeed;

        }

        private void Start()
        {
            layerMask = LayerMask.GetMask ("MiddleMap");
           

        }
      

  
    }
    
    
}