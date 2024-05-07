using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static GameStates CurrentGameState;

    public TMP_Text ScoreRed;
    public TMP_Text ScoreBlue;

    public void UpdateScore(BoardID id)
    {
        
    }
}
