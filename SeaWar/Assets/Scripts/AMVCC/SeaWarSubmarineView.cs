using System;
using UnityEngine;

namespace AMVCC
{
    public class SeaWarSubmarineView : SeaWarElement
    {
        private void Awake()
        {
       
        }
    
        private void Start()
        {
            
         
            
        }
        private void Update()
        {
           Application.controller.submarineController.Move();
        }

        private void OnTriggerEnter(Collider other)
        {
            Application.controller.submarineController.CheckSubmarineIsInMiddleOrStartPoint(other);
        }
    }
}