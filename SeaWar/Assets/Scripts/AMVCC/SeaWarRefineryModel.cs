using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AMVCC
{
    public class SeaWarRefineryModel : SeaWarElement
    {
        public Unit refineryData;
        public Unit oilTankerData;
        [SerializeField] float storedOil;// just for watch each refinery production separately
        public static Action onOilProductionAction;
    }
}