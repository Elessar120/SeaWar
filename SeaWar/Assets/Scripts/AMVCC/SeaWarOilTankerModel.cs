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

        private void Awake()
        {
            oilTankerRotationAnimator = GetComponent<Animator>();

        }

        private void Start()
        {
            layerMask = LayerMask.GetMask ("MiddleMap");
            if (transform.position.x > 0)
            {
                outPoint = rightOutPoint;
                animationName = "rotatingRight";
            }
            else if (transform.position.x < 0)
            {
                outPoint = leftOutPoint;
                animationName = "rotatingLeft";
            }
            oilTankerIsGoingToMiddleMap = true;
        }
    }
    
    
}