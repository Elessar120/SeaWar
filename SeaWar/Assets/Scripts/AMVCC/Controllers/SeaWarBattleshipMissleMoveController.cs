using UnityEngine;
using DG.Tweening;

namespace AMVCC.Controllers
{
    public class SeaWarBattleshipMissleMoveController : SeaWarElement
    {
        private Tween rotateTween;
        [SerializeField] new Rigidbody rigidbody;
        [SerializeField] float speed;
        public GameObject target;
        private Vector3 targetPosition;
        public GameObject myBattleship;
        private bool isMoving;
        //public Action noEnemyAction;
        public bool isExploded;
        private void Start()
        {
//            Debug.Log(target.name);
           // noEnemyAction += UpdateTarget;
            rigidbody = GetComponent<Rigidbody>();
            speed = Application.model.battleshipModel.missleSpeed;
            //target = GetComponent<SeaWarBattleshipMissleView>().target;
            targetPosition = target.transform.position;
            isMoving = true;
        }
     
        private void FixedUpdate()
        {
            if (isMoving)
            {
                Move();
            }

            if (!target)
            {
                rotateTween.Kill();
                Destroy(gameObject);
            }
            /*if (target != null)
            {
                

            }
            else if(target == null)
            {
                target = targetClone;
                transform.position += transform.forward * Time.deltaTime * speed;

            }*/
                    

            
            /*
            if (damage == 0)
            {
                damage = Application.model.battleshipModel.damage;
            }*/
                
        }

        private void Move()
        {
            /*moveTweenSequence.Append(transform.DOMoveY(9, speed).SetSpeedBased(true))
                .Append(transform.DOLookAt(target.transform.position, 1).SetSpeedBased(true))
                .Append(transform.DOMove(target.transform.position, speed).SetSpeedBased()); */
            if (transform.position.y >= 9)
            {
                if (target)
                {
                    rotateTween = transform.DODynamicLookAt(target.transform.position, Vector3.Distance(target.transform.position,transform.position)/speed);
                }
                else if (!target)
                {
                    rotateTween.Kill();
                }
                Vector3 directionVector = targetPosition - transform.position;
                //RotationCalculator(directionVector);
                transform.position += transform.forward * Time.deltaTime * speed;
               

            }
            else
            {
                transform.position += transform.forward * Time.deltaTime * speed;

            }
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(gameObject.tag))
            {
                if (other.gameObject.name == "Radioactive Tower" || other.gameObject.name == "Magnetic Tower" ||
                    other.gameObject.name == "Electric Tower" || other.gameObject.name == "Trench" ||
                    other.gameObject.name == "Anti Air Craft" || other.gameObject.name == "Artillery")
                {
                    isMoving = false;
                    GetComponentInChildren<SeaWarBattleshipMissleAttackController>().onMissleHit();
                }
            }
        }

        

        /*private void UpdateTarget()
        {
            if (gameObject.transform.parent)
            {
                if (GetComponentInParent<SeaWarBattleshipAttackController>().targets != null)
                {
                    target = GetComponentInParent<SeaWarBattleshipAttackController>().targets.Peek(); 
                }
            }
             
        }*/

        private void RotationCalculator(Vector3 directionVector)
        {

                //transform.rotation = Quaternion.Euler(60,0,0);
                double rotationDegree = Mathf.Atan(directionVector.y / directionVector.x) * Mathf.Rad2Deg;
                Rotator(directionVector);
        }

        private void Rotator(Vector3 directionalVector)
        {
            Quaternion lookRotation = Quaternion.LookRotation(directionalVector);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,lookRotation, Time.deltaTime * 120);
        }
    }
}