using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
