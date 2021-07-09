using System;
using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarElectricTowerController : SeaWarElement
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(gameObject.tag))
            {
                if (other.name == "Artillery" || other.name == "Radioactive Tower" || other.name == "Anti Air Craft" || other.name == "Sea Mine")
                {
                    Debug.Log("befor effect : " + other.GetComponent<SeaWarAttackView>().damage);
                
                    GetComponent<SeaWarElectricTowerView>().effectedTowers.Add(other);
                    other.GetComponent<SeaWarAttackView>().damage = other.GetComponent<SeaWarAttackView>().damage *
                                                                    Application.model.electricTowerModel
                                                                        .damageIncreasedCoeffidency;
                    Debug.Log("after effect : " + other.GetComponent<SeaWarAttackView>().damage);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            GetComponent<SeaWarElectricTowerView>().effectedTowers.Remove(other);
        }


        private void OnDestroy()
        {
            foreach (Collider towers in GetComponent<SeaWarElectricTowerView>().effectedTowers)
            {
                GetComponent<SeaWarAttackView>().damage = GetComponent<SeaWarAttackView>().damageHolder;

            }
        }
    }
}