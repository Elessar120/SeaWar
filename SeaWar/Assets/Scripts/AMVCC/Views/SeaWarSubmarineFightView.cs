using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarSubmarineFightView : SeaWarElement
    {
        private void Awake()
        {
            
            Application.model.submarineModel.hunting = false;
        }

        private void Start()
        {
            Application.model.submarineModel.damage = Application.model.submarineModel.submarineData.damage;
            Application.model.submarineModel.health =Application.model.submarineModel.submarineData.health;
            Application.model.submarineModel.fireRate =Application.model.submarineModel.submarineData.fireRate;
            Application.model.submarineModel.shootableMask = LayerMask.GetMask (Application.model.submarineModel.submarineData.AttackTargets);
        }

        private void Update()
        {
            Application.controller.submarineFightController.DelayBetweenAttacks();
        }

        private void OnTriggerEnter(Collider other)
        {
            Application.controller.submarineFightController.ActivateAttackModeWhenEnemyIsInRange(other);
        }

        private void OnTriggerExit(Collider other)
        {
            Application.controller.submarineFightController.DeActivateAttackMode(other);
        }
    }
}