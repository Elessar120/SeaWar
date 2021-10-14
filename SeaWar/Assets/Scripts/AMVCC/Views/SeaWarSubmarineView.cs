using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarSubmarineView : SeaWarElement
    {
        public Vector3 startPosition;
        public float sightRange;

        public Animator submarineRotationAnimator;
        public bool wasInMiddleFirstTime;
        public bool submarineIsGoingToMiddleMap;
        public bool isCrossMiddleMap;
        public bool middleMapPassed;
        public Collider enemyCollider;
        public float health;
        public bool isAttackTime;
        public float fireRate;
        public GameObject rayCastingPoint;
        public Transform nextDestination;
        public float speed;
        private void Awake()
        {

            //submarineRotationAnimator = gameObject.GetComponent<Animator>();
            wasInMiddleFirstTime = false;
            submarineIsGoingToMiddleMap = true;
            fireRate = Application.model.submarineModel.submarineData.fireRate;
            health = Application.model.submarineModel.submarineData.health;
            speed = Application.model.submarineModel.speed;
        }
    
        private void Start()
        {
            sightRange = Application.model.submarineModel.sightRange;

            startPosition = gameObject.transform.position;
            /*if (transform.position.x > 0)
            {
                gameObject.layer = LayerMask.NameToLayer("RedSubmarine");    
            }
            else if (transform.position.x < 0)
            {
                gameObject.layer = LayerMask.NameToLayer("BlueSubmarine");    

            }*/
            
        }
        private void Update()
        {
        }

        
    }
}