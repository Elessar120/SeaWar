﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   private static GameManager instance;

   public static GameManager Instance
   {
      get
      {
         if (instance == null)
         {
            instance = FindObjectOfType<GameManager>();
         }

         return instance;
      }
   }
   public GameObject middleMap;
   public Transform rightOutPoint;
   public Transform leftOutPoint;
   
}
