using UnityEngine;
using System.Collections;

public class PrepareState : MonoBehaviour, IGameState
{
    private byte _currentTime = 0;
    private byte _timeCount = 3;

    public void HandleState(GameStateHandler stateHandler)
    {
        Debug.Log("Current state is: " + this);
        
        StartCoroutine(TimeCount());
    }

    IEnumerator TimeCount()
    {
        while (_currentTime < _timeCount)
        {
            yield return new WaitForSeconds(1f);
            _currentTime++;
        }

        if (_currentTime >= _timeCount)
        {
            //GameStateHandler.EnterControllableState();
            StopCoroutine(TimeCount());
        }
    }
}
