using UnityEngine;
using System.Collections;
using TMPro;

public class PrepareState : MonoBehaviour, IGameState
{
    private int _timeCount = 3;

    private TMP_Text _text;
    private GameObject obj;

    public void HandleState(GameStateHandler stateHandler)
    {
        Debug.Log("Current state is: " + this);

        GameManager.CurrentGameState = GameStates.PrepareState;

        obj = UIManager.CreateCountDownUI();

        _text = obj.GetComponentInChildren<TMP_Text>();

        StartCoroutine(TimeCount());
    }

    IEnumerator TimeCount()
    {
        while (0 <= _timeCount)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log(_timeCount);
            _timeCount--;
            _text.text = _timeCount == 0 ? "FIGHT!" : _timeCount.ToString();
        }

        if (_timeCount < 0)
        {
            GameStateHandler._playState = gameObject.AddComponent<PlayState>();
            GameStateHandler._stopState = gameObject.AddComponent<StopState>();
            GameStateHandler._gameEndState = gameObject.AddComponent<GameEndState>();

            GameStateHandler.EnterState(GameStates.PlayState);
            
            Destroy(obj);
            StopCoroutine(TimeCount());
        }
    }
}
