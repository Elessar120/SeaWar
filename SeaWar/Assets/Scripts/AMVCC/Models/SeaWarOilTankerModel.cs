using System;
using UnityEngine;

namespace AMVCC.Models
{
    public class SeaWarOilTankerModel : SeaWarElement
    {
        public Transform outPoint;
        
        public GameObject middleMap;
        public Transform rightOutPoint;
        public Transform leftOutPoint;
        public float movmentSpeed;

        public Unit oilTankerData;
        public Animator oilTankerRotationAnimator;
        public bool oilTankerIsGoingToMiddleMap;
        public int layerMask;
        public string animationName;

        public Action onExitMapAction;

        private void Awake()
        {
            movmentSpeed = oilTankerData.movmentSpeed;

        }

        private void Start()
        {
            layerMask = LayerMask.GetMask ("MiddleMap");
            if (transform.position.x > 0)
            {
                outPoint = Application.model.oilTankerModel.rightOutPoint;
                animationName = "rotatingRight";
            }
            else if (transform.position.x < 0)
            {
                outPoint = Application.model.oilTankerModel.leftOutPoint;
                animationName = "rotatingLeft";
            }
            oilTankerIsGoingToMiddleMap = true;

        }
      

  
    }
    
    
}