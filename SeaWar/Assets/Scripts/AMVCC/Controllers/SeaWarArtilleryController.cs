using UnityEngine;
using System;
using System.Linq;
using AMVCC.Views;
namespace AMVCC.Controllers
{
    public class SeaWarArtilleryController : SeaWarElement
    {
        [SerializeField]private float fireRate;
        [SerializeField]private bool isAttackTime;

        private void Start()
        {
            isAttackTime = true;
            fireRate = GetComponent<SeaWarArtilleryView>().fireRate;
        }

        private void Update()
        {
            if (!isAttackTime)
            {
                fireRate -= Time.deltaTime;
                if (fireRate <= 0)
                {
                    isAttackTime = true;
                    fireRate = GetComponent<SeaWarArtilleryView>().fireRate;
                }
                    
            }
        }

        private void OnTriggerEnter(Collider other)
        {

            if (!other.CompareTag(gameObject.tag))
            {

                if (other.name == "Motor Boat" || other.name == "Lench" || other.name == "Frigate" || other.name == "BattleShip" || other.name == "Oil Tanker" || other.name == "Submarine")

                {
                    Debug.Log("Fire!");
//todo                    StartCoroutine("Rotator");
                    Attack(other);
                    

                }
                
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag(gameObject.tag))
            {

                if (other.name == "Motor Boat" || other.name == "Lench" || other.name == "Frigate" || other.name == "BattleShip" || other.name == "Oil Tanker" || other.name == "Submarine")

                {
                    Attack(other);
                    

                }
                
            }
        }

        /*todo private IEnumerator Rotator()
        {
            yield return new WaitForSeconds(1);
        }*/
        private void Attack(Collider hit)
        {

            if (isAttackTime)
            {
                hit.GetComponent<SeaWarHealthView>().TakeDamage(GetComponent<SeaWarAttackView>().damage);
            }

            isAttackTime = false;

        }

    }
}