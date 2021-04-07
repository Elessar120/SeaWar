using UnityEngine;

namespace AMVCC
{
    public class SeaWarSubmarineController : SeaWarElement
    {
        public void Move()
        {
            Debug.Log(SubmarineFightSystem.hunting);
            // if (!SubmarineFightSystem.hunting)
            //{
            if (!rotationAnimator.GetBool("isInRotateMod"))
            {
                if (isGoingToMiddleMap)
                {
                    transform.position = Vector3.MoveTowards(transform.position,new Vector3(middleMap.transform.position.x,transform.position.y,transform.position.z),Time.deltaTime * speed);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position,startPosition,Time.deltaTime * speed);

                }

            }
            // }
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
            if (other.CompareTag("MiddleMap"))
            {
                SetSubmarineTurnAnimationState();
                SetWasInsMiddleFirstTimeState();
                SetIsGoingToMiddleMapStateToFalse();
            }

            if (other.CompareTag("StartPoint") && wasInMiddleFirstTime)
            {
                SetSubmarineTurnAnimationState();
                SetIsGoingToMiddleMapStateToTrue();

            }
        }

        private void SetIsGoingToMiddleMapStateToTrue()
        {
            isGoingToMiddleMap = true;
        }

        private void SetIsGoingToMiddleMapStateToFalse()
        {
            isGoingToMiddleMap = false;
        }

        private void SetWasInsMiddleFirstTimeState()
        {
            if (!wasInMiddleFirstTime)
            {
                wasInMiddleFirstTime = true;
                        
            }
            
        }
        
    }
}