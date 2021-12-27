using System;
using AMVCC.Views;
using UnityEditor;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarSeaMineController : SeaWarElement
    {
        private bool isExplosionTime;
        [SerializeField] private SeaWarSeaMineView seaMineView;
        private float damage;
        private Collider waterPlatform;
        private void Start()
        {
            damage = seaMineView.damage;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts"))
            {
                if (!other.CompareTag(gameObject.tag))
                {
                    isExplosionTime = true;
                    int explosiveLayer = LayerMask.NameToLayer("Sea Crafts");
                    Debug.Log(other.name);
                }
                
            }

            if (other.name == "Water 1" || other.name == "Water 2" || other.name == "Water 3")
            {
                other.GetComponent<SeaWarWaterPlatformView>().onBuildingTime();
                waterPlatform = other;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position,3f);
        }

        private void Update()
        {
            if (!waterPlatform)
            {
                
            }
            if (isExplosionTime)
            {
                Collider[] explosiveColliders = Physics.OverlapSphere(transform.position, 3f);
                
                foreach (Collider explosiveCollider in explosiveColliders)
                {
                    Debug.Log("explosiveColliders : " + explosiveCollider.name + "mine position: " + transform.position);

                    if (explosiveCollider.gameObject.layer == LayerMask.NameToLayer("Sea Crafts"))
                    {
                        if (!explosiveCollider.CompareTag(tag))
                        {
                            explosiveCollider.GetComponent<SeaWarHealthView>().TakeDamage(seaMineView.CalculateCurrentDamage(), gameObject);

                        }
                        
                    }

                }
                Death();
            }
        }

        private void Death()
        {
            waterPlatform.GetComponent<SeaWarWaterPlatformView>().onBuildingTime();

            if (transform.parent)
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}