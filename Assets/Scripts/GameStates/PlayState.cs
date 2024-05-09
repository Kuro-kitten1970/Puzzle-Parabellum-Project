using System.Collections;
using UnityEngine;

public class PlayState : MonoBehaviour, IGameState
{
    private UIManager uiManager;

    public void HandleState(GameStateHandler stateHandler)
    {
        Debug.Log("Current state is: " + this);

        GameManager.CurrentGameState = GameStates.PlayState;

        uiManager = FindObjectOfType<UIManager>();

        StartCoroutine(TimeCount());
    }

    IEnumerator TimeCount()
    {
        int currentTimeCount = GameManager.TimePlay;

        while (0 <= currentTimeCount)
        {
            uiManager.UpdateTimer(currentTimeCount.ToString());
            yield return new WaitForSeconds(1f);
            currentTimeCount--;
        }

        if (currentTimeCount < 0)
        {           
            GameStateHandler.EnterState(GameStates.GameEndState);

            StopCoroutine(TimeCount());
        }
    }
}
