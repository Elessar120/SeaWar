using System;
using UnityEngine;

namespace AMVCC.Controllers
{
    public class MapEdgeController : SeaWarElement
    {
        private void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
        }
    }
}