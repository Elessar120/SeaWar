using System;
using UnityEngine;

namespace AMVCC
{
    public class SeaWarRefineryView : SeaWarElement
    {
        private void Start()
          {
             Application.controller.refineryController.InvokeRepeating("AddOilAmount",1f,1f);
          }   
        
    }
}