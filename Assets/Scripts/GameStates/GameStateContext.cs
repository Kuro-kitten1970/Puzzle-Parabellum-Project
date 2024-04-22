using UnityEngine;

public class GameStateContext : MonoBehaviour
{
    public IGameState CurrentGameState { get; set; }

    private readonly GameStateHandler _stateHandler;

    public GameStateContext(GameStateHandler stateHandler)
        => _stateHandler = stateHandler;

    public void Transition()
        => CurrentGameState.HandleState(_stateHandler);

    public void Transition(IGameState gameState)
    {
        CurrentGameState = gameState;
        CurrentGameState.HandleState(_stateHandler);
    }
}
