using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class EventsHolder : MonoBehaviour
{
    public delegate void AsteroidDestroyed(Vector2 position); 
    public static event AsteroidDestroyed AsteroidBeenDestroyed;

    public delegate void ScoreIncreased();
    public static event ScoreIncreased ScoreBeenChanged;

    public delegate void PlayerDefeated();
    public static event PlayerDefeated PlayerBeenDefeated;

    public delegate void GamePaused(bool isPauseActive);
    public static event GamePaused GamePauseChangedState;



    public delegate void VisualViewChanged();
    public static event VisualViewChanged VisualViewBeenChanged;

    public static void OnAsteroidBeenDestroyed(Vector2 position)
    {
        AsteroidBeenDestroyed?.Invoke(position);
    }

    public static void OnScoreBeenIncreased()
    {
        ScoreBeenChanged?.Invoke();
    }

    public static void OnPlayerBeenDefeated()
    {
        PlayerBeenDefeated?.Invoke();
    }

    public static void OnGamePauseChangedState(bool isPauseActive)
    {
        GamePauseChangedState?.Invoke(isPauseActive);
    }

    public static void OnVisualViewBeenChanged()
    {
        VisualViewBeenChanged?.Invoke();
    }

}
