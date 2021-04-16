using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarOilTankerController : SeaWarElement
    {
        private void Update()
        {
            Debug.Log("update");
            Move();

        }

        private void OnTriggerEnter(Collider other)
        {
            CheckOilTankerIsInMiddleOrExitPoint(other);
        }

        public void Move()
        {
            if (!Application.model.oilTankerModel.oilTankerRotationAnimator
                .GetBool(Application.model.oilTankerModel.animationName))
            {
                if (Application.model.oilTankerModel.oilTankerIsGoingToMiddleMap)
                {
                    Debug.Log("if");
                    transform.position = Vector3.MoveTowards(transform.position,
                        new Vector3(Application.model.oilTankerModel.middleMap.transform.position.x,
                            transform.position.y, transform.position.z),
                        Time.deltaTime * Application.model.oilTankerModel.oilTankerData.movmentSpeed);


                }

                else
                {
                    transform.position = Vector3.MoveTowards(transform.position,
                        Application.model.oilTankerModel.outPoint.position,
                        Time.deltaTime * Application.model.oilTankerModel.oilTankerData.movmentSpeed);
                }

            }
        }

        public void CheckOilTankerIsInMiddleOrExitPoint(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("MiddleMap"))
            {
                SetOilTankerTurnAnimationStateToTrue();
            }

            if (other.gameObject.layer == LayerMask.NameToLayer("ExitPoint"))
            {
                // UIManager.Instance.SetNewGoldAmount();
                SetIsGoingToMiddleMapStateToFalse();
                Application.model.oilTankerModel.onExitMapAction();
                Destroy(gameObject);

            }

        }

        public void SetOilTankerTurnAnimationStateToFalse()
        {
            Application.model.oilTankerModel.oilTankerRotationAnimator.SetBool(
                Application.model.oilTankerModel.animationName, false);
            SetIsGoingToMiddleMapStateToFalse();
        }

        private void SetOilTankerTurnAnimationStateToTrue()
        {
            Application.model.oilTankerModel.oilTankerRotationAnimator.SetBool(
                Application.model.oilTankerModel.animationName, true);

        }

        private void SetIsGoingToMiddleMapStateToFalse()
        {
            Application.model.oilTankerModel.oilTankerIsGoingToMiddleMap = false;

            /*}
            public void UncheckRotationAnimatorTrigger()
            {
                Application.model.oilTankerModel.oilTankerRotationAnimator.SetBool(Application.model.oilTankerModel.animationName, false);
                Debug.Log("event");
            }*/
        }
    }
}