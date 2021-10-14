using AMVCC.Views;
using UnityEngine;
using DG.Tweening;
namespace AMVCC.Controllers.FSM.Submarine.Submarine_States
{
    public class SubmarineChasingAndAttackingState : SubmarineBaseState
    {
        public void EnterState(SubmarineController submarine)
        {
            //submarine.GetComponent<SeaWarSubmarineView>().isChasing = true;
            
            Debug.Log(submarine.CurrentState);
        }

        public void Update(SubmarineController submarine)
        {
            /*RaycastHit hit;
            Ray ray = new Ray(submarine.GetComponent<SeaWarSubmarineView>().rayCastingPoint.transform.position, submarine.transform.right);
            Debug.DrawRay(submarine.GetComponent<SeaWarSubmarineView>().rayCastingPoint.transform.position,submarine.transform.right * 3, Color.green);
            if (Physics.Raycast(ray,out hit, 3f))
            {
                
//                Debug.Log(submarine.tag+" enemy in sight! :" + hit.collider.name);
                if (!hit.collider.CompareTag(submarine.GetComponent<SeaWarSubmarineView>().tag) &&
                    (hit.collider.name == "Submarine(Clone)" || hit.collider.name == "OilTanker(Clone)" ||
                     hit.collider.name == "BattleShip(Clone)" || hit.collider.name == "SmallBattleship(Clone)" ||
                     hit.collider.name == "MotorBoat(Clone)" ))
                {
                    submarine.GetComponent<SeaWarSubmarineView>().enemyCollider = hit.collider; 
                    Chase(submarine,hit.collider);
                    //SetFireRate(submarine,hit.collider);
                }
                //submarine.currentState.Update(this);
               
            }
            else
            {
                submarine.GetComponent<SeaWarSubmarineView>().enemyCollider = null;

                 if (!submarine.GetComponent<SeaWarSubmarineView>().middleMapPassed)
                 {
                    submarine.TransitionToState(submarine.movingForwardState);
                 }
                 else
                 {
                     submarine.TransitionToState(submarine.turningState);

                 }

            }*/
            
           
            
        }

        public void OnTriggerEnter(SubmarineController submarine, Collider other)
        {
           
        }

        public void OnTriggerStay(SubmarineController submarine, Collider other)
        {
            /*if (other != null)
            {
                if (!other.CompareTag(submarine.tag) &&
                    (other.name == "Submarine(Clone)" || other.name == "OilTanker(Clone)" ||
                     other.name == "BattleShip(Clone)" || other.name == "SmallBattleship(Clone)" ||
                     other.name == "MotorBoat(Clone)" ))
                {
                    Debug.Log(other.name + other.tag);

                    //Chase(submarine,hit.collider);
                    //SetFireRate(submarine,hit.collider);
                }
            }
           
            else
            {
                if (Vector3.Distance(submarine.transform.position, submarine.Application.model.submarineModel.middleMap.transform.position) < 6.6)
                {
                    submarine.TransitionToState(submarine.turningState);

                }
                else
                {
                    submarine.TransitionToState(submarine.movingForwardState);
                }
            }*/
        }
        /*private void Chase(SubmarineController submarine, Collider enemyCollider)
        {
            Debug.Log(submarine.tag+" is chasing");
           submarine.transform.position = Vector3.MoveTowards(submarine.transform.position,
                new Vector3(enemyCollider.transform.position.x,
                    enemyCollider.transform.position.y, enemyCollider.transform.position.z),
                Time.deltaTime * submarine.Application.model.submarineModel.submarineData.movmentSpeed);
        }*/
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
      

       public void OnTriggerExit(SubmarineController submarine, Collider other)
        {
            

        }

       public void Start(SubmarineController submarine)
       {
           throw new System.NotImplementedException();
       }

       public void Enable(SubmarineController submarine)
       {
           throw new System.NotImplementedException();
       }
    }
}
