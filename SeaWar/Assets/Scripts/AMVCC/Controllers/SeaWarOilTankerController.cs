using AMVCC.Views;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
namespace AMVCC.Controllers
{
    public class SeaWarOilTankerController : SeaWarElement
    {
        private List<GameObject> effectiveMagneticTowers;
        public Action <GameObject> onEffectedByMagneticTower;
        [SerializeField] float currentSpeed;
        [SerializeField] private SeaWarOilTankerView oilTankerView;
        [SerializeField] private SeaWarSpeedController speedController;
        private Tween moveToMiddleMapTween;
        private Tween moveToExitPointTween;
        private Tween rotateToExitPointTween;
        private Ease moveEase = Ease.Linear;
        private Quaternion targetRotationAngleBlue;
        private Quaternion targetRotationAngleRed;
        private float rotateDuration;
        private Rigidbody myRigidbody;
        private void Start()
        {
            effectiveMagneticTowers = new List<GameObject>();
            onEffectedByMagneticTower += AddMagneticTowerToList;
            currentSpeed = oilTankerView.speed;
            StartCoroutine(nameof(Move));

            myRigidbody = GetComponent<Rigidbody>();
            rotateDuration = 2f;
        }
        private void AddMagneticTowerToList(GameObject magneticTower)
        {
            if (!effectiveMagneticTowers.Contains(magneticTower))
            {
                effectiveMagneticTowers.Add(magneticTower);

            }
            Debug.Log("lists count = " + effectiveMagneticTowers.Count + " " + magneticTower.name);
        }
        public float CalculateCurrentSpeed()
        {

            currentSpeed = oilTankerView.speed;
            Debug.Log(effectiveMagneticTowers.Count);
            for (int i = 0; i < effectiveMagneticTowers.Count; i++)
            {
                if (!effectiveMagneticTowers[i])
                {
                    effectiveMagneticTowers.RemoveAt(i);

                }
                else
                {
                    currentSpeed *= Application.model.magneticTowerModel.enemyCoenfficientSlowDown;

                }


            }

            return currentSpeed;
        }

        private void Update()
        {
            //Debug.Log("update");

        }

        private void OnEnable()
        {
            targetRotationAngleRed = Quaternion.LookRotation(oilTankerView.redExitPoint.transform.position ,Vector3.up);
            if (gameObject.CompareTag("Blue"))
            {
                gameObject.transform.rotation = Quaternion.LookRotation(transform.right);
            }
            else if (gameObject.CompareTag("Red"))
            {
                gameObject.transform.rotation = Quaternion.LookRotation(transform.right);

            }
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }

        private IEnumerator Move()
        {
            if (gameObject.CompareTag("Blue"))
            {
                moveToMiddleMapTween = gameObject.transform.DOMoveX(oilTankerView.middleMap.transform.position.x,
                        Vector3.Distance(transform.position, oilTankerView.middleMap.transform.position) /
                        CalculateCurrentSpeed())
                    .SetEase(moveEase);
                yield return moveToMiddleMapTween.WaitForCompletion();
                
                targetRotationAngleBlue = Quaternion.LookRotation(transform.right * -1 ,Vector3.up); 
                rotateToExitPointTween = gameObject.transform.DORotate(new Vector3(0,90,0), rotateDuration).SetEase(moveEase);

                yield return rotateToExitPointTween.WaitForCompletion();

                 moveToExitPointTween = gameObject.transform.DOMoveZ(oilTankerView.blueExitPoint.transform.position.z,Vector3.Distance(transform.position, oilTankerView.blueExitPoint.transform.position) /
                        CalculateCurrentSpeed())
                    .SetEase(moveEase).OnComplete(AddOil);
                 yield return moveToExitPointTween.WaitForCompletion();

            }
            else if(gameObject.CompareTag("Red"))
            {
                 moveToMiddleMapTween = gameObject.transform.DOMoveX(oilTankerView.middleMap.transform.position.x,
                        Vector3.Distance(transform.position, oilTankerView.middleMap.transform.position) /
                        CalculateCurrentSpeed())
                    .SetEase(moveEase);
                     yield return moveToMiddleMapTween.WaitForCompletion();

                    rotateToExitPointTween = gameObject.transform.DORotate(new Vector3(0,270,0),rotateDuration).SetEase(moveEase);
                     yield return rotateToExitPointTween.WaitForCompletion();

                    moveToExitPointTween = gameObject.transform.DOMoveZ(oilTankerView.redExitPoint.transform.position.z,Vector3.Distance(transform.position, oilTankerView.redExitPoint.transform.position) /
                        CalculateCurrentSpeed())
                    .SetEase(moveEase).OnComplete(AddOil);
                     yield return moveToExitPointTween.WaitForCompletion();
            }
           
        }

        private void AddOil()
        {
            FindObjectOfType<SeaWarUIView>().onExitMapAction();
            Destroy(gameObject);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, oilTankerView.blueExitPoint.transform.position - transform.position);
        }
    }
}