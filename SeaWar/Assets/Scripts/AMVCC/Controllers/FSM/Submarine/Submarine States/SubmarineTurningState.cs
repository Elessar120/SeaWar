using UnityEngine;
using AMVCC.Views;
namespace AMVCC.Controllers.FSM.Submarine.Submarine_States
{
    public class SubmarineTurningState : SubmarineBaseState
    {
        public void EnterState(SubmarineController submarine)
        {
            submarine.SetSubmarineTurnAnimationStateToTrue();
            /*if (submarine.PreviousState == submarine.movingForwardState)
            {
                submarine.gameObject.transform.rotation = Quaternion.Euler(0,180,0);
            }

            if (submarine.PreviousState == submarine.movingBackState)
            {
                submarine.gameObject.transform.rotation = Quaternion.Euler(0,180,0);

            }*/
            //Debug.Log(submarine.CurrentState);

        }

        public void Update(SubmarineController submarine)
        {
           
           
        }

        public void OnTriggerEnter(SubmarineController submarine, Collider other)
        {
            
        }

        public void OnTriggerStay(SubmarineController submarine, Collider other)
        {
            
        }

        public void OnTriggerExit(SubmarineController submarine, Collider other)
        {
            
        }
    }
}