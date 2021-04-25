using System;
using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarOilTankerView : SeaWarElement
    {
        public Transform outPoint;
        public Animator oilTankerRotationAnimator;
        public bool oilTankerIsGoingToMiddleMap;
        public string animationName;

        private void Awake()
        {
            oilTankerRotationAnimator = GetComponent<Animator>();

        }

        private void Start()
        {
            if (transform.position.x > 0)
            {
                outPoint = Application.model.oilTankerModel.rightOutPoint;
                animationName = "rotatingRight";
                gameObject.layer = LayerMask.NameToLayer("RedOilTanker");    
            }
            else if (transform.position.x < 0)
            {
                outPoint = Application.model.oilTankerModel.leftOutPoint;
                animationName = "rotatingLeft";
                gameObject.layer = LayerMask.NameToLayer("BlueOilTanker");    

            }

                
            oilTankerIsGoingToMiddleMap = true;
        }
    }
}