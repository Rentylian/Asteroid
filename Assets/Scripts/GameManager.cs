using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemySpawnManager _spawnManager;

    public static GameManager Instance { get; private set; }
    public bool GameIsPause { get; private set; } = true;


    void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        EventsHolder.GamePauseChangedState += ToChangePauseState;
    }
    void OnDisable()
    {
        EventsHolder.GamePauseChangedState -= ToChangePauseState;
    }


    void ToChangePauseState(bool state)
    {
        GameIsPause = state;
    }


    public void ToStartGame()
    {
        ToChangePauseState(false);
        _spawnManager.gameObject.SetActive(true);
    }
}
