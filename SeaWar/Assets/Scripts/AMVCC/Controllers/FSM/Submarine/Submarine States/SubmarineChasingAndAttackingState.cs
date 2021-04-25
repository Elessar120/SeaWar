using AMVCC.Views;
using UnityEngine;

namespace AMVCC.Controllers.FSM.Submarine.Submarine_States
{
    public class SubmarineChasingAndAttackingState : SubmarineBaseState
    {
        public void EnterState(SubmarineController submarine)
        {
            submarine.GetComponent<SeaWarSubmarineView>().isChasing = true;
            Debug.Log(submarine.CurrentState);
        }

        public void Update(SubmarineController submarine)
        {
            RaycastHit hit;
            Ray ray = new Ray(submarine.transform.position, submarine.transform.right);
            Debug.DrawRay(submarine.transform.position,submarine.transform.right * 3, Color.green);

            if (Physics.Raycast(ray,out hit, 3f))
            {
                
                Debug.Log(submarine.tag+" enemy in sight! :" + hit.collider.name);
                if (!hit.collider.CompareTag("MiddleMap") && !hit.collider.CompareTag("StartPoint"))
                {
                    submarine.GetComponent<SeaWarSubmarineView>().enemyCollider = hit.collider; 
                    Chase(submarine,hit.collider);
                    SetFireRate(submarine,hit.collider);
                }
                //submarine.currentState.Update(this);
               
            }
            else
            {
                submarine.GetComponent<SeaWarSubmarineView>().enemyCollider = null;
                submarine.GetComponent<SeaWarSubmarineView>().isChasing = false;

                submarine.TransitionToState(submarine.turningState);
            }
            
        }

        public void OnTriggerEnter(SubmarineController submarine)
        {
        }

        public void OnTriggerStay(SubmarineController submarine)
        {
            
        }
        private void Chase(SubmarineController submarine, Collider enemyCollider)
        {
            Debug.Log(submarine.tag+"chasing");
           submarine.transform.position = Vector3.MoveTowards(submarine.transform.position,
                new Vector3(enemyCollider.transform.position.x,
                    enemyCollider.transform.position.y, enemyCollider.transform.position.z),
                Time.deltaTime * submarine.Application.model.submarineModel.submarineData.movmentSpeed);
        }
        private void SetFireRate(SubmarineController submarine, Collider enemyCollider)
        {
            SeaWarSubmarineView instance = submarine.GetComponent<SeaWarSubmarineView>();
            if (instance.isAttackTime)
            {
                Attack(submarine.Application.model.submarineModel.submarineData.damage, enemyCollider); 
                instance.isAttackTime = false;
            }
                
            instance.fireRate -= Time.deltaTime;
                
            if (instance.fireRate < 0)
            {
                instance.fireRate = submarine.Application.model.submarineModel.submarineData.fireRate;
                instance.isAttackTime = true;
            }
        }
        public void Attack(float damage, Collider enemyCollider)
        {
            enemyCollider.GetComponent<SubmarineController>().TakeDamage(damage);
        }
      

       public void OnTriggerExit(SubmarineController submarine)
        {
            
        }
    }
}
