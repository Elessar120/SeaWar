using System.Collections;
using System;
using System.Collections.Generic;
using AMVCC;
using DG.Tweening;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarAntiAirCraftRotationController : SeaWarElement
    {
        private Tween rotateBack;
        private Tween rotateToTarget;
        public Action<GameObject> newTargetAction;
        public Action nullTargetAction;
        private Vector3 directionVector;
        Quaternion basicRotation;
        [SerializeField] Queue targets = new Queue();
        private GameObject target;
        private float rotateSpeed;
        private double rotationDegree;
        public bool isRotationCompleted;

        private void Start()
        {
            newTargetAction += SetNewTarget;
            nullTargetAction += SetTargetToNull;
            newTargetAction += SetNewTarget;
            basicRotation = transform.rotation;
            rotateSpeed = Application.model.antiAirCraftModel.rotateSpeed;
        }

        private void SetNewTarget(GameObject newTarget)
        {
            if (!target)
            {
                target = newTarget;
                transform.DOKill();
                RotationCalculator();

            }
        }
        private void SetTargetToNull()
        {
            if (target)
            {
                target = null;
                transform.DOKill();

                StartCoroutine(nameof(RotatateToOrginal));

                
            }
        }
        private void Update()
        {
            if (target)
            {
                RotationCalculator();
            }
            else if (!target)
            {
                
            }
        }

        private IEnumerator RotatateToOrginal()
        {
            //Quaternion lookRotation = Quaternion.LookRotation(Vector3.right, Vector3.up);

           // transform.rotation =
               // Quaternion.RotateTowards(transform.rotation, basicRotation, 180 * Time.deltaTime);
            
            //Debug.Log("2-1");
            if (CompareTag("Blue"))
            {
                rotateBack = transform.DORotate(new Vector3(0,90,0), Mathf.Abs((float) rotationDegree / rotateSpeed));

            }
            else if(CompareTag("Red"))
            {
                rotateBack = transform.DORotate(new Vector3(0,-90,0), (float) rotationDegree / rotateSpeed);

            }
            Debug.Log("basic rotation : " + basicRotation);
            yield return rotateBack.WaitForCompletion();

        }

        //todo call action in other script
        /*private void AddQueue(Transform enemy)
        {

            targets.Enqueue(enemy.transform);
           // Debug.Log("3");

            //RotationCalculator();

        }*/

       

        private void RotationCalculator()
        {
            
                directionVector = target.transform.position - transform.position;
                rotationDegree = Mathf.Atan(directionVector.y / directionVector.x) * Mathf.Rad2Deg;
            
            
            //Debug.Log("1-1");

            if (!rotateToTarget.IsActive())
            {
                StartCoroutine(nameof(Rotator));

            }
            
        }

        private IEnumerator Rotator()
        {
            
            isRotationCompleted = false;

            //Quaternion lookRotation = Quaternion.LookRotation(directionVector,Vector3.up);
            Debug.Log(rotationDegree);
            float t = Time.time;
            //Tween rotateToTween =
            //  transform.DORotate(directionVector, ((float)rotationDegree / 45));
            rotateToTarget = transform.DOLookAt(target.transform.position,Mathf.Abs((float)rotationDegree)/rotateSpeed);
            yield return rotateToTarget.WaitForCompletion();
            Debug.Log("rotation time : " + (Time.time - t));
            isRotationCompleted = true;
            /*if (targets.Count == 0)
            {
                transform.rotation = basicRotation;

            }*/
            //else
            //{
            
                //Transform targetTransform = (Transform) targets.Peek();
                //if (transform.position.x - targetTransform.position.x <= 0)
                //{
                    /*transform.rotation =
                        Quaternion.RotateTowards(transform.rotation, lookRotation, (float)(rotationDegree/180));*/
                    //Debug.Log("1-2- rotation degree = " + rotationDegree);
               // }
                /*else if (transform.position.x - targetTransform.position.x > 0)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(transform.forward * -1, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation,lookRotation, 180);
                    Debug.Log("1-3- rotation degree = " + rotationDegree);

                }*/
               
            
                
            
           

            //Debug.Log("rotation degree is : " + rotationDegree);
            //  }


        }
        private void OnDrawGizmos()
        {
            if (target)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(target.transform.position, transform.position);
            }
            
        }
    }
}
