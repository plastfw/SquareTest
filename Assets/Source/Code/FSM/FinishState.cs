using UnityEngine.SceneManagement;

public class FinishState : IState
{
  private const string Scene = "Scene";

  public void Enter()
  {
    var scene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(Scene);
  }

  public void Exit()
  {
  }
}