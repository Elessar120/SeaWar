using System.Collections;
using System.Collections.Generic;
using AMVCC.Application;
using UnityEngine;

namespace AMVCC
{
    public class SeaWarElement : MonoBehaviour
    {
        public SeaWarApplication Application
        {
            get
            {
                return GameObject.FindObjectOfType<SeaWarApplication>();
            }
        }

    }

}
