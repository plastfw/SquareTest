using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
  private List<Transform> _enemySpawnPoints = new List<Transform>();

  public List<Transform> SpawnPoints => _enemySpawnPoints;

  private void OnValidate()
  {
    foreach (Transform SpawnPoint in transform)
      _enemySpawnPoints.Add(SpawnPoint);
  }
}