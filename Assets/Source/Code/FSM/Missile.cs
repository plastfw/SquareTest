using UnityEngine;

public class Missile : MonoBehaviour
{
  [SerializeField] private Rigidbody _rigidbody;
  [SerializeField] private float _speed;

  private float _damage = .5f;

  private void OnCollisionEnter(Collision collision)
  {
    gameObject.SetActive(false);
    transform.position = Vector3.zero;

    if (collision.gameObject.TryGetComponent(out EnemyHealth health))
      health.TakeDamage(_damage);
  }

  public void Move(Vector3 direction) => _rigidbody.velocity = direction * _speed;
}