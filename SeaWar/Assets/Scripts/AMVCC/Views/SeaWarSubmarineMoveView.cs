using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarSubmarineMoveView : SeaWarElement
    {
        private void Awake()
        {
        
            Application.model.submarineModel.middleMap = GameManager.Instance.middleMap;
            Application.model.submarineModel.rotationAngle = 180;
            Application.model.submarineModel.speed = Application.model.submarineModel.submarineData.movmentSpeed;

        }
    
        private void Start()
        {
            Application.model.submarineModel.submarineRotationAnimator = gameObject.GetComponent<Animator>();
            Application.model.submarineModel.startPosition = transform.position;

            //Application.model.submarineModel.startPosition =Application.model.submarineModel.gameObject.transform.position;
            Application.model.submarineModel.wasInMiddleFirstTime = false;
            Application.model.submarineModel.submarineIsGoingToMiddleMap = true;
         
            
        }
        private void Update()
        {
           Application.controller.submarineMoveController.Move();
        }

        private void OnTriggerEnter(Collider other)
        {
            Application.controller.submarineMoveController.CheckSubmarineIsInMiddleOrStartPoint(other);
        }
    }
}