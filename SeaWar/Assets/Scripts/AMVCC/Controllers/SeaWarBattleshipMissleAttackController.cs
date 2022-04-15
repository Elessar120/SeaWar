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
             Destroy(transform.parent.gameObject,20);
         }

         private void ExplosionDamage()
         {
              
             Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
             
             for(int i = 0; i < hitColliders.Length; i++)
             {
                 if (hitColliders[i].gameObject.layer == LayerMask.NameToLayer("Buildings") && !hitColliders[i].CompareTag(tag))
                 {
                     if (hitColliders[i].transform.Find("Trench"))
                     {
                         /*if (!hitCollider.GetComponent<SeaWarHealthView>().attackers.Contains(gameObject))
                         {
                             hitCollider.GetComponent<SeaWarHealthView>().attackers.Add(gameObject);     
                         }*/
                         var trench = hitColliders[i].transform.Find("Trench");
                         trench.GetComponent<SeaWarHealthView>().TakeDamage(damage, gameObject);
                     }
                     else 
                     {  
                         /*if (!hitCollider.GetComponent<SeaWarHealthView>().attackers.Contains(gameObject))
                         {
                             hitCollider.GetComponent<SeaWarHealthView>().attackers.Add(gameObject);     
                         }*/
                         hitColliders[i].GetComponent<SeaWarHealthView>().TakeDamage(damage, gameObject);
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