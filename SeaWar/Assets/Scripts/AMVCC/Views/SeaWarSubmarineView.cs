using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarSubmarineView : SeaWarElement
    {
        public Vector3 startPosition;

        public Animator submarineRotationAnimator;
        public bool wasInMiddleFirstTime;
        public bool submarineIsGoingToMiddleMap;
        public bool isCrossMiddleMap;
        public bool isChasing;
        public Collider enemyCollider;
        public float health;
        public bool isAttackTime;
        public float fireRate;
        public GameObject rayCastingPoint;
        private void Awake()
        {

            submarineRotationAnimator = gameObject.GetComponent<Animator>();
            wasInMiddleFirstTime = false;
            submarineIsGoingToMiddleMap = true;
            fireRate = Application.model.submarineModel.submarineData.fireRate;
            health = Application.model.submarineModel.submarineData.health;
        }
    
        private void Start()
        {
           
            startPosition = gameObject.transform.position;
            if (transform.position.x > 0)
            {
                gameObject.layer = LayerMask.NameToLayer("RedSubmarine");    
            }
            else if (transform.position.x < 0)
            {
                gameObject.layer = LayerMask.NameToLayer("BlueSubmarine");    

            }
            
        }
        private void Update()
        {
        }

        
    }
}