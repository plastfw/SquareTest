using System;
using UnityEngine;

public class EventBus
{
  public  Action EnemyDie;

  private static EventBus _instance;
  
  public static EventBus Instance
  {
    get
    {
      if (_instance == null)
        _instance = new EventBus();

      return _instance;
    }
  }

}