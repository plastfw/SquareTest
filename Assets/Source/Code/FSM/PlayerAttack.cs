using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
  [SerializeField] private Factory _factory;
  [SerializeField] private Transform _missileSpawnPoint;
  [SerializeField] private MissilePool _pool;

  private Camera _camera;
  private bool _canShoot = false;

  private void Start() => _camera = Camera.main;

  private void Update()
  {
    if (_canShoot)
    {
      if (Input.GetMouseButtonDown(0))
        Shoot();
    }
  }

  public void ChangeShootState(bool state) => _canShoot = state;

  private void Shoot()
  {
    Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit ray);

    Vector3 bulletSpawnPoint = _missileSpawnPoint.position;
    Vector3 shootDirection = (ray.point - bulletSpawnPoint).normalized;


    Missile currentMissile = _pool.GetMissile();
    currentMissile.transform.position = _missileSpawnPoint.position;
    currentMissile.gameObject.SetActive(true);
    currentMissile.Move(shootDirection);
  }
}