using System;
using UnityEngine;
using AMVCC.Views;
namespace AMVCC.Controllers
{
    public class SeaWarFrigateCannonAttackController : SeaWarElement
    {
        public GameObject target;
        private float damage;

        private void Start()
        {
            damage = Application.model.seaWarFrigateModel.damage;
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
            if (other.transform.Find("Trench"))
            {
                
                    
                    var trench = other.transform.Find("Trench");
                    bool isDead = trench.GetComponent<SeaWarHealthView>().TakeDamage(damage, gameObject);
                    if (isDead)
                    {                

                        other = null;


                    }
                


            }
            else if(!other.transform.Find("Trench"))
            {
                
                    Debug.Log("suck " + other.name + "'s dick!");

                    bool isDead = other.GetComponent<SeaWarHealthView>().TakeDamage(damage, gameObject);
                    if (isDead)
                    {
                        other = null;
                    }
                
            }

            Death();
        }

        private void Death()
        {
            Destroy(gameObject);
        }
    }
}