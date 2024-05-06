using UnityEngine;

public class StartState : MonoBehaviour, IGameState
{
    public void HandleState(GameStateHandler stateHandler)
    {
        Debug.Log("Current state is: " + this);

        GameManager.CurrentGameState = GameStates.StartState;
    }
}
