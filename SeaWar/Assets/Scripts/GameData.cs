using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : ScriptableObject
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
                                                                                                                                       
  public float storedOil;
  public float productionRate;
  private void Awake()
  {
    instance = this;
  }
}
