using System;
using UnityEngine;
using AMVCC.Views;
namespace AMVCC.Controllers
{
    public class SeaWarFrigateMoveController : SeaWarElement
    {
        [SerializeField] bool isStopTime;
        private float speed;
        public Action moveAction;
        private void Start()
        {
            isStopTime = GetComponent<SeaWarFrigateView>().isStopTime;
            speed = GetComponent<SeaWarFrigateView>().speed;
            moveAction += SetMoveState;
        }

        
        private void Update()
        {
            Debug.Log(isStopTime);

            if (!isStopTime)
            {
                Move();
            }
           
        }

        /*private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(gameObject.tag))
            {
                if (other.name == "Refinery 1" || other.name == "Refinery 2" || other.name == "Refinery 3")
                {
                    Debug.Log("collide!");
                    SetMoveState();
                }
            }            
        }
        */


        private void SetMoveState()
        {
            isStopTime = !isStopTime;
        }

        private void Move()
        {
//            Debug.Log(speed);
            transform.position += transform.forward * speed * Time.deltaTime;
            Debug.Log(speed);

        }

        
        public void StopMoving()
        {
            Debug.Log("stopmoving");
            isStopTime = true;
        }
        
    }
}