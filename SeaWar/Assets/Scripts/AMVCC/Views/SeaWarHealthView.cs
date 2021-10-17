using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using AMVCC.Controllers;
using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarHealthView : SeaWarElement
    { 
        public float health;
        private bool isDead;
        public List<GameObject> attackers = new List<GameObject>();
            
        private void Start()
        {
            switch(gameObject.name)
            {
                case "Refinery 1":
                   SetHealthRefinery();
                    break;
                case "Refinery 2":
                   SetHealthRefinery();
                    break;
                case "Refinery 3":
                   SetHealthRefinery();
                    break;
                case "Submarine":
                    SetHealthSubmarine();
                    break;
                case "Oil Tanker":
                    SetHealthOilTanker();
                    break;
                case "Motor Boat":
                    SetHealthMotorBoat();
                    break;
                case "Lench":
                    SetHealthLench();
                    break;
                case "Radioactive Tower":
                    SetHealthRadioactiveTower();
                    break;
                case "Electric Tower":
                    SetHealthElectronicTower();
                    break;
                case "Magnetic Tower":
                    SetHealthMagneticTower();
                    break;
                case "Trench":
                    SetHealthTrench();
                    break;
                case "Anti Air Craft":
                    SetAntiAirCraftHealth();
                    Debug.Log("running!");

                    break;
                case "Jet Fighter":
                    SetJetFighterHealth();

                    break;
                case "Helicopter":
                    SetHelicopterHealth();
                    break;
                case  "Artillery":
                    SetArtilleryHealth();
                    break;
                case "Frigate":
                    SetFrigateHealth();
                    break;
                case "Battleship":
                    SetBattleshipHealth();
                    break;
                case "Battleship Missle(Clone)":
                    SetBattleshipMissleHealth();
                    break;
            }
            
        }

        private void SetBattleshipHealth()
        {
            health = Application.model.battleshipModel.health;
        }

        private void SetBattleshipMissleHealth()
        {
            health = Application.model.battleshipModel.missleHealth;

        }

        private void SetFrigateHealth()
        {
            health = Application.model.seaWarFrigateModel.health;
        }

        private void SetArtilleryHealth()
        {
            Debug.Log("artillery health : " + health);
            health = Application.model.artilleryModel.health;
        }


        private void SetHealthTrench()
        {
            health = Application.model.trenchModel.health;
        }

        private void SetHealthMagneticTower()
        {
            health = Application.model.magneticTowerModel.health;
        }

        private void SetHealthElectronicTower()
        {
            health = Application.model.electricTowerModel.health;
        }

        private void SetHealthRadioactiveTower()
        {
            health = Application.model.radioActiveTowerModel.health;
        }

        private void SetHealthLench()
        {
            health = Application.model.lenchModel.health;
        }

        private void SetHealthMotorBoat()
        {
            health = Application.model.motorBoatModel.health;
        }

        private void SetHealthOilTanker()
        {
            health = Application.model.oilTankerModel.health;
        }

        private void SetHealthSubmarine()
        {
            health = Application.model.submarineModel.health;
        }

        private void SetHealthRefinery()
        {
            health = Application.model.refineryModel.health;
        }
        private void SetJetFighterHealth()
        {
            health = Application.model.jetFighterModel.health;
        }

        private void SetAntiAirCraftHealth()
        {
            health = Application.model.antiAirCraftModel.health;
        }
        private void SetHelicopterHealth()
        {
            health = Application.model.helicopterModel.health;
        }
        public void TakeDamage(float damage)
        {
                //     Debug.Log(damage);
            if (health > 0)
            {
                isDead = false;
                health -= damage;
//                    Debug.Log( gameObject.name + health);
            }
            if (health <= 0)
            {
                health = 0f;
                isDead = true;
                OnRegister();
                Death();
            }
            //return isDead;
            }

        private void OnRegister()
        {
            Debug.Log("list has : " + attackers.Count + "objects");
            foreach (GameObject attacker in attackers)
            {
                if (attacker != null)
                {
                    Debug.Log(attacker.name);
                    if (attacker.name == "Helicopter(Clone)")   
                    {
                        attacker.GetComponent<SeaWarHelicopterAttackController>().onKillAction();
                        Debug.Log("I called action");
                    }
                    else if (attacker.name == "Frigate(Clone)")
                    {
                        attacker.GetComponent<SeaWarFrigateAttackController>().onKillAction();
                    }

                    if (attacker.name == "Battleship(Clone)" || attacker.name == "Battleship Missle(Clone)")
                    {
                        attacker.GetComponentInParent<SeaWarBattleshipMoveController>().isStopTime = false;
                        //attacker.GetComponent<SeaWarBattleshipAttackController>().onKillAction(gameObject);
                    }
                }
                
            }        
        }

        private void Death()
        {
            if (gameObject.layer == LayerMask.NameToLayer("Buildings"))
            {

                gameObject.GetComponent<SeaWarPlatformController>().onDestroy();
            }
            if (transform.parent && gameObject.name != "Trench")
            {
                Destroy(transform.parent.gameObject);
            }

            
            Destroy(gameObject);
            
        }
    }
}