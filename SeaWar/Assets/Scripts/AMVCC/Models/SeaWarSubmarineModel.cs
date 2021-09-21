using System;
using UnityEngine;

namespace AMVCC.Models
{
    public class SeaWarSubmarineModel : SeaWarElement
    {
        #region navigationSystemData

       
        public GameObject middleMap;
        [SerializeField] private float smooth = .1f;
        public float rotationAngle;
        private Quaternion target;
        public float speed = .1f;
        #endregion
        

        #region fightSystemData

        public float damage;
        public float health;
        public float fireRate;
        public bool hunting;
        private Transform enemyTransform;
        public int shootableMask;

        #endregion


        public float cost;
        public Unit submarineData;

        private void Awake()
        {
            rotationAngle = submarineData.rotationSpeed;
            speed = submarineData.movmentSpeed;
            cost = submarineData.costWithGold;
        }

        private void Start()
        {
          
            
            Application.model.submarineModel.damage = Application.model.submarineModel.submarineData.damage;
            Application.model.submarineModel.health =Application.model.submarineModel.submarineData.health;
            Application.model.submarineModel.fireRate =Application.model.submarineModel.submarineData.fireRate;
            Application.model.submarineModel.shootableMask = LayerMask.GetMask (Application.model.submarineModel.submarineData.AttackTargets);

        }
    }
}