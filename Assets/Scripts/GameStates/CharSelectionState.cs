using UnityEngine;

public class CharSelectionState : MonoBehaviour, IGameState
{
    public void HandleState(GameStateHandler stateHandler)
    {
        Debug.Log("Current state is: " + this);
    }
}
