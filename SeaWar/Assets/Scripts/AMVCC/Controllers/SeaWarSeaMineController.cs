using System;
using AMVCC.Views;
using UnityEditor;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarSeaMineController : SeaWarElement
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Lench" || other.name == "Motor Boat" || other.name == "Oil Tanker" || other.name == "Battleship" || other.name == "Submarine" || other.name == "Small Battleship")
            {
                Debug.Log(GetComponent<SeaWarAttackView>().damage);
                other.GetComponent<SeaWarHealthView>().TakeDamage(gameObject.GetComponent<SeaWarAttackView>().damage);
                Death();
            }
        }

        private void Death()
        {
            Destroy(transform.parent.gameObject);        
        }
    }
}