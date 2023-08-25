using UnityEngine;
using UnityEngine.AI;

public class AttackState : IState
{
  private const string AttackStateAnimation = "AttackState";

  private NavMeshAgent _player;
  private PlayerAttack _playerAttack;
  private int _enemies;
  private int _currentPointIndex = 0;
  private Waypoints _waypoints;
  private Factory _factory;
  private WayPoint _wayPoint;
  private GameFSM _fsm;
  private Animator _animator;

  public AttackState(Waypoints waypoints, GameFSM fsm, Factory factory, PlayerAttack playerAttack, Animator animator)
  {
    _waypoints = waypoints;
    _fsm = fsm;
    _factory = factory;
    _playerAttack = playerAttack;
    _animator = animator;
  }

  public void Enter()
  {
    _animator.SetBool(AttackStateAnimation, true);
    EventBus.Instance.EnemyDie += RemoveTarget;

    _playerAttack.ChangeShootState(true);
    _enemies = _waypoints.transform.GetChild(_currentPointIndex).transform.childCount;
    _wayPoint = _waypoints.transform.GetChild(_currentPointIndex).GetComponent<WayPoint>();
    _factory.CreateEnemies(_wayPoint.SpawnPoints);
  }

  private void RemoveTarget()
  {
    _enemies--;
    if (_enemies <= 0)
    {
      if (_currentPointIndex == _waypoints.transform.childCount - 1)
        _fsm.SetState<FinishState>();
      else
        _fsm.SetState<MoveState>();
    }
  }

  public void Exit()
  {
    _playerAttack.ChangeShootState(false);
    _currentPointIndex++;
    EventBus.Instance.EnemyDie -= RemoveTarget;
  }
}