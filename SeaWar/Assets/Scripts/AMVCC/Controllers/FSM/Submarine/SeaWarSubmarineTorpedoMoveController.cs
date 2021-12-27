using System;
using UnityEngine;
using DG.Tweening;
namespace AMVCC.Controllers.FSM.Submarine
{
    public class SeaWarSubmarineTorpedoMoveController : SeaWarElement
    {
        public GameObject target;
        private Tween moveTween;
        private float fireRate;
        private Ease moveEase = Ease.Linear;
        private float speed;
        private void Start()
        {
            fireRate = Application.model.submarineModel.fireRate;
            speed = Application.model.submarineModel.speed;
            /*moveTween = transform.DOMove(target.transform.position,
                Vector3.Distance(target.transform.position, transform.position) / fireRate).SetEase(moveEase);*/


        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position,(speed + fireRate) * Time.deltaTime);
        }
    }
}