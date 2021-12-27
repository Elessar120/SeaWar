using System;
using UnityEngine;

namespace AMVCC.Models
{
    public class SeaWarOilTankerModel : SeaWarElement
    {
        public float rotateSpeed;
        public GameObject middleMap;
        public Transform rightOutPoint;
        public Transform leftOutPoint;
        public float movmentSpeed;
        public float health;
        public Unit oilTankerData;
        public int middleMaplayerMask;
        public float cost;

        private void Awake()
        {
            movmentSpeed = oilTankerData.movmentSpeed;
            rotateSpeed = oilTankerData.rotateSpeed;
            health = oilTankerData.health;
            cost = oilTankerData.costWithOil;
        }

        private void Start()
        {
            middleMaplayerMask = LayerMask.GetMask ("MiddleMap");
           

        }
      

  
    }
    
    
}