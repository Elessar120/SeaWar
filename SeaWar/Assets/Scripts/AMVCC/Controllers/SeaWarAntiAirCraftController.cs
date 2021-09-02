using System;
using System.Collections;
using UnityEngine;
using AMVCC.Views;
using UnityEditor;

namespace AMVCC.Controllers
{
    public class SeaWarAntiAirCraftController : SeaWarElement
    {
        [SerializeField]private float fireRate;
        [SerializeField]private bool isAttackTime;

        private void Start()
        {
            isAttackTime = true;
            fireRate = GetComponent<SeaWarAttackView>().fireRate;
        }

        private void Update()
        {
            if (!isAttackTime)
            {
                fireRate -= Time.deltaTime;
                if (fireRate <= 0)
                {
                    isAttackTime = true;
                    fireRate = GetComponent<SeaWarAttackView>().fireRate;
                }
                    
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(gameObject.tag))
            {

                if (other.name == "Jet Fighter" || other.name == "Helicopter" || other.name == "Battleship Missle(Clone)")

                {

//todo                    StartCoroutine("Rotator");
                   Attack(other);
                    

                }
                
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (!other.CompareTag(gameObject.tag))
            {

                if (other.name == "Jet Fighter" || other.name == "Helicopter" || other.name == "Battleship Missle(Clone)")

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
                hit.GetComponent<SeaWarHealthView>().TakeDamage(GetComponent<SeaWarAntiAirCraftView>().damage);
                Debug.Log("AHHHH! " + hit.name + "is in me! it's damage is : " + GetComponent<SeaWarAttackView>().damage);

            }

            isAttackTime = false;

        }

       
    }
}