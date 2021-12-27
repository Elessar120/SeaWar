using System;
using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarElectricTowerController : SeaWarElement
    {
        bool isFirstTime;

        [SerializeField] GameObject parentGameObject;

        private void Start()
        {
            isFirstTime = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(gameObject.tag))
            {
                if (other.name == "Artillery" || other.name == "Radioactive Tower" || other.name == "Anti Air Craft" || other.name == "Sea Mine")
                {
                    Debug.Log("electric tower");
//                    Debug.Log("befor effect : " + other.GetComponent<SeaWarAttackView>().damage);
                
                    //GetComponent<SeaWarElectricTowerView>().effectedTowers.Add(other);
                   // other.GetComponent<SeaWarAttackView>().damage = other.GetComponent<SeaWarAttackView>().damage *
                                                                   // Application.model.electricTowerModel
                                                                      //  .damageIncreasedCoeffidency;
//                    Debug.Log("after effect : " + other.GetComponent<SeaWarAttackView>().damage);
                }
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.name == "Artillery")
            {
                if (other.CompareTag(tag))
                {
                    if (other.CompareTag(tag))
                    {
                        other.GetComponent<SeaWarArtilleryView>().onEffectedByElectricTower(parentGameObject);
                    }
                }
            }

            if (other.name == "Radioactive Tower")
            {
                if (other.CompareTag(tag))
                {
                    other.GetComponent<SeaWarRadioActiveTowerView>().onEffectedByElectricTower(parentGameObject);
                }
            }

            if (other.name == "Anti Air Craft")
            {
                if (other.CompareTag(tag))
                {
                    if (other.CompareTag(tag))
                    {
                        other.GetComponent<SeaWarAntiAirCraftView>().onEffectedByElectricTower(parentGameObject);
                    }
                }
            }

            if (other.name == "Sea Mine")
            {
                if (other.CompareTag(tag))
                {
                    if (other.CompareTag(tag))
                    {
                        other.GetComponent<SeaWarSeaMineView>().onEffectedByElectricTower(parentGameObject);
                    }
                }
            }

            if (other.CompareTag(tag))
            {
                if (isFirstTime)
                {

                    isFirstTime = false;
                }
            }

            if (other.name == "Artillery" || other.name == "Radioactive Tower" || other.name == "Anti Air Craft" ||
                other.name == "Sea Mine")
                {


                }
            }
        

        private void OnTriggerExit(Collider other)
        {
            //GetComponent<SeaWarElectricTowerView>().effectedTowers.Remove(other);
        }


        private void OnDestroy()
        {
            foreach (Collider towers in GetComponent<SeaWarElectricTowerView>().effectedTowers)
            {
                //GetComponent<SeaWarAttackView>().damage = GetComponent<SeaWarAttackView>().damageHolder;

            }
        }
    }
}