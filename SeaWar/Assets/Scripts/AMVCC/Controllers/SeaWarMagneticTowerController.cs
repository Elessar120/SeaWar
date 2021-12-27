using System;
using AMVCC.Controllers.FSM.Submarine;
using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarMagneticTowerController : SeaWarElement
    {
        [SerializeField] private SeaWarMagneticTowerView magneticTowerView;
        [SerializeField] private GameObject parentGameObject;
        private void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag(tag))
            {
                if (other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts") ||
                    other.gameObject.layer == LayerMask.NameToLayer("Air Crafts"))
                {
                    if (other.name == "Oil Tanker")
                    {
                        other.GetComponent<SeaWarOilTankerController>().onEffectedByMagneticTower(parentGameObject);

                    }
                    else if (other.name == "Motor Boat")
                    {
                        other.GetComponent<SeaWarMotorBoatController>().onEffectedByMagneticTower(parentGameObject);

                    }
                    else if (other.name == "Lench")
                    {
                        other.GetComponent<SeaWarLenchController>().onEffectedByMagneticTower(parentGameObject);

                    }
                    else if (other.name == "Frigate")
                    {
                        other.GetComponent<SeaWarFrigateMoveController>().onEffectedByMagneticTower(parentGameObject);

                    }
                    else if (other.name == "Battleship")
                    {
                        other.GetComponent<SeaWarBattleshipMoveController>().onEffectedByMagneticTower(parentGameObject);

                    }
                    else if (other.name == "Submarine")
                    {
                        other.GetComponentInParent<SubmarineController>().onEffectedByMagneticTower(parentGameObject);
                    }
                    else if (other.name == "Jet Fighter")
                    {
                        other.GetComponent<JetFighterMoveController>().onEffectedByMagneticTower(parentGameObject);

                    }
                    else if (other.name == "Helicopter")
                    {
                        other.GetComponent<SeaWarHelicopterMoveController>().onEffectedByMagneticTower(parentGameObject);

                    }
                }
            }

           
                
            
                     
        }

       

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<SeaWarSpeedController>())
            {
                other.gameObject.GetComponent<SeaWarSpeedController>().speed
                    = other.gameObject.GetComponent<SeaWarSpeedController>().speedHolder;
            }
           
        }
    }
}