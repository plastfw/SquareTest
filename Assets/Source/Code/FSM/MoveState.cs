using UnityEngine;
using UnityEngine.AI;

public class MoveState : IState
{
  private const string AttackStateAnimation = "AttackState";

  private PlayerMoving _playerMoving;
  private Waypoints _waypoints;
  private NavMeshAgent _player;
  private GameFSM _fsm;
  private Transform _currentPoint;
  private Animator _animator;

  public MoveState(PlayerMoving playerMoving, Waypoints waypoints, NavMeshAgent player, GameFSM fsm, Animator animator)
  {
    _playerMoving = playerMoving;
    _waypoints = waypoints;
    _player = player;
    _fsm = fsm;
    _animator = animator;
  }

  public void Enter()
  {
    _animator.SetBool(AttackStateAnimation,false);
      _currentPoint = _waypoints.GetPoint(_currentPoint);

    if (_currentPoint != null)
    {
      _player.SetDestination(_currentPoint.position);
      _playerMoving.GetPoint(_currentPoint);
      _playerMoving.OnPointReached += OnPoint;
    }
  }

  public void Exit() => _playerMoving.OnPointReached -= OnPoint;

  private void OnPoint()
  {
    if (_currentPoint != null)
      _fsm.SetState<AttackState>();
    else
      _fsm.SetState<FinishState>();
  }
}