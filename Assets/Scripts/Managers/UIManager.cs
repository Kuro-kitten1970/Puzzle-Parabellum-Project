using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject CountDownPrefab;
    [SerializeField] private GameObject PauseUIPrefab;

    public static GameObject GetCountDownUI;
    public static GameObject GetPauseUI;

    private void Start()
    {
        GetCountDownUI = CountDownPrefab;
        GetPauseUI = PauseUIPrefab;
    }

    public static GameObject CreateCountDownUI() => Instantiate(GetCountDownUI);
    public static GameObject CreatePauseUI() => Instantiate(GetPauseUI);

    public void PlayBTN()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    public void ExitBTN() => Application.Quit();

    public void OnSceneChanged(Scene scene1, Scene scene2) => GameStateHandler.EnterState(GameStates.PrepareState);
}
