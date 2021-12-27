using System;
using AMVCC.Views;
using UnityEngine;
using DG.Tweening;
namespace AMVCC.Controllers
{
    public class SeaWarJetFighterBombController : SeaWarElement
    {
        [SerializeField] private SeaWarJetFighterBombAttackController bombAttackController;
        public GameObject target;
        private float damage;
        private Tween moveTween;
        private Ease moveEase = Ease.Linear;
        private bool isExplosionTime;
        private void Start()
        {
            damage = Application.model.jetFighterModel.damage;
            moveTween = transform
                .DOMoveY(0, 1)
                .SetEase(moveEase).OnKill(Explode).OnComplete(Explode);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Bridge Platform" || other.name == "Water 1" || other.name == "Water 2" || other.name == "Water 3"
            || other.gameObject.layer == LayerMask.NameToLayer("Buildings") || other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts"))
            {
                moveTween.Kill();
            }
        }

        private void Explode()
        {
            isExplosionTime = true;
            bombAttackController.onExplosionAction();
        }
        private void OnTriggerStay(Collider other)
        {
            if (isExplosionTime)
            {
                
                Death();

            }
        }
        private void Death()
        {
            Destroy(gameObject);
        }
    }
}