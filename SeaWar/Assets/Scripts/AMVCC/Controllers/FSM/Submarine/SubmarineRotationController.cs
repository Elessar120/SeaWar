using System;
using System.Collections;
using System.Collections.Generic;
using AMVCC;
using AMVCC.Views;
using UnityEngine;
using DG.Tweening;
namespace AMVCC.Controllers.FSM.Submarine
{
    
    public class SubmarineRotationController : SeaWarElement
    {
        private List<GameObject> effectiveMagneticTowers;
        public Action <GameObject> onEffectedByMagneticTower;
        [SerializeField] private SeaWarSubmarineView submarineView;
        [SerializeField] float currentSpeed;
        [SerializeField] private SubmarineController submarine;
        public bool isRotating;
        public Action<GameObject> newTargetAction;
        public Action nullTargetAction;
        public Tween rotationTween;
        //private GameObject target;
        // Start is called before the first frame update
        void Start()
        {
            tag = GetComponentInParent<Transform>().tag;
            effectiveMagneticTowers = new List<GameObject>();
            onEffectedByMagneticTower += AddMagneticTowerToList;
            currentSpeed = Application.model.submarineModel.speed;   
            
        }
        private void AddMagneticTowerToList(GameObject magneticTower)
        {
            if (!effectiveMagneticTowers.Contains(magneticTower))
            {
                effectiveMagneticTowers.Add(magneticTower);

            }
            Debug.Log("lists count = " + effectiveMagneticTowers.Count + " " + magneticTower.name);
        }
        public float CalculateCurrentSpeed()
        {

            currentSpeed = submarineView.speed;
            Debug.Log(effectiveMagneticTowers.Count);
            for (int i = 0; i < effectiveMagneticTowers.Count; i++)
            {
                if (!effectiveMagneticTowers[i])
                {
                    effectiveMagneticTowers.RemoveAt(i);

                }
                else
                {
                    currentSpeed *= Application.model.magneticTowerModel.enemyCoenfficientSlowDown;

                }


            }

            return currentSpeed;
        }
        
        void Update()
        {
        
        }

      

       
        
    }

}
