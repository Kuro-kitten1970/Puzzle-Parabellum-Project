using UnityEngine;

public class StopState : MonoBehaviour, IGameState
{
    public void HandleState(GameStateHandler stateHandler)
    {
        Debug.Log("Current state is: " + this);

        GameManager.CurrentGameState = GameStates.StopState;
    }
}
