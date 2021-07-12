using System.Text;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    private StringBuilder _stringBuilder = new StringBuilder("Score: 0");


    public void UpdateScoreText(int score)
    {
        _stringBuilder.Clear();
        _stringBuilder.Append("Score: " + score);
        _scoreText.text = _stringBuilder.ToString();
    }

}
