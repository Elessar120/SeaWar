using System;
using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarHealthView : SeaWarElement
    {
        private float health;
        private void Start()
        {
            switch(gameObject.name)
            {
                case "Rifinery":
                   SetHealthRefinery();
                    break;
                case "Submarin":
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
                case "Electronic Tower":
                    SetHealthElectronicTower();
                    break;
                case "Magnetic Tower":
                    SetHealthMagneticTower();
                    break;
            }
        }

        private void SetHealthMagneticTower()
        {
            health = Application.model.submarineModel.health;
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

        public void TakeDamage(float damage)
        {
            Debug.Log(health);
            if (health > 0)
            {
                health -= damage;
                Debug.Log(health);

            }
            else
            {
                health = 0f;
                Death();
      
            }
        }

        private void Death()
        {
            Destroy(gameObject);
        }
    }
}