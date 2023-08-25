using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
  [SerializeField] private Image _image;

  public event Action IsDead;

  private float _currentHealth;

  private void Awake()
  {
    _currentHealth = _image.fillAmount;
  }

  public void TakeDamage(float damage)
  {
    _currentHealth -= damage;
    _image.fillAmount = _currentHealth;
    if (_currentHealth <= 0)
      IsDead?.Invoke();
  }
}