using System;
using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarMagneticTowerController : SeaWarElement
    {
        private void OnTriggerEnter(Collider other)
        {
        
            
            if(other.gameObject.GetComponent<SeaWarAttackView>() != null)
            {
//                Debug.Log("oh yea!");

                 other.gameObject.GetComponent<SeaWarAttackView>().speed
                        = other.gameObject.GetComponent<SeaWarAttackView>().speed *
                                Application.model.magneticTowerModel.enemyCoenfficientSlowDown;
            }
                
            
                     
        }

        private void OnTriggerStay(Collider other)
        {
            
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<SeaWarAttackView>())
            {
                other.gameObject.GetComponent<SeaWarAttackView>().speed
                    = other.gameObject.GetComponent<SeaWarAttackView>().speedHolder;
            }
           
        }
    }
}