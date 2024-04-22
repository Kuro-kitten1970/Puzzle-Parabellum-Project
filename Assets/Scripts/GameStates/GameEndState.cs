using UnityEngine;

public class GameEndState : MonoBehaviour, IGameState
{
    public void HandleState(GameStateHandler stateHandler)
    {
        Debug.Log("Current state is: " + this);
    }
}
