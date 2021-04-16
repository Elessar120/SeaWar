using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarSubmarineMoveController : SeaWarElement
    {
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
            if (!Application.model.oilTankerModel.oilTankerRotationAnimator.GetBool("isInRotateMod"));
            {
                if (Application.model.submarineModel.submarineIsGoingToMiddleMap)
                {
                    transform.position = Vector3.MoveTowards(transform.position,new Vector3(Application.model.oilTankerModel.middleMap.transform.position.x,transform.position.y,transform.position.z),Time.deltaTime * Application.model.oilTankerModel.oilTankerData.movmentSpeed);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position,Application.model.oilTankerModel.outPoint.position, Time.deltaTime * Application.model.oilTankerModel.oilTankerData.movmentSpeed);
                }

            }
        }
        public void UncheckRotationAnimatorTrigger()
        {
            Application.model.submarineModel.submarineRotationAnimator.SetBool("isInRotateMod", false);
            Debug.Log("event");
        }

        private void SetSubmarineTurnAnimationState()
        {
            Application.model.submarineModel.submarineRotationAnimator.SetBool("isInRotateMod", true);
        }

        public void CheckSubmarineIsInMiddleOrStartPoint(Collider other)
        {
            Debug.Log("collide!");
            if (other.CompareTag("MiddleMap"))
            {
                Debug.Log("isinmiddlemap");
                SetSubmarineTurnAnimationState();
                SetWasInsMiddleFirstTimeState();
                SetIsGoingToMiddleMapStateToFalse();
            }

            if (other.CompareTag("StartPoint") && Application.model.submarineModel.wasInMiddleFirstTime)
            {
                Debug.Log("isinstartpoint");
                SetSubmarineTurnAnimationState();
                SetIsGoingToMiddleMapStateToTrue();

            }
        }

        private void SetIsGoingToMiddleMapStateToTrue()
        {
            Application.model.submarineModel.submarineIsGoingToMiddleMap = true;
        }

        private void SetIsGoingToMiddleMapStateToFalse()
        {
            Application.model.submarineModel.submarineIsGoingToMiddleMap = false;
        }

        private void SetWasInsMiddleFirstTimeState()
        {
            if (!Application.model.submarineModel.wasInMiddleFirstTime)
            {
                Application.model.submarineModel.wasInMiddleFirstTime = true;
                        
            }
            
        }
        
    }
}