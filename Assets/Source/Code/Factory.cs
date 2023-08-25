using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

public class Factory : MonoBehaviour
{
  [SerializeField] private Object _enemyPrefab;

  public void CreateEnemies(List<Transform> spawnPoints)
  {
    foreach (Transform point in spawnPoints)
    {
      Instantiate(_enemyPrefab, point.position, point.rotation, point);
    }
  }
}