using UnityEngine;

public class PlayState : MonoBehaviour, IGameState
{
    public void HandleState(GameStateHandler stateHandler)
    {
        Debug.Log("Current state is: " + this);

        GameManager.CurrentGameState = GameStates.PlayState;
    }
}
