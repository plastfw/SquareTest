using UnityEngine;
using UnityEngine.UI;

public class StartState : IState
{
  private Button _startButton;
  private GameObject _startScreen;
  private GameFSM _fsm;

  public StartState(Button button, GameObject startScreen, GameFSM fsm)
  {
    _startButton = button;
    _startScreen = startScreen;
    _fsm = fsm;
  }

  public void Enter() => _startButton.onClick.AddListener(ClickEvent);

  public void Exit() => _startButton.onClick.RemoveListener(ClickEvent);

  private void ClickEvent()
  {
    _startScreen.SetActive(false);
    _fsm.SetState<MoveState>();
  }
}