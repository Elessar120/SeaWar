using UnityEngine;
using UnityEngine.PlayerLoop;

namespace AMVCC.Controllers.FSM.Submarine.Submarine_States
{
    public interface SubmarineBaseState
    {
        void EnterState(SubmarineController submarine);
        void Update(SubmarineController submarine);
        void OnTriggerEnter(SubmarineController submarine);
        void OnTriggerStay(SubmarineController submarine);
        void OnTriggerExit(SubmarineController submarine);
    }
}
