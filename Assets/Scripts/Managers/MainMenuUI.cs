using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void PlayBTN()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    public void ExitBTN() => Application.Quit();

    public void OnSceneChanged(Scene scene1, Scene scene2) => GameStateHandler.EnterState(GameStates.PlayState);
}
