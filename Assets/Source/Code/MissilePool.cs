using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MissilePool : MonoBehaviour
{
  [SerializeField] private int _size;
  [SerializeField] private Missile _missile;

  private List<Missile> _missiles = new List<Missile>();

  private void Awake() => CreatePool();

  private void CreatePool()
  {
    for (int i = 0; i < _size; i++)
    {
      var missile = Instantiate(_missile, transform.position, Quaternion.identity, transform);
      _missiles.Add(missile);
    }
  }

  public Missile GetMissile() => _missiles.First(p => p.gameObject.activeSelf == false);
}