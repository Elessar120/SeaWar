using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

namespace AMVCC.Controllers
{
    public class ButtonsAnimationController : SeaWarElement
    {
        private Tween scaledTween;
        private float newScale;
        private float baseScale;
        private float scaleTime;
        
        private GameObject touchedButton;

        private void Start()
        {
            newScale = .95f;
            baseScale = 1f;
            scaleTime = .2f;
        }

        private void Update()
        {
#if UNITY_EDITOR 
            Debug.Log("mouse 0 is pressed");
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("mouse 0 is held");
                touchedButton = EventSystem.current.currentSelectedGameObject;
                Debug.Log(touchedButton.name + touchedButton.tag);
                       
                if (touchedButton.CompareTag("AnimatedButton"))
                {
                    Debug.Log("animated button");

                    scaledTween = touchedButton.transform.DOScale(newScale, scaleTime);
                            
                }
                      
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (touchedButton.CompareTag("AnimatedButton"))
                {
                    Debug.Log("mouse 0 is released");
                    scaledTween = touchedButton.transform.DOScale(baseScale, scaleTime);
                }
                
            }   
#endif
            

            if (Input.touchCount <= 0) 
                return;
            Touch currentTouch = Input.GetTouch(0);
            touchedButton = EventSystem.current.currentSelectedGameObject;
            Debug.Log("toched button!");
            Debug.Log(touchedButton.name + touchedButton.tag);
            //Ray ray = Camera.main.ScreenPointToRay(currentTouch.position);
           // RaycastHit hit;
           // if (Physics.Raycast(ray,out hit))
            //{
                if (touchedButton.CompareTag("AnimatedButton"))
                {
                   
                    if (currentTouch.phase == TouchPhase.Stationary)
                    {
                        
                        scaledTween = touchedButton.transform.DOScale(newScale, scaleTime);
                    }

                    if (currentTouch.phase == TouchPhase.Ended)
                    {
                        if (touchedButton.CompareTag("AnimatedButton"))
                        {
                            Debug.Log("touch ended");
                            scaledTween = touchedButton.transform.DOScale(baseScale, scaleTime);
                        }
                    }
                }
            //}
        }

        private void KillTween()
        {
            scaledTween.Kill();
        }
    }
}