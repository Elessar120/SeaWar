using UnityEngine;
using System;
using System.Linq;
using AMVCC.Views;
namespace AMVCC.Controllers
{
    public class SeaWarBattleshipMoveController : SeaWarElement
    {
        public bool isStopTime;
        private float speed;
        public bool isStopTimeForEver;
        private void Start()
        {
            isStopTime = GetComponent<SeaWarBattleshipView>().isStopTime;
            speed = GetComponent<SeaWarBattleshipView>().speed;
            
        }

        
        private void Update()
        {

            if (!isStopTime && !isStopTimeForEver)
            {
                Move();
            }
           
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(transform.tag))
            {
                
                 if (other.gameObject.layer == LayerMask.NameToLayer("Refinery"))
                 {
                     isStopTimeForEver = true;
                     Debug.Log("collide!"); 
                     isStopTime = true;
                 }
               
                
            }  
        }


       

        private void Move()
        {
//            Debug.Log(speed);
            transform.position += transform.forward * speed * Time.deltaTime;
//            Debug.Log(speed);

        }

        
       
    }
}