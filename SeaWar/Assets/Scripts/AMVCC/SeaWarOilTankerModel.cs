using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace AMVCC
{
    public class SeaWarOilTankerModel : SeaWarElement
    {
        public Transform outPoint;
        
        [SerializeField] GameObject middleMap;
        public Transform rightOutPoint;
        public Transform leftOutPoint;
        public Unit oilTankerData;
        public Animator oilTankerRotationAnimator;
        public bool oilTankerIsGoingToMiddleMap;
        public int layerMask;
        public string animationName;

        public static Action onExitMapAction;

      

  
    }
    
    
}