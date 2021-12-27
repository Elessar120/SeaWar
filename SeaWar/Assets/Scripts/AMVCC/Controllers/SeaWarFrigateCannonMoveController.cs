using System;
using AMVCC.Views;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core.Easing;

namespace AMVCC.Controllers
{
    public class SeaWarFrigateCannonMoveController : SeaWarElement
    {
        
        float fireRate;
        private Tween moveTween;
        private Ease moveEase = Ease.Linear;
        public GameObject target;

        private void Start()
        {
            fireRate = Application.model.seaWarFrigateModel.fireRate;
            moveTween = transform.DOMove(target.transform.position,
                Vector3.Distance(target.transform.position, transform.position) /fireRate).SetEase(moveEase);
        }
    }
}