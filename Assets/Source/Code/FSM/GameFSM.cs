using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameFSM : MonoBehaviour
{
  private Dictionary<Type, IState> _states;
  private IState _currentState;

  [SerializeField] private Button _startButton;
  [SerializeField] private Canvas _startScreen;
  [SerializeField] private PlayerMoving _playerMoving;
  [SerializeField] private Waypoints _waypoints;
  [SerializeField] private NavMeshAgent _player;
  [SerializeField] private Factory _factory;
  [SerializeField] private PlayerAttack _playerAttack;
  [SerializeField] private Animator _playerAnimator;

  private void OnEnable() => InitStates();

  private void InitStates()
  {
    _states = new Dictionary<Type, IState>
    {
      [typeof(StartState)] = new StartState(_startButton, _startScreen.gameObject, this),
      [typeof(MoveState)] = new MoveState(_playerMoving, _waypoints, _player, this,_playerAnimator),
      [typeof(AttackState)] = new AttackState(_waypoints, this, _factory, _playerAttack,_playerAnimator),
      [typeof(FinishState)] = new FinishState()
    };

    SetDefaultState();
  }

  public void SetState<T>() where T : IState => SetState(GetState<T>());

  public void SetDefaultState() => SetState(GetState<StartState>());

  private void SetState(IState state)
  {
    _currentState?.Exit();
    _currentState = state;
    _currentState.Enter();
  }

  private IState GetState<T>() where T : IState
  {
    var state = typeof(T);
    return _states[state];
  }
}