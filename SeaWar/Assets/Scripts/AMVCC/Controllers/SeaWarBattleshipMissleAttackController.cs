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
         }

         private void ExplosionDamage()
         {
             Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
             Destroy(transform.parent.gameObject);
             foreach (Collider hitCollider in hitColliders)
             {
                 if (hitCollider.gameObject.layer == LayerMask.NameToLayer("Buildings"))
                 {
                     if (hitCollider.transform.Find("Trench"))
                     {
                         var trench = hitCollider.transform.Find("Trench");
                         trench.GetComponent<SeaWarHealthView>().TakeDamage(damage);
                     }
                     else 
                     {
                         hitCollider.GetComponent<SeaWarHealthView>().TakeDamage(damage);
                         //Debug.Log(gameObject.transform.parent + "aaaaaaa");
                     } 
                 }
                 
             }
            
         }
    }
}