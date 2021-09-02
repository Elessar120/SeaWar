using UnityEngine;
using System;
using System.Collections;
using AMVCC.Views;

namespace AMVCC.Controllers
{
    public class SeaWarBattleshipMissleAttackController : SeaWarElement
    {
         [SerializeField]private Collider target;
         [SerializeField]private float damage;

         private void Start() 
         { 
             target = (Collider)GetComponentInParent<SeaWarBattleshipAttackController>().targets.Peek(); 
             damage = Application.model.battleshipModel.damage;
         }
         private void OnTriggerEnter(Collider other)
         {
             if (!other.CompareTag(gameObject.tag))
             {
                 if (other.gameObject.name == "Radioactive Tower" || other.gameObject.name == "Magnetic Tower" ||
                     other.gameObject.name == "Electric Tower" || other.gameObject.name == "Trench" ||
                     other.gameObject.name == "Anti Air Craft" || other.gameObject.name == "Artillery")
                 {
                     if (!other.GetComponent<SeaWarHealthView>().attackers.Contains(gameObject))
                     {
                         other.GetComponent<SeaWarHealthView>().attackers.Add(gameObject);     
                     }
                     other.GetComponent<SeaWarHealthView>().TakeDamage(damage);
                     if (hit.transform.Find("Trench"))
                     {
                         if (isAttackTime)
                         {
                    
                             var trench = hit.transform.Find("Trench");
                             //trench.GetComponent<SeaWarHealthView>().TakeDamage(damage);
                             MissleSpawner();
                             isAttackTime = false;
                         }

                         isAttackTime = false;

                     }
                     else if(!hit.transform.Find("Trench"))
                     {
                         if (isAttackTime)
                         {
                             Debug.Log("suck " + hit.name + "'s dick!");

                             //hit.GetComponent<SeaWarHealthView>().TakeDamage(damage);
                             MissleSpawner();
                             isAttackTime = false; 
                         }
                
                         isAttackTime = false;
                     }

                 }
                     Destroy(gameObject);
                 }
             }
         }
    }
}