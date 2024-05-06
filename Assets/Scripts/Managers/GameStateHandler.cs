using UnityEngine;

public enum GameStates
{
    StartState, PrepareState, PlayState, StopState, GameEndState
}

public class GameStateHandler : Singleton<GameStateHandler>
{
    public static IGameState _startState, _prepareState, _playState, _stopState, _gameEndState;
    private static GameStateContext _stateContext;

    private void Start()
    {
        _stateContext = gameObject.AddComponent<GameStateContext>();

        _startState = gameObject.AddComponent<StartState>();
        _prepareState = gameObject.AddComponent<PrepareState>();

        _stateContext.Transition(_startState);
    }

    public static void EnterState(GameStates state)
    {
        switch (state)
        {
            case GameStates.StartState:
                _stateContext.Transition(_startState);
                break;
            case GameStates.PrepareState:
                _stateContext.Transition(_prepareState);
                break;
            case GameStates.PlayState:
                _stateContext.Transition(_playState);
                break;
            case GameStates.StopState:
                _stateContext.Transition(_stopState);
                break;
            case GameStates.GameEndState:
                _stateContext.Transition(_gameEndState);
                break;
            default:
                Debug.Log("Error Cannot Apply State.");
                break;
        }
    }
}