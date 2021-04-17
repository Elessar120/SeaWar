using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarSubmarineMoveView : SeaWarElement
    {
        public Animator submarineRotationAnimator;
        public bool wasInMiddleFirstTime;
        public bool submarineIsGoingToMiddleMap;
        private void Awake()
        {

            submarineRotationAnimator = gameObject.GetComponent<Animator>();
            wasInMiddleFirstTime = false;
            submarineIsGoingToMiddleMap = true;
        }
    
        private void Start()
        {
           
            //Application.model.submarineModel.startPosition =Application.model.submarineModel.gameObject.transform.position;
         
            
        }
        private void Update()
        {
        }

        
    }
}