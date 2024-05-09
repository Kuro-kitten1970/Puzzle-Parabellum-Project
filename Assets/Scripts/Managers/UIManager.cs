using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMP_Text TimerText;
    public TMP_Text P1_winText;
    public TMP_Text P2_winText;

    private void Start()
    {
        TimerText.text = GameManager.TimePlay.ToString();
    }

    public void CallGameEndMenu()
    {
        if (GameManager.GetPlayerWin() == 0)
        {
            P1_winText.text = "WIN!";
            P1_winText.color = Color.green;

            P2_winText.text = "LOSE!";
            P2_winText.color = Color.red;
        }
        else if (GameManager.GetPlayerWin() == 1)
        {
            P1_winText.text = "LOSE!";
            P1_winText.color = Color.red;

            P2_winText.text = "WIN!";
            P2_winText.color = Color.green;
        }
        else
        {
            P1_winText.text = "DRAW";
            P1_winText.color = Color.yellow;

            P2_winText.text = "DRAW";
            P2_winText.color = Color.yellow;
        }
    }

    public void UpdateTimer(string time) => TimerText.text = time;
}
