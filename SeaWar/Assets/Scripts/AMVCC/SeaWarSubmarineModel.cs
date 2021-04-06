using System;
using UnityEngine;

namespace AMVCC
{
    public class SeaWarSubmarineModel : SeaWarElement
    {
        #region navigationSystemData

        public bool wasInMiddleFirstTime;
        public bool submarineIsGoingToMiddleMap;
        public Animator submarineRotationAnimator;
        public GameObject middleMap;
        public Vector3 startPosition;
        [SerializeField] private float smooth = .1f;
        public float rotationAngle;
        private Quaternion target;
        [SerializeField] private float speed = .1f;
        #endregion
        

        #region fightSystemData

        public float damage;
        public float health;
        public float fireRate;
        public bool hunting;
        private Transform enemyTransform;
        public int shootableMask;

        #endregion
       
        
        public Unit submarineData;

        private void Awake()
        {
            //rotationAnimator = GetComponent<Animator>();
           // middleMap = GameManager.Instance.middleMap;
            startPosition = transform.position;
            rotationAngle = 180;
            
            hunting = false;

        }

        private void Start()
        {
            #region setUnitData
            damage = submarineData.damage;
            health = submarineData.health;
            fireRate = submarineData.fireRate;
            
            /*unitName = submarineData.unitName;
             model = submarineData.model;
             level = submarineData.level;
             movmentSpeed = submarineData.movmentSpeed;
             sightRange = submarineData.sightRange;
             rotationSpeed = submarineData.rotationSpeed;
             costWithMoney = submarineData.costWithGold;
             costWithOil = submarineData.costWithOil;
             upgradeCardsNeed = submarineData.upgradeCardsNeed;
             upgradeGoldsNeed = submarineData.upgradeGoldsNeed;
             supportDamageRate = submarineData.supportDamageRate;
             productionRate = submarineData.productionRate;
             earnedMoney = submarineData.earnedMoney;*/

            #endregion

            startPosition = gameObject.transform.position;
            wasInMiddleFirstTime = false;
            submarineIsGoingToMiddleMap = true;
            shootableMask = LayerMask.GetMask (submarineData.AttackTargets);
        }
    }
}