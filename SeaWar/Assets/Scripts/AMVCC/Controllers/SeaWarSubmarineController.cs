using System;
using AMVCC.Views;
using UnityEngine;
using  DG.Tweening;
namespace AMVCC.Controllers
{
    public class SeaWarSubmarineController : SeaWarElement
    {
        [SerializeField] private GameObject mapCenter;
        private float rotateSpeed;
        private Rigidbody rigidbody;
        float speed;
        private bool isMoving;
        private bool isRotatingToBase;
        private bool isRotatingToBattlefield;
        private Vector3 startPostion;
        private Quaternion startRotation;
        private float rotationTime;
        private void Start()
        {
            rotateSpeed = Application.model.submarineModel.rotateSpeed;
            speed = Application.model.submarineModel.speed;
            mapCenter = GameObject.Find("Middle Map");
            isMoving = true;
            startPostion = GetComponent<SeaWarSubmarineView>().startPosition;
            startRotation = transform.rotation;
            rotationTime = 1;
            rigidbody = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Middle Map")
            {
                isMoving = false;
                if (gameObject.CompareTag("Blue"))
                {
                     rigidbody.DORotate(new Vector3(0,270,0), 1f, RotateMode.Fast);
    
                }
                if (gameObject.CompareTag("Red"))
                {
                    rigidbody.DORotate(new Vector3(0,90,0), 1f, RotateMode.Fast);

                }
                //isRotatingToBase = true;
                //Vector3 targetRotationAngle = transform.eulerAngles + 180f * Vector3.up;
                //transform.eulerAngles = Vector3.RotateTowards(targetRotationAngle,targetRotationAngle,Time.deltaTime,0f);
                //Quaternion targetRotationAngle = Quaternion.LookRotation(-transform.forward ,Vector3.up);
                //transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotationAngle,180 * Time.deltaTime);

                //isMoving = true;
            }   
        }

        private void Update()
        {
            if (isMoving)
            {
                Move();
            }

            /*if (isRotatingToBase)
            {
                //transform.Rotate(new Vector3(0, -180 * Time.deltaTime, 0));
                Quaternion targetRotationAngle = Quaternion.LookRotation(-transform.right ,Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation,targetRotationAngle,180 * Time.deltaTime);
                /*if (Mathf.Abs(transform.rotation.y - startRotation.y) == 0)
                {
                    isRotatingToBase = false;
                    isMoving = true;
                }#1#
                //isRotating = false;
                //isMoving = true;

            }*/
            float position = mapCenter.transform.position.x - transform.position.x;
            Debug.Log("Position = " + position);

            if (position < 0.1 && position > -0.1)
            {
                
            }
        }

        private void Move()
        {
            transform.position += transform.forward * speed * Time.deltaTime;

        }

        
    }
}