using System;
using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarSubmarineMoveController : SeaWarElement
    {
        private void OnTriggerEnter(Collider other)
        {
            CheckSubmarineIsInMiddleOrStartPoint(other);
        }

        private void Update()
        {
            Move();

        }

        public void Move()
        {
            /*Debug.Log(SubmarineFightSystem.hunting);
            // if (!SubmarineFightSystem.hunting)
            //{
            if (!Application.model.submarineModel.submarineRotationAnimator.GetBool("isInRotateMod"))
            {
                Debug.Log("isInRotateMod");
                if (Application.model.submarineModel.submarineIsGoingToMiddleMap)
                {
                   transform.position = Vector3.MoveTowards(transform.position,new Vector3(Application.model.submarineModel.middleMap.transform.position.x,transform.position.y,transform.position.z)
                        ,Time.deltaTime *Application.model.submarineModel.submarineData.movmentSpeed);
                    Debug.Log("submarineIsGoingToMiddleMap");
                }
                else
                {
                   transform.position = Vector3.MoveTowards(transform.position,Application.model.submarineModel.startPosition,
                        Time.deltaTime * Application.model.submarineModel.submarineData.movmentSpeed);
                    Debug.Log("!submarineIsGoingToMiddleMap");

                }

            }
            // }*/
            if (!gameObject.GetComponent<SeaWarSubmarineMoveView>().submarineRotationAnimator
                .GetBool("isInRotateMod")) 
            {
                Debug.Log(gameObject.GetComponent<SeaWarSubmarineMoveView>().submarineRotationAnimator.GetBool("isInRotateMod"));
                if (gameObject.GetComponent<SeaWarSubmarineMoveView>().submarineIsGoingToMiddleMap)
                {
                    transform.position = Vector3.MoveTowards(transform.position,new Vector3(Application.model.submarineModel.middleMap.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z),Time.deltaTime * Application.model.submarineModel.submarineData.movmentSpeed);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position,Application.model.submarineModel.startPosition.transform.position, Time.deltaTime * Application.model.submarineModel.submarineData.movmentSpeed);
                }

            }
        }
        public void UncheckRotationAnimatorTrigger()
        {
            gameObject.GetComponent<SeaWarSubmarineMoveView>().submarineRotationAnimator.SetBool("isInRotateMod", false);
            Debug.Log("event");
        }

      

        public void CheckSubmarineIsInMiddleOrStartPoint(Collider other)
        {
            Debug.Log("collide!");
            if (other.CompareTag("MiddleMap"))
            {
                Debug.Log("isinmiddlemap");
                SetSubmarineTurnAnimationStateToTrue();
                SetWasInMiddleFirstTimeState();
                SetIsGoingToMiddleMapStateToFalse();
            }

            if (other.CompareTag("StartPoint") && gameObject.GetComponent<SeaWarSubmarineMoveView>().wasInMiddleFirstTime)
            {
                Debug.Log("isinstartpoint");
                SetSubmarineTurnAnimationStateToTrue();
                SetIsGoingToMiddleMapStateToTrue();

            }
        }
        
        private void SetSubmarineTurnAnimationStateToTrue()
        {
            gameObject.GetComponent<SeaWarSubmarineMoveView>().submarineRotationAnimator.SetBool("isInRotateMod", true);
        }
        
        private void SetIsGoingToMiddleMapStateToTrue()
        {
            gameObject.GetComponent<SeaWarSubmarineMoveView>().submarineIsGoingToMiddleMap = true;
        }

        private void SetIsGoingToMiddleMapStateToFalse()
        {
            gameObject.GetComponent<SeaWarSubmarineMoveView>().submarineIsGoingToMiddleMap = false;
        }

        private void SetWasInMiddleFirstTimeState()
        {
            if (!gameObject.GetComponent<SeaWarSubmarineMoveView>().wasInMiddleFirstTime)
            {
                gameObject.GetComponent<SeaWarSubmarineMoveView>().wasInMiddleFirstTime = true;
                        
            }
            
        }
        
    }
}