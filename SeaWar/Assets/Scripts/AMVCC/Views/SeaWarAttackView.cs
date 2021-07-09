using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace AMVCC.Views
{
    public class SeaWarAttackView : SeaWarElement
    {
        public float fireRate; 
        public float lastRecivedDamageTimeOfRadioactiveTower;
        public float reciveDamageOfMagneticTower;
        public float reciveDamageOfElectricTower;
        public float speed;
        public float speedHolder;
        public float damage;
        public float damageHolder;
        private void Awake()
        {
            switch (gameObject.name)
            {
                case "Submarin(Clone)":
                    SetFireRateSubmarine();
                    SetReciveDamageOfRadioactiveTower();
                    SetSubmarinSpeed();
                    SetSubmarinDamage();
                    break;
                case "Motor Boat(Clone)":
                    Debug.Log("switch motor boat");
                    SetFireRateMotorBoat();
                    SetReciveDamageOfRadioactiveTower();
                    SetMotorBoatSpeed();
                    SetMotorBoatDamage();

                    break;
                case "Lench(Clone)":
                    SetFireRateLench();
                    SetReciveDamageOfRadioactiveTower();
                    SetLenchSpeed();
                    SetLenchDamage();

                    break;
                case "Radioactive Tower":
                    SetFireRateRadioactiveTower();
                    SetRadioactiveTowerDamage();
                    break;
                case "Electronic Tower(Clone)":
                    SetFireRateElectronicTower();
                    break;
                case "Magnetic Tower(Clone)":
                    SetFireRateMagneticTower();
                    break;
                case "Artillery(Clone)":
                    SetArtilleryDamage();

                    break;
                case "Sea Mine(Clone)":
                    SetSeaMineDamage();

                    break;
                case "Anti Air Craft(Clone)":
                    SetAntiAirCraftDamage();

                    break;
                }
        }

        private void Start()
        {
            if (transform.parent)
            {
                gameObject.tag = transform.parent.tag;
            }
        }

        private void SetLenchDamage()
        {
            damage = Application.model.lenchModel.damage;
            damageHolder = damage;
        }

        private void SetMotorBoatDamage()
        {
            damage = Application.model.motorBoatModel.damage;
            damageHolder = damage;
        }

        private void SetSubmarinDamage()
        {
            damage = Application.model.submarineModel.damage;
            damageHolder = damage;
        }

        private void SetRadioactiveTowerDamage()
        {
            damage = Application.model.radioActiveTowerModel.damage;
            damageHolder = damage;
            Debug.Log("radioactive tower damage :" + damage );
        }

        private void SetArtilleryDamage()
        {
            damage = Application.model.artilleryModel.damage;
            damageHolder = damage;
        }

        private void SetSeaMineDamage()
        {
            damage = Application.model.seaMineModel.damage;
            damageHolder = damage;
        }

        private void SetAntiAirCraftDamage()
        {
            damage = Application.model.antiAirCraftModel.damage;
            damageHolder = damage;
        }

        private void SetLenchSpeed()
        {
            speed = Application.model.lenchModel.speed;
            speedHolder = speed;
        }

        private void SetMotorBoatSpeed()
        {
            speed = Application.model.motorBoatModel.speed;
            speedHolder = speed;

        }

        private void SetSubmarinSpeed()
        {
            speed = Application.model.submarineModel.speed;
            speedHolder = speed;

        }

        private void SetReciveDamageOfRadioactiveTower()
        {
            lastRecivedDamageTimeOfRadioactiveTower = Application.model.radioActiveTowerModel.fireRate;
        }

        private void SetFireRateMagneticTower()
        {
        }

        private void SetFireRateElectronicTower()
        {
        }

        private void SetFireRateRadioactiveTower()
        {
            fireRate = GetComponent<SeaWarRadioActiveTowerView>().fireRate;
        }

        private void SetFireRateLench()
        {
            fireRate = GetComponent<SeaWarLenchView>().fireRate;
        }

        private void SetFireRateMotorBoat()
        {
            fireRate = GetComponent<SeaWarMotorBoatView>().fireRate;
        }

        private void SetFireRateSubmarine()
        {
            fireRate = GetComponent<SeaWarSubmarineView>().fireRate;
        }
    }
}