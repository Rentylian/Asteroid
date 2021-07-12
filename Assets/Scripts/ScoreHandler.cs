using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private ScoreUI _scoreUI;
    [SerializeField] private ScoreUI _scoreUIDefeatScreen;
    private int _score;
    void OnEnable()
    {
        EventsHolder.ScoreBeenChanged += ToUpdateScore;
    }
    void OnDisable()
    {
        EventsHolder.ScoreBeenChanged -= ToUpdateScore;
    }

    void ToUpdateScore()
    {
        IncreaseScore();
        _scoreUI.UpdateScoreText(_score);
        _scoreUIDefeatScreen.UpdateScoreText(_score);
    }

    void IncreaseScore()
    {
        _score += 10;
    }

}
