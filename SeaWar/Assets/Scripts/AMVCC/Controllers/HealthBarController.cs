using System;
using UnityEngine;
using UnityEngine.UI;
namespace AMVCC.Controllers
{
    public class HealthBarController : SeaWarElement
    {
        [SerializeField] private SlicedFilledImage fill;
        [SerializeField] private Sprite fullHealthSprite;
        [SerializeField] private Sprite midHealthSprite;
        [SerializeField] private Sprite lowHealthSprite;
        private bool isMidHealth;
        private bool isLowHealth;
        //private SlicedFilledImage slicedFilledImage;
        
        public Action<float> onHealthChange;
        public Action<float> onStart;

        private float fullHealth;
        private void Awake()
        {
            onStart += SetStartHealth;
            onHealthChange += SetHealth;
            //slicedFilledImage = fill.GetComponent<SlicedFilledImage>();

        }       

        private void Start()
        {
            
        }

        private void SetStartHealth(float startHealth)
        {
            fullHealth = startHealth;
            Debug.Log("onstartaction");
            fill.fillAmount = 1;
            fill.sprite = fullHealthSprite;

        }

        private void SetHealth(float currentHealth)
        {
            
            if (fill.fillAmount > .6f)
            {
                fill.fillAmount = currentHealth / fullHealth;
            }
            else if (fill.fillAmount <= .6f && fill.fillAmount > .3f)
            {
                if (!isMidHealth)
                {
                    fill.sprite = midHealthSprite;
                    isMidHealth = true;
                    Debug.Log("onhealthchange");

                }

                fill.fillAmount = currentHealth / fullHealth;
            }
            else if (fill.fillAmount <= .3f)
            {
                if (!isLowHealth)
                {
                    fill.sprite = lowHealthSprite;
                    isLowHealth = true;
                    Debug.Log("onhealthchange");

                }
                fill.fillAmount = currentHealth / fullHealth;

            }
            

        }
        
    }
}