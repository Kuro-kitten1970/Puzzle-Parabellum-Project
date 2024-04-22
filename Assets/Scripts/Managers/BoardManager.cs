using UnityEngine;

public class BoardManager : Singleton<BoardManager>
{
    public static GameBoard gameBoard_1;
    public static GameBoard gameBoard_2;

    public AnimationClip[] animationClips;

    private void Start()
    {
        GameBoard[] findGameBoard = FindObjectsOfType<GameBoard>();

        foreach (GameBoard board in findGameBoard)
        {
            switch (board.BoardID)
            {
                case BoardID.BoardPlayer1:
                    gameBoard_1 = board;
                    break;
                case BoardID.BoardPlayer2:
                    gameBoard_2 = board;
                    break;
                default: Debug.Log("Error BoardId is not valid"); break;
            }
        }
    }

    public static GameBoard GetBoard(BoardID id)
    {
        if (id == gameBoard_1.BoardID)
            return gameBoard_1;
        else
            return gameBoard_2;
    }

    private void AnimationController()
    {
        foreach (AnimationClip clip in animationClips)
        {
            if (clip != null)
                GetComponent<Animator>().Play(clip.name);            
        }
    }
}
