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
                    SetSubmarineDamage();
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
                case "Radioactive Tower(Clone)":
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
                    Debug.Log(gameObject.name);
                    SetAntiAirCraftDamage();
                    SetAntiAirCraftFireRate();
                    break;
                case "Jet Fighter(Clone)":
                    SetJetFighterSpeed();
                    SetJetFighterDamage();
                    SetJetFighterFireRate();
                    break;
                case "Helicopter(Clone)":
                    SetHelicopterSpeed();
                    SetHelicopterDamage();
                    SetHelicopterFireRate();
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

        private void SetSubmarineDamage()
        {
            damage = Application.model.submarineModel.damage;
            damageHolder = damage;
        }

        private void SetRadioactiveTowerDamage()
        {
            damage = Application.model.radioActiveTowerModel.damage;
            damageHolder = damage;
//            Debug.Log("radioactive tower damage :" + damage );
        }

        private void SetArtilleryDamage()
        {
           // damage = GetComponent<art>();
            damageHolder = damage;
        }

        private void SetSeaMineDamage()
        {
            damage =GetComponent<SeaWarSeaMineView>().damage;
            damageHolder = damage;
            Debug.Log(damage);
        }

        private void SetAntiAirCraftDamage()
        {
            damage = GetComponent<SeaWarAntiAirCraftView>().damage;
            damageHolder = damage;
        }
        private void SetJetFighterDamage()
        {
            damage = Application.model.jetFighterModel.damage;
            damageHolder = damage;
//            Debug.Log("damage" + damage);
            
        }
        private void SetHelicopterDamage()
        {
            damage = Application.model.helicopterModel.damage;
            damageHolder = damage;
            
        }
        private void SetReciveDamageOfRadioactiveTower()
        {
            lastRecivedDamageTimeOfRadioactiveTower = Application.model.radioActiveTowerModel.fireRate;
        }
        private void SetLenchSpeed()
        {
            speed = GetComponent<SeaWarLenchView>().speed;
            speedHolder = speed;
        }

        private void SetMotorBoatSpeed()
        {
            speed = GetComponent<SeaWarMotorBoatView>().speed;
            speedHolder = speed;

        }

        private void SetSubmarinSpeed()
        {
            //speed = GetComponent<SeaWarSubmarineView>().sp;
            speedHolder = speed;

        }

        private void SetJetFighterSpeed()
        {
            speed = GetComponent<SeaWarJetFighterView>().speed;
            speedHolder = speed;
        }
        private void SetHelicopterSpeed()
        {
            speed = GetComponent<SeaWarHelicopterView>().speed;
            speedHolder = speed;
            
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
        private void SetJetFighterFireRate()
        {
            fireRate = GetComponent<SeaWarJetFighterView>().fireRate;
        }

        private void SetAntiAirCraftFireRate()
        {
            fireRate = GetComponent<SeaWarAntiAirCraftView>().fireRate;

        }
        private void SetHelicopterFireRate()
        {
            fireRate = Application.model.helicopterModel.fireRate;
        }
        private void Update()
        {
//            Debug.Log(gameObject.name + " : " + damage);
        }
    }
}