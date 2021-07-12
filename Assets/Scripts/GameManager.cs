using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemySpawnManager _spawnManager;

    public static GameManager Instance { get; private set; }
    public bool GameIsPause { get; private set; } = true;

    public enum VisualView
    {
        Polygonal,
        Sprite
    }

    public VisualView CurrentView { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        EventsHolder.VisualViewBeenChanged += ToChangeVisualView;
        EventsHolder.GamePauseChangedState += ToChangePauseState;
    }
    void OnDisable()
    {
        EventsHolder.VisualViewBeenChanged -= ToChangeVisualView;
        EventsHolder.GamePauseChangedState -= ToChangePauseState;
    }


    void ToChangePauseState(bool state)
    {
        GameIsPause = state;
    }

    void ToChangeVisualView()
    {
        if (CurrentView == VisualView.Sprite)
            CurrentView = VisualView.Polygonal;
        else if (CurrentView == VisualView.Polygonal)
            CurrentView = VisualView.Sprite;
    }

    public void ToStartGame()
    {
        ToChangePauseState(false);
        _spawnManager.gameObject.SetActive(true);
    }
}
