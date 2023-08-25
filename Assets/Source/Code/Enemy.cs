using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField] private Ragdoll _ragdoll;
  private EnemyHealth _health;

  private void OnEnable()
  {
    _health = GetComponent<EnemyHealth>();
    _health.IsDead += Die;
  }

  private void OnDisable() => _health.IsDead -= Die;

  public void Die()
  {
    EventBus.Instance.EnemyDie?.Invoke();
    ActivateRagdoll();
  }

  private void ActivateRagdoll() => _ragdoll.ActivateRagdoll();
}