using System;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class Billboard : SeaWarElement
    {
        public Transform cam;

        private void Start()
        {
            cam = Camera.main.transform;
        }

        private void LateUpdate()
        {
            transform.LookAt(transform.position + cam.forward);
        }
    }
}

