using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarLenchView : SeaWarElement
    {
        public float damage;
        public float speed;
        public float fireRate;
        public float timer;
        public bool isAttackTime;
        public bool isStopTime;
        private void Awake()
        {
            damage = Application.model.lenchModel.damage;
            speed = Application.model.lenchModel.speed;
            fireRate = Application.model.lenchModel.fireRate;
            timer = Application.model.lenchModel.fireRate;
            isAttackTime = true;
        }
    }
}