using UnityEngine;
using System;
using System.Collections;

using System.Linq;
using AMVCC.Views;
namespace AMVCC.Controllers
{
    public class SeaWarBattleshipRotateController : SeaWarElement
    { 
        public Action<Collider> reachEnemyAction;
        public Action deadEnemyAction;
        private Vector3 directionVector;
        Quaternion basicRotation;
        private float rotateSpeed;
        private Queue targets = new Queue();
        private void Start()
        {
            reachEnemyAction += AddQueue;
            deadEnemyAction += RemoveQueue;
            basicRotation = transform.rotation;
            rotateSpeed = Application.model.battleshipModel.rotateSpeed;
        }

        private void Update()
        {
            Debug.DrawRay(transform.position,directionVector,Color.red);
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
            directionVector = (Vector3)targets.Peek() - GetComponentInChildren<Transform>().position;

            float rotationDegree = Mathf.Atan(directionVector.y / directionVector.magnitude) * Mathf.Rad2Deg;
            Debug.Log("rotation Degree : " + rotationDegree);

            Rotator(rotationDegree);
        }

        private void Rotator(float rotationDegree)
        {
            /*if (targets.Count == 0)
            {
                transform.rotation = basicRotation;

            }*/
            //else
            //{
                Quaternion lookRotation = Quaternion.LookRotation(directionVector);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation,rotateSpeed * Time.deltaTime);
                //Debug.Log("rotation degree is : " + rotationDegree);
                //  }


        }
    }
}