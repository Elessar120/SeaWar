using UnityEngine;
using System.Collections;
using System.Linq;
using AMVCC.Views;
namespace AMVCC.Controllers
{
    public class SeaWarArtilleryController : SeaWarElement
    {
        //public Action onKillAction;

        [SerializeField] private float fireRate;
        [SerializeField] private bool isAttackTime;
        [SerializeField] private SeaWarArtilleryView artilleryView;
        [SerializeField] private SeaWarArtilleryRotationController artilleryRotationController;
        private Queue targets = new Queue();

        private GameObject target;

        //private GameObject target;
        private float rotateDuration;
        private float timer;
        private double rotationDegree;
        private bool isRotateTime;

        private void Start()
        {
            rotateDuration = artilleryView.rotateSpeed;
            isAttackTime = true;
            fireRate = artilleryView.fireRate; 
            // onKillAction += RemoveQueue;
            //onKillAction += CallActionInRotateClass;

        }

        private void Update()
        {
            if (target == null)
            {
                artilleryRotationController.nullTargetAction();
                //todo after full rotate back call this
            }

            if (!isAttackTime)
            {
                float t = Time.time - timer;
//                Debug.Log("fire rate : " + t);

                //fireRate -= Time.deltaTime;
                if (t >= fireRate)
                {
                    isAttackTime = true;
                    timer = Time.time;
//                    Debug.Log("fire rate full : " + t);
                }

            }

            /*if (target)
            {
                Vector3 directionVector = target.transform.position - parentTransform.transform.position; 
                rotationDegree = Mathf.Atan(directionVector.y / directionVector.x) * Mathf.Rad2Deg;
                Rotate(directionVector, rotationDegree);
            }*/

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts"))

            {
                //Debug.Log(transform.parent.name);
                Debug.Log(other.gameObject.name);
                ////towerView.attackTargets.Add(other.gameObject);
                // Attack(other.gameObject);
                if (!other.CompareTag(tag))
                {
                    if (!target)
                    {
                        target = other.gameObject;

                        artilleryRotationController.newTargetAction(target);

                    }

                }

            }

        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts"))
            {
                if (!other.CompareTag(tag))
                {
                    if (!target)
                    {
                        target = other.gameObject;
                        artilleryRotationController.newTargetAction(target);
                    }

                    if (target && artilleryRotationController.isRotationCompleted)
                    {
                        Attack(target);

                    }

                }
            }

        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Sea Crafts"))
            {
                if (!other.CompareTag(tag))
                {
                    if (other == target.GetComponent<Collider>())
                    {
                        target = null;
                        artilleryRotationController.nullTargetAction();
                        Debug.Log(other.name + " exit from : " + transform.name);
                        //Debug.Log("queue count is : " + targets.Count);
                        //isRotateTime = false;
                    }
                }
            }
        }

        private void Attack(GameObject hit)
        {
            Debug.Log(name + "is attacking to : " + hit.name);

            if (isAttackTime)
            {
                bool isDead = hit.GetComponent<SeaWarHealthView>().TakeDamage(artilleryView.CalculateCurrentDamage(), gameObject);
                isAttackTime = false;
                timer = Time.time;

                if (isDead)
                {
                    target = null;

                    artilleryRotationController.nullTargetAction();

                }
            }
        }
    }
}