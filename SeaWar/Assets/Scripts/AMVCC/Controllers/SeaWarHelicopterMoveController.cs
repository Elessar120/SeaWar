using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using AMVCC.Views;
namespace AMVCC.Controllers
{
    public class SeaWarHelicopterMoveController : SeaWarElement
    {
        [SerializeField] bool isStopTime;
        private float speed;
        public Action moveAction;
        private void Start()
        {
            isStopTime = GetComponent<SeaWarHelicopterView>().isStopTime;
            speed = GetComponent<SeaWarHelicopterView>().speed;
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

      

      

       private void SetMoveState()
       {
           isStopTime = !isStopTime;
       }

        private void Move()
        {
//            Debug.Log(speed);
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        
        public void StopMoving()
        {
            Debug.Log("stopmoving");
            isStopTime = true;
        }
        /*todo private IEnumerator Rotator()
        {
            yield return new WaitForSeconds(1);
        }*/
  
    }
}