using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AMVCC.Views;
using DG.Tweening;
namespace AMVCC.Controllers
{
    public class SeaWarHelicopterRotateController : SeaWarElement
    {
        
        private Tween rotateBack;
        private Tween rotateToTarget;
        public Action<GameObject> newTargetAction;
        public Action nullTargetAction;
        private Vector3 directionVector;
        Quaternion basicRotation;
        Vector3 basicPosition;
        private Queue targets = new Queue();
        public GameObject target;
        private float rotateSpeed;
        private double rotationDegree;
        public bool isRotationCompleted;

        private void Start()
        {
            newTargetAction += SetNewTarget;
            nullTargetAction += SetTargetToNull;
            basicRotation = transform.rotation;
            basicPosition = transform.position;
            rotateSpeed = Application.model.helicopterModel.rotateSpeed;
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
           
        }

        private IEnumerator RotatateToOrginal()
        {
            if (CompareTag("Blue"))
            {
                rotateBack = transform.DORotate(new Vector3(0,90,0), Mathf.Abs((float) rotationDegree / rotateSpeed));

            }
            else if(CompareTag("Red"))
            {
                rotateBack = transform.DORotate(new Vector3(0,-90,0), (float) rotationDegree / rotateSpeed);

            }
            // transform.rotation = Quaternion.RotateTowards(transform.rotation,basicRotation,45 * Time.deltaTime);
           // Debug.Log("basic rotation : " + basicRotation);
            yield return rotateBack.WaitForCompletion();
        }

        
        private void RotationCalculator()
        {
            
            directionVector = target.transform.position - transform.position;
            rotationDegree = Mathf.Atan(directionVector.y / directionVector.x) * Mathf.Rad2Deg;
//            Debug.Log("rotation Degree : " + rotationDegree);
            if (!rotateToTarget.IsActive())
            {
                StartCoroutine(nameof(Rotator));

            }
            
        }

        private IEnumerator Rotator()
        {
            
            isRotationCompleted = false;

                //Quaternion lookRotation = Quaternion.LookRotation(directionVector,Vector3.up);
             //   Debug.Log(rotationDegree);
                float t = Time.time;
                //Tween rotateToTween =
                  //  transform.DORotate(directionVector, ((float)rotationDegree / 45));
                rotateToTarget = transform.DOLookAt(target.transform.position,Mathf.Abs((float)rotationDegree/rotateSpeed));
                yield return rotateToTarget.WaitForCompletion();
               // Debug.Log("rotation time : " + (Time.time - t));
                isRotationCompleted = true;

               
        }
    }
}