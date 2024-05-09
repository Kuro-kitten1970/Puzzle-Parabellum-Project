using UnityEngine;

public class GameEndState : MonoBehaviour, IGameState
{
    private UIManager uiManager;

    public void HandleState(GameStateHandler stateHandler)
    {
        Debug.Log("Current state is: " + this);

        GameManager.CurrentGameState = GameStates.GameEndState;

        GameManager.IsGameEnd = true;

        Time.timeScale = 0f;

        uiManager = FindObjectOfType<UIManager>();
        uiManager.CallGameEndMenu();
    }
}
