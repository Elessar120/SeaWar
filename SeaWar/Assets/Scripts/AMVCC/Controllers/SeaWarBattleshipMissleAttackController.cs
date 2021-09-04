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
         public Action noEnemyAction;
         private void Start()
         {
             noEnemyAction += UpdateTarget;
             target = (Collider)GetComponentInParent<SeaWarBattleshipAttackController>().targets.Peek(); 
             damage = Application.model.battleshipModel.damage;
         }

         private void UpdateTarget()
         {
             if (gameObject.transform.parent)
             {
                 if (GetComponentInParent<SeaWarBattleshipAttackController>().targets.Peek() != null)
                 {
                     target = (Collider)GetComponentInParent<SeaWarBattleshipAttackController>().targets.Peek(); 
                 }
             }
             
             target = (Collider)GetComponentInParent<SeaWarBattleshipAttackController>().targets.Peek(); 

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
                     
                     Destroy(transform.parent.gameObject);
                 }
             }
         }
    }
}