using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AMVCC
{
    public class SeaWarApplication : MonoBehaviour
    {
        public SeaWarModel model;
        public SeaWarView view;
        public SeaWarController controller;

        private void Awake()
        {
            #region Set Submarin Model Data
            
            model.submarineModel.submarineRotationAnimator = view.submarineView.gameObject.GetComponent<Animator>();
            model.submarineModel.middleMap = GameManager.Instance.middleMap;
            model.submarineModel.startPosition = view.submarineView.gameObject.transform.position;
            model.submarineModel.rotationAngle = 180;
            
            model.submarineModel.hunting = false;

            #endregion

            #region Set OilTanker Model Data

            model.oilTankerModel.oilTankerRotationAnimator = view.oilTankerView.gameObject.GetComponent<Animator>();


            #endregion
        }

        private void Start()
        {
            #region set Submarine Model Data
            
            model.submarineModel.damage = model.submarineModel.submarineData.damage;
            model.submarineModel.health =model.submarineModel.submarineData.health;
            model.submarineModel.fireRate =model.submarineModel.submarineData.fireRate;
            model.submarineModel.startPosition =model.submarineModel.gameObject.transform.position;
            model.submarineModel.wasInMiddleFirstTime = false;
            model.submarineModel.submarineIsGoingToMiddleMap = true;
            model.submarineModel.shootableMask = LayerMask.GetMask (model.submarineModel.submarineData.AttackTargets);
            #endregion
           
            #region Set OilTanker Model Data

            model.oilTankerModel.layerMask = LayerMask.GetMask ("MiddleMap");
            if (view.oilTankerView.gameObject.transform.position.x > 0)
            {
                model.oilTankerModel.outPoint = model.oilTankerModel.rightOutPoint;
                model.oilTankerModel.animationName = "rotatingRight";
            }
            else if (view.oilTankerView.gameObject.transform.position.x < 0)
            {
                model.oilTankerModel.outPoint = model.oilTankerModel.leftOutPoint;
                model.oilTankerModel.animationName = "rotatingLeft";
            }
            model.oilTankerModel.oilTankerIsGoingToMiddleMap = true;

            #endregion
        }
    }

}
