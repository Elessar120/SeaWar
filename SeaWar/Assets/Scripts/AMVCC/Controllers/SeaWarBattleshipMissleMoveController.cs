using UnityEngine;
using System;
using System.Collections;
using AMVCC.Views;
namespace AMVCC.Controllers
{
    public class SeaWarBattleshipMissleMoveController : SeaWarElement
    {
        [SerializeField] new Rigidbody rigidbody;
        [SerializeField] float speed;
        [SerializeField]private Collider target;
        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            speed = Application.model.battleshipModel.missleSpeed;
            target = (Collider)GetComponentInParent<SeaWarBattleshipAttackController>().targets.Peek();

        }
     
        private void FixedUpdate()
        {
            /*if (target == null)
            {
                target = GetComponent<SeaWarBattleshipMissleView>().target;

            }

            if (damage == 0)
            {
                damage = Application.model.battleshipModel.damage;
            }*/
            if (target != null)
            {
                Vector3 directionVector = target.gameObject.transform.position - transform.position;
                if (transform.localPosition.y >= 375)
                {
                    RotationCalculator(directionVector);
                    transform.position += transform.forward * Time.deltaTime * speed;

                }
                else
                {
                    transform.position += transform.forward * Time.deltaTime * speed;

                }
            }
            else
            {
                //Destroy(gameObject);
            }

            
        }

        

        private void RotationCalculator(Vector3 directionVector)
        {

                //transform.rotation = Quaternion.Euler(60,0,0);
                double rotationDegree = Mathf.Atan(directionVector.y / directionVector.x) * Mathf.Rad2Deg;
                Rotator(directionVector);
        }

        private void Rotator(Vector3 directionalVector)
        {
            Quaternion lookRotation = Quaternion.LookRotation(directionalVector);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,lookRotation, Time.deltaTime * 60);
        }
    }
}