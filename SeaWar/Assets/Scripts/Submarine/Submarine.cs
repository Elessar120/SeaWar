using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Submarine : MonoBehaviour,IMovementSystem
{
      
      
      /*private enum playerTeam
      {
            red,blue

      }
      private playerTeam team;*/
      private bool wasInMiddleFirstTime;
      private bool isGoingToMiddleMap;
      public Animator rotationAnimator;
      private GameObject middleMap;
      private Vector3 startPosition;
      [SerializeField] private float smooth = 180f;
      private float rotationAngle;
      private Quaternion target;
      [SerializeField] private float speed = 1.2f;
      private void Awake()
      {

            rotationAnimator = GetComponent<Animator>();
            middleMap = GameManager.Instance.middleMap;
            startPosition = transform.position;
            rotationAngle = 180;
            
      }

      private void Start()
      {
            startPosition = gameObject.transform.position;
            wasInMiddleFirstTime = false;
            isGoingToMiddleMap = true;
      }
      public void Move()
      {
            Debug.Log(SubmarineFightSystem.hunting);
            // if (!SubmarineFightSystem.hunting)
            //{
            if (!rotationAnimator.GetBool("isInRotateMod"))
            {
                  if (isGoingToMiddleMap)
                  {
                        transform.position = Vector3.MoveTowards(transform.position,new Vector3(middleMap.transform.position.x,transform.position.y,transform.position.z),Time.deltaTime * speed);
                  }
                  else
                  {
                        transform.position = Vector3.MoveTowards(transform.position,startPosition,Time.deltaTime * speed);

                  }

            }
            // }
      }
  

      private void Update()
      {
            Move();
      }
      private void OnTriggerEnter(Collider other)
      {
            if (other.CompareTag("MiddleMap"))
            {
                 
                  rotationAnimator.SetBool("isInRotateMod", true);
                  if (!wasInMiddleFirstTime)
                  {
                        wasInMiddleFirstTime = true;
                        
                  }
                  isGoingToMiddleMap = false;
            }

            if (other.CompareTag("StartPoint") && wasInMiddleFirstTime)
            {
                  rotationAnimator.SetBool("isInRotateMod", true);
                  isGoingToMiddleMap = true;

            }

           
        
      }

      
}
