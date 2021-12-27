using System;
using UnityEngine;
using System.Collections.Generic;
namespace AMVCC.Views
{
    public class SeaWarSpeedController : SeaWarElement
    {
        private List<GameObject> effectiveMagneticTowers;
        public Action <GameObject> onEffectedByMagneticTower;
        public float fireRate;
        public float lastRecivedDamageTimeOfRadioactiveTower;
        public float reciveDamageOfMagneticTower;
        public float reciveDamageOfElectricTower;
        public float speed;
        public float speedHolder;
        public float damage;
        public float damageHolder;
        [SerializeField] float currentSpeed;
        private void Awake()
        {
            switch (gameObject.name)
            {
                case "Submarine":
                    SetSubmarinSpeed();

                    //SetFireRateSubmarine();
                    //SetReciveDamageOfRadioactiveTower();
                    //SetSubmarineDamage();
                    break;
                case "Motor Boat":
                    SetMotorBoatSpeed();

                    Debug.Log("switch motor boat");
                    //SetFireRateMotorBoat();
                   // SetReciveDamageOfRadioactiveTower();
                    //SetMotorBoatDamage();

                    break;
                case "Lench":
                   // SetFireRateLench();
                    //SetReciveDamageOfRadioactiveTower();
                    SetLenchSpeed();
                    //SetLenchDamage();

                    break;
                case "Radioactive Tower(Clone)":
                    SetRadioactiveTowerDamage();

                   // SetFireRateRadioactiveTower();
                    break;
                case "Electronic Tower(Clone)":
                    //SetFireRateElectronicTower();
                    break;
                case "Magnetic Tower(Clone)":
                    //SetFireRateMagneticTower();
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
                    //SetAntiAirCraftFireRate();
                    break;
                case "Jet Fighter":
                    SetJetFighterSpeed();
                    /*SetJetFighterDamage();
                    SetJetFighterFireRate();*/
                    break;
                case "Helicopter":
                    SetHelicopterSpeed();
                    /*SetHelicopterDamage();
                    SetHelicopterFireRate();*/
                    break;
                case "Frigate":
                    SetFrigateSpeed();
                    /*SetFrigateDamage();
                    SetFrigateFireRate();*/
                    break;
                case "Artillery":
                    /*SetArtilleryDamage();
                    SetArtilleryFireRate();*/
                    break;
                case "Oil Tanker":
                    SetOilTankerSpeed();
                    break;
                case "Battleship":
                    SetBattleshipSpeed();
                    break;
            }
        }
        private void Start()
        {
            effectiveMagneticTowers = new List<GameObject>();
            onEffectedByMagneticTower += AddMagneticTowerToList;
            currentSpeed = speed;
            if (transform.parent)
            {
                gameObject.tag = transform.parent.tag;
            }
        }
        private void AddMagneticTowerToList(GameObject magneticTower)
        {
            if (!effectiveMagneticTowers.Contains(magneticTower))
            {
                effectiveMagneticTowers.Add(magneticTower);

            }
            Debug.Log("lists count = " + effectiveMagneticTowers.Count + " " + magneticTower.name);
        }
        public float CalculateCurrentSpeed()
        {

            currentSpeed = speed;
            Debug.Log(effectiveMagneticTowers.Count);
            for (int i = 0; i < effectiveMagneticTowers.Count; i++)
            {
                if (!effectiveMagneticTowers[i])
                {
                    effectiveMagneticTowers.RemoveAt(i);

                }
                else
                {
                    currentSpeed *= Application.model.magneticTowerModel.enemyCoenfficientSlowDown;

                }


            }

            return currentSpeed;
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
            damage = GetComponent<SeaWarArtilleryView>().damage;
            damageHolder = damage;
        }

        private void SetSeaMineDamage()
        {
            damage = GetComponent<SeaWarSeaMineView>().damage;
            damageHolder = damage;
            Debug.Log(damage);
        }

        private void SetAntiAirCraftDamage()
        {
            damage = GetComponent<SeaWarAntiAirCraftView>().damage;
            damageHolder = damage;
            Debug.Log("anti air craft damage is : " + damage);
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

        private void SetFrigateDamage()
        {
            damage = Application.model.seaWarFrigateModel.damage;
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
            speed = Application.model.motorBoatModel.speed;
            speedHolder = speed;

        }

        private void SetSubmarinSpeed()
        {
            speed = GetComponent<SeaWarSubmarineView>().speed;
            speedHolder = speed;
            Debug.Log(gameObject.name + "'speed : " + speed);
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

        private void SetFrigateSpeed()
        {
            speed = Application.model.seaWarFrigateModel.speed;
            speedHolder = speed;
        }

        void SetOilTankerSpeed()
        {
            speed = Application.model.oilTankerModel.movmentSpeed;
            speedHolder = speed;
        }

        void SetBattleshipSpeed()
        {
            speed = Application.model.battleshipModel.speed;
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
            fireRate = Application.model.antiAirCraftModel.fireRate;

        }
        private void SetHelicopterFireRate()
        {
            fireRate = Application.model.helicopterModel.fireRate;
        }

        private void SetFrigateFireRate()
        {
            fireRate = Application.model.seaWarFrigateModel.fireRate;

        }

        private void SetArtilleryFireRate()
        {
            fireRate = GetComponent<SeaWarArtilleryView>().fireRate;

        }
        private void Update()
        {
//            Debug.Log(gameObject.name + " : " + damage);
        }
    }
}