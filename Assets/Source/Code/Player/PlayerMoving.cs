using System;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
  private static readonly int Speed = Animator.StringToHash("Speed");

  private const float Epsilon = 1.1f;

  public event Action OnPointReached;

  [SerializeField] private Animator _animator;

  private Transform _currentPoint;

  private void Update()
  {
    if (_currentPoint != null)
    {
      var distance = Vector3.Distance(transform.position, _currentPoint.position);

      if (distance < Epsilon)
      {
        _currentPoint = null;
        OnPointReached?.Invoke();
      }
    }

    // SetAnimatorValues();
  }

  public void GetPoint(Transform point) => _currentPoint = point;

  // private void SetAnimatorValues() =>
  //   _animator.SetFloat(Speed, _agent.desiredVelocity.magnitude);
}