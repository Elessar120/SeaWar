using System;
using UnityEngine;
using AMVCC.Views;
namespace AMVCC.Controllers
{
    public class SeaWarJetFighterBombAttackController : SeaWarElement
    {
        private bool isExplosionTime;
        public Action onExplosionAction;
        public GameObject target;
        [SerializeField] float damage;
        private void Start()
        {
            tag = transform.parent.tag;
            onExplosionAction += Explode;
            damage = Application.model.jetFighterModel.damage;
        }
        private void Explode()
        {
            isExplosionTime = true;
        }
        private void OnTriggerEnter(Collider other)
        {
            /*if (other.gameObject)
            {
                Attack(other);

            }*/
        }

        private void OnTriggerStay(Collider other)
        {
            if (isExplosionTime)
            {
                if (!other.CompareTag(tag))
                {
                    if (other.gameObject.layer == LayerMask.NameToLayer("Buildings") || other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts"))
                    {
                        Attack(other);

                    }
                }
            }
        }

        private void Attack(Collider other)
        {
            if (other.name == "Water 1" || other.name == "Water 2" || other.name == "Water 3")
            {
                
            }

            if (other.transform.Find("Trench"))
            {
                    var trench = other.transform.Find("Trench");
                    trench.GetComponent<SeaWarHealthView>().TakeDamage(damage, gameObject);
            }
            else if(!other.transform.Find("Trench"))
            {
                other.GetComponent<SeaWarHealthView>().TakeDamage(damage, gameObject);
            }
            
            //Death();
        }
        private void Death()
        {
            Destroy(transform.parent);
        }
    }
}