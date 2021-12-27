using System;
using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarOilTankerView : SeaWarElement
    {
        
        [HideInInspector] public GameObject middleMap;
        [HideInInspector] public GameObject blueExitPoint;
        [HideInInspector] public GameObject redExitPoint;
        [HideInInspector]public float speed;
        //public Action onEnterMagneticTower;
        //public Action onExitMagneticTower;
        private void Awake()
        {
            middleMap = GameObject.Find("Middle Map");
            blueExitPoint = GameObject.Find("Blue Exit Point");
            redExitPoint = GameObject.Find("Red Exit Point");
        }

        private void Start()
        {
            //onEnterMagneticTower += SetEffectedSpeed;
            //onExitMagneticTower += SetDefaultSpeed;
            speed = Application.model.oilTankerModel.movmentSpeed;
        }

        /*private void SetEffectedSpeed()
        {
            speed *= Application.model.magneticTowerModel.enemyCoenfficientSlowDown;
        }

        private void SetDefaultSpeed()
        {
            speed = Application.model.oilTankerModel.movmentSpeed;
        }*/
        
        
    }
}