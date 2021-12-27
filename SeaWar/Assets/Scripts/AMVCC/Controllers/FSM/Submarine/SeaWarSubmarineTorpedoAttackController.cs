using System;
using UnityEngine;
using AMVCC.Views;
namespace AMVCC.Controllers.FSM.Submarine
{
    public class SeaWarSubmarineTorpedoAttackController : SeaWarElement
    {
        public GameObject target;
        private float damage;
        private void Start()
        {
            damage = Application.model.submarineModel.damage;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (target == other.gameObject)
            {
                Attack(other.gameObject);
            }
        }

        private void Attack(GameObject other)
            {
          
                Debug.Log("my name is : " + other.name);
                Debug.Log("suck " + other.name + "'s dick!");

                    bool isDead = other.GetComponent<SeaWarHealthView>().TakeDamage(damage, gameObject);
                    if (isDead)
                    {
                        other = null;
                    }
                
                

                Death();
            }

            private void Death()
            {
                Destroy(gameObject);
            }
        }
    }
