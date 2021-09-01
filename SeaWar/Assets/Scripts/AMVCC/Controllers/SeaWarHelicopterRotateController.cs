using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AMVCC.Views;

namespace AMVCC.Controllers
{
    public class SeaWarHelicopterRotateController : SeaWarElement
    {
        public Action <Collider> reachEnemyAction;
        public Action deadEnemyAction;
        private Vector3 directionVector;
        Quaternion basicRotation;
        private Queue targets = new Queue();
        private float rotateSpeed;
        private void Start()
        {
            reachEnemyAction += AddQueue;
            deadEnemyAction += RemoveQueue;
            basicRotation = transform.rotation;
            rotateSpeed = Application.model.helicopterModel.rotateSpeed;
        }

        private void Update()
        {
            if (targets.Count != 0)
            {
                RotationCalculator();
            }

            if (targets.Count == 0)
            {
                RotatateToOrginal();
            }
        }

        private void RotatateToOrginal()
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation,basicRotation,rotateSpeed * Time.deltaTime); 
        }

        //todo call action in other script
        private void AddQueue(Collider enemy)
        {

            targets.Enqueue(enemy.transform.position);
            //RotationCalculator();

        }

        private void RemoveQueue()
        {
            targets.Dequeue();
            Rotator(0);
        }
        private void RotationCalculator()
        {
            directionVector = (Vector3)targets.Peek() - transform.position;

            double rotationDegree = Mathf.Atan(directionVector.y / directionVector.x) * Mathf.Rad2Deg;
            Debug.Log("rotation Degree : " + rotationDegree);

            Rotator(rotationDegree);
        }

        private void Rotator(double rotationDegree)
        {
            /*if (targets.Count == 0)
            {
                transform.rotation = basicRotation;

            }*/
            //else
            //{
                Quaternion lookRotation = Quaternion.LookRotation(directionVector,Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation,rotateSpeed * Time.deltaTime);
                //Debug.Log("rotation degree is : " + rotationDegree);
                //  }


        }
    }
}