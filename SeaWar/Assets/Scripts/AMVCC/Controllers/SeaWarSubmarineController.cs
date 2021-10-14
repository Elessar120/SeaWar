using System;
using System.Collections;
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
        [SerializeField] Vector3 startPostion;
        private Quaternion startRotation;
        private float rotationTime;
        private float rotateDuration;
        private void Start()
        {
            rotateSpeed = Application.model.submarineModel.rotateSpeed;
            speed = Application.model.submarineModel.speed;
            mapCenter = GameObject.Find("Middle Map");
            isMoving = true;
            startPostion = GetComponent<SeaWarSubmarineView>().startPosition;
            startRotation = transform.rotation;
            rigidbody = GetComponent<Rigidbody>();
            rotateDuration = 0.9f;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Middle Map")
            {
                Debug.Log("in middle map");
                if (!isRotatingToBase)//for OnTriggerEnter runs one time 
                {
                    isRotatingToBase = true;
                    StartCoroutine(Rotate());
                }
               
            }

            if (other.name == "Refinery 1" || other.name == "Refinery 2" || other.name == "Refinery 3" && isRotatingToBase)
            {
                StartCoroutine(Rotate());
                isRotatingToBase = false;
            }
        }

        private IEnumerator Rotate()
        {
            Quaternion targetRotationAngle = Quaternion.LookRotation(-transform.forward ,Vector3.up);

            isMoving = false;
            if (gameObject.CompareTag("Blue"))
            {
                //rigidbody.DORotate(new Vector3(0,-90,0), rotateDuration, RotateMode.Fast);
                transform.DORotateQuaternion(targetRotationAngle, rotateDuration);

            }
            if (gameObject.CompareTag("Red"))
            {
                transform.DORotateQuaternion(targetRotationAngle, rotateDuration);
            }

            yield return new WaitForSeconds(rotateDuration + 0.1f);
            isMoving = true;
        }
        

        private void Update()
        {
            if (isMoving)
            {
                Move();
            }

        }

        private void Move()
        {
            transform.position += transform.forward * speed * Time.deltaTime;

        }

        
    }
}