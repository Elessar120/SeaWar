using UnityEngine;
using System;
using System.Collections;
using AMVCC.Views;
namespace AMVCC.Controllers
{
    public class SeaWarBattleshipMissleController : SeaWarElement
    {
        private new Rigidbody rigidbody;
        public float speed;
        private Collider target;
        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            speed = Application.model.battleshipModel.missleSpeed;
        }
     
        private void FixedUpdate()
        {
            if (target == null)
            {
                target = GetComponent<SeaWarBattleshipMissleView>().target;

            }
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

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(gameObject.tag))
            {
                if (other.gameObject.name == "Radioactive Tower" || other.gameObject.name == "Magnetic Tower" ||
                    other.gameObject.name == "Electric Tower" || other.gameObject.name == "Trench" ||
                    other.gameObject.name == "Anti Air Craft" || other.gameObject.name == "Artillery")
                {
                    
                }
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