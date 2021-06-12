using System;
using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarRadioActiveTowerAttackController : SeaWarElement
    {
        private SeaWarPlatformView platformView;
        private SeaWarRadioActiveTowerView towerView;
        private float fireRate;
        private void Start()
        {
            SetFireRate();
        }

        private void OnTriggerEnter(Collider other)
        {

            if (other.gameObject.layer != gameObject.layer)
            {
                towerView.attackTargets.Add(other.gameObject);
                Attack(other.gameObject);
            }
            
        }

        private void OnTriggerStay(Collider other)
        {
            fireRate -= Time.time;
            if (fireRate <= 0)
            {
                foreach (GameObject target in towerView.attackTargets)
                {
                    Attack(target);
                    SetFireRate();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            foreach (GameObject target in towerView.attackTargets)
            {
                if (other.gameObject.name == target.gameObject.name)
                {
                    //towerView.attackTargets[];
                }
            }
        }

        private void SetFireRate()
        {
            fireRate = GetComponent<SeaWarRadioActiveTowerView>().fireRate;

        }

        private void Attack(GameObject other)
        {
            other.gameObject.GetComponent<SeaWarHealthController>().TakeDamage(towerView.damage);

        }

        private void OnDestroy()
      {
          platformView.platformIsFull = false;
      }
    }
}