using UnityEngine;

namespace AMVCC.Models
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
       
        
        public Unit submarineData;

        
    }
}