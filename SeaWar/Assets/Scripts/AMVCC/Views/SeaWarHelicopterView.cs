using UnityEngine;
using System.Collections;
namespace AMVCC.Views
{
    public class SeaWarHelicopterView : SeaWarElement
    {
        public float fireRate;
        public float health;
        public float damage;
        public bool isStopTime;
        public float speed;
        public Queue targets = new Queue();
        private void Awake()
        {
            fireRate = Application.model.helicopterModel.fireRate;
            health = Application.model.helicopterModel.health;
            damage = Application.model.helicopterModel.damage;
            speed = Application.model.helicopterModel.speed;
        }
    }
}