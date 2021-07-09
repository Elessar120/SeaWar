using System;
using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarMagneticTowerController : SeaWarElement
    {
        private void OnTriggerEnter(Collider other)
        {
        
            Debug.Log("oh yea!");
            
            if(other.gameObject.GetComponent<SeaWarAttackView>() != null)
            {
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
            other.gameObject.GetComponent<SeaWarAttackView>().speed
                = other.gameObject.GetComponent<SeaWarAttackView>().speedHolder;
        }
    }
}