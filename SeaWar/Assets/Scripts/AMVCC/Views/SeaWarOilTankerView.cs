using UnityEngine;

namespace AMVCC.Views
{
    public class SeaWarOilTankerView : SeaWarElement
    {
        private void Awake()
        {
            Application.model.oilTankerModel.oilTankerRotationAnimator = GetComponent<Animator>();

        }

        

       

       
    }
}