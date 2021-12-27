using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarSubmarineFightView : SeaWarElement
    {
        public bool haunting;
        public float health;
        public string myTag;
        public bool isAttackTime;
        public float fireRate;
        public Collider enemyCollider;
        public bool isChasing;
        
        private void Awake()
        {
            haunting = false;

        }

        private void Start()
        {
            isAttackTime = true;
            myTag = gameObject.tag;
            health = Application.model.submarineModel.health;

        }

        private void Update()
        {
        }

      
    }
}