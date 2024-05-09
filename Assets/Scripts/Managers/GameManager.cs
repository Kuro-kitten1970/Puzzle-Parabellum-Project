using TMPro;
using UnityEngine;

public enum BattleResult
{
    P1Win = 0, P2Win = 1, Draw = 2
}

public class GameManager : Singleton<GameManager>
{
    public static int TimePlay = 60;
    public static int player1_Score;
    public static int player2_Score;

    public static bool IsGameEnd = false;

    public static GameStates CurrentGameState;

    public static void UpdateScore(BoardID id, int score)
    {
        if (id == BoardID.BoardPlayer1)
            player1_Score += score;
        else
            player2_Score += score;
    }

    public static int GetScore(BoardID id)
    {
        if (id == BoardID.BoardPlayer1)
            return player1_Score;
        else
            return player2_Score;
    }

    public static int GetPlayerWin() 
    {
        if (player1_Score > player2_Score)
            return (int)BattleResult.P1Win;
        else if (player2_Score > player1_Score)
            return (int)BattleResult.P2Win;
        else
            return (int)BattleResult.Draw;
    }
}
