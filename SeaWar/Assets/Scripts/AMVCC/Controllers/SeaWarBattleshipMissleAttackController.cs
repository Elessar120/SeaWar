using UnityEngine;
using System;
using System.Collections;
using AMVCC.Views;

namespace AMVCC.Controllers
{
    public class SeaWarBattleshipMissleAttackController : SeaWarElement
    {
         [SerializeField]private float damage;
         public Action onMissleHit;
         private float explosionRadius;
         private void Start()
         {
             //motherBattleship = GetComponentInParent<Transform>();
             //Debug.Log("mother battleship name : " + motherBattleship.name);
             //gameObject.transform.parent.SetParent(null);
             //target = motherBattleship.GetComponent<SeaWarBattleshipAttackController>().targets.Peek(); 
             explosionRadius = Application.model.battleshipModel.battleshipData.explosionArea;
             damage = Application.model.battleshipModel.damage;
             onMissleHit += ExplosionDamage;
             Destroy(transform.parent.gameObject,15);
         }

         private void ExplosionDamage()
         {
             
             Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
             
             foreach (Collider hitCollider in hitColliders)
             {
                 if (hitCollider.gameObject.layer == LayerMask.NameToLayer("Buildings"))
                 {
                     if (hitCollider.transform.Find("Trench"))
                     {
                         /*if (!hitCollider.GetComponent<SeaWarHealthView>().attackers.Contains(gameObject))
                         {
                             hitCollider.GetComponent<SeaWarHealthView>().attackers.Add(gameObject);     
                         }*/
                         var trench = hitCollider.transform.Find("Trench");
                         trench.GetComponent<SeaWarHealthView>().TakeDamage(damage);
                     }
                     else 
                     {  
                         /*if (!hitCollider.GetComponent<SeaWarHealthView>().attackers.Contains(gameObject))
                         {
                             hitCollider.GetComponent<SeaWarHealthView>().attackers.Add(gameObject);     
                         }*/
                         hitCollider.GetComponent<SeaWarHealthView>().TakeDamage(damage);
                         //Debug.Log(gameObject.transform.parent + "aaaaaaa");
                     } 
                 }
                 
             }
             Destroy(transform.parent.gameObject);
           
         }

         private void OnDrawGizmos()
         {
             Gizmos.DrawWireSphere(transform.position,explosionRadius);
         }
    }
}