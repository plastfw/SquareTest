using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
  [SerializeField] private List<Rigidbody> _rigidbodies;
  [SerializeField] private List<Collider> _colliders;
  [SerializeField] private Animator _animator;
  [SerializeField] private Collider _collider;

  private void Awake()
  {
    DeactivateRagdoll();
  }

  public void DeactivateRagdoll()
  {
    foreach (var bone in _rigidbodies)
      bone.isKinematic = true;

    foreach (var collider in _colliders)
      collider.enabled = false;
  }

  public void ActivateRagdoll()
  {
    _animator.enabled = false;
    _collider.enabled = false;

    foreach (var bone in _rigidbodies)
      bone.isKinematic = false;

    foreach (var collider in _colliders)
      collider.enabled = true;

    Destroy(gameObject, 2);
  }
}