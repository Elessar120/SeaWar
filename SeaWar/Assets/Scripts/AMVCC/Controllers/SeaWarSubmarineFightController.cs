using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarSubmarineFightController : SeaWarElement
    {
        public void DelayBetweenAttacks()
        {
            if (Application.model.submarineModel.hunting)
            {
                Application.model.submarineModel.fireRate -= Time.time;
                if (Application.model.submarineModel.fireRate < 0)
                {
                    Attack(Application.model.submarineModel.submarineData.damage);
                    Application.model.submarineModel.fireRate = Application.model.submarineModel.submarineData.fireRate;
                }
            }
        }
        public void Attack(float damage)
        {
        
        }
        public void TakeDamage(float damage)
        {
            if (Application.model.submarineModel.health > 0)
            {
                Application.model.submarineModel.health -= damage;
            
            }
            else
            {
                Application.model.submarineModel.health = 0;
                Destroy(gameObject);
            }
        }

        public void ActivateAttackModeWhenEnemyIsInRange(Collider other)
        {
            if (other.gameObject.layer == Application.model.submarineModel.shootableMask)
            {
                Application.model.submarineModel.hunting = true;
            }
        }
        public void DeActivateAttackMode(Collider other)
        {
            Application.model.submarineModel.hunting = false;
        }
    }
}