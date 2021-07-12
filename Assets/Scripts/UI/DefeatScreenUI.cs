using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatScreenUI : MonoBehaviour
{

    [SerializeField] private GameObject _containerDefeatScreen;

    void OnEnable()
    {
        EventsHolder.PlayerBeenDefeated += ShowDefeatScreen;
    }
    void OnDisable()
    {
        EventsHolder.PlayerBeenDefeated -= ShowDefeatScreen;
    }

    void ShowDefeatScreen()
    {
        Time.timeScale = 0;
        _containerDefeatScreen.SetActive(true);
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
