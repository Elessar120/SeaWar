using System;
using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class SeaWarPlatformController : SeaWarElement
    {
        private void OnTriggerStay(Collider other)
        {
            // if (other.CompareTag("Tower"))
            // {
            //     GetComponent<SeaWarPlatformView>().platformIsFull = true;
            //     Debug.Log(GetComponent<SeaWarPlatformView>().platformIsFull);
            // }
        }
    }
}