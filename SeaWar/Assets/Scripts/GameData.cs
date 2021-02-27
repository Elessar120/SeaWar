using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
  #region singletone
  private static GameData instance;

  public static GameData Instance
  {
    get
    {
      if (instance == null)
      {
        Debug.LogError("instance of game data is null");
      }
      return instance;
    }
  }
  

  #endregion

  public Unit refinery;
  public Unit oilTanker;
  public Unit submarine;
  
 private void Awake()
  {
    instance = this;
  }
}
