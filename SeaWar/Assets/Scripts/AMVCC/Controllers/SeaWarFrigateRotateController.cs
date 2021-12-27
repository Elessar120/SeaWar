using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using AMVCC.Views;
using System.Linq;
using DG.Tweening;
using Debug = UnityEngine.Debug;

namespace AMVCC.Controllers
{
    public class SeaWarFrigateRotateController : SeaWarElement
    {
        //public Action<Collider> reachEnemyAction;
        //public Action deadEnemyAction;
        private Tween rotateBack;
        private Tween rotateToTarget;
        private double rotationDegree;
        public bool isRotationCompleted;
        public Action<GameObject> newTargetAction;
        public Action nullTargetAction;
        private Vector3 directionVector;
        private Vector3 basicForwardVector;
        Quaternion basicRotation;
        private float rotateSpeed;
        private Queue targets = new Queue();
        [SerializeField] GameObject target;
        [SerializeField] private SeaWarFrigateAttackController frigateAttackController;
        private void Start()
        {
           
            newTargetAction += SetNewTarget;
            nullTargetAction += SetTargetToNull;
            basicRotation = transform.rotation;
            basicForwardVector = transform.right * -1;
            rotateSpeed = Application.model.seaWarFrigateModel.rotateSpeed;
        }

        private void SetNewTarget(GameObject newTarget)
        {
            if (!target)
            {
                Debug.Log("frigate test 1");
                target = newTarget;
                transform.DOKill();
                RotationCalculator();

            }
        }

        private void SetTargetToNull()
        {

            if (target)
            {
                Debug.Log("frigate test 3");

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
            // rotateBack = transform.DORotate(basicForwardVector, rotateSpeed * Time.deltaTime);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation,basicRotation,rotateSpeed * Time.deltaTime);
           //yield return rotateBack.WaitForCompletion();
           if (CompareTag("Blue"))
           {
               rotateBack = transform.DORotate(new Vector3(0,90,0), Mathf.Abs((float) rotationDegree / rotateSpeed));
               yield return rotateBack.WaitForCompletion();

           }
           else if(CompareTag("Red"))
           {
               rotateBack = transform.DORotate(new Vector3(0,-90,0), (float) rotationDegree / rotateSpeed);
               yield return rotateBack.WaitForCompletion();

           }
           Debug.Log("frigate test 4");


        }

        private void RotationCalculator()
        {
            directionVector = target.transform.position -transform.position;
            rotationDegree = Mathf.Atan(directionVector.y / directionVector.x) * Mathf.Rad2Deg;
            Debug.Log("rotation Degree : " + rotationDegree);
            if (!rotateToTarget.IsActive())
            {
                StartCoroutine(nameof(Rotator));

            }
        }

        private IEnumerator Rotator()
        {
                Debug.Log("frigate test 5");

                isRotationCompleted = false;
                //Quaternion lookRotation = Quaternion.LookRotation(directionVector);
                Debug.Log(rotationDegree);
                float t = Time.time;
                
                    rotateToTarget = transform.DOLookAt(target.transform.position, Mathf.Abs((float)rotationDegree)/rotateSpeed);

                
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation,rotateSpeed * Time.deltaTime);
                //Debug.Log("rotation degree is : " + rotationDegree);
                //  }
                yield return rotateToTarget.WaitForCompletion();
                Debug.Log("rotation time : " + (Time.time - t));
                isRotationCompleted = true;
        }

        
    }
}