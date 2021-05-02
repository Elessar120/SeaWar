using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers.FSM.Submarine.Submarine_States
{
    public class SubmarineMovingBackState : SubmarineBaseState
    {
        
        public void EnterState(SubmarineController submarine)
        {
            submarine.gameObject.GetComponent<SeaWarSubmarineView>().wasInMiddleFirstTime = true;
            submarine.GetComponent<SeaWarSubmarineView>().nextDestination =
                submarine.GetComponent<SeaWarSubmarineView>().startPosition;
            //Debug.Log(submarine.CurrentState);

        }

        public void Update(SubmarineController submarine)
        {
            submarine.transform.position = Vector3.MoveTowards(submarine.transform.position,submarine.gameObject.GetComponent<SeaWarSubmarineView>().startPosition, Time.deltaTime * submarine.Application.model.submarineModel.submarineData.movmentSpeed);
            if (Vector3.Distance(submarine.transform.position, submarine.GetComponent<SeaWarSubmarineView>().startPosition) <= 0f)
            {
                submarine.TransitionToState(submarine.turningState);
            }
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
