using System.Text;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LaserUI : MonoBehaviour
{

    [SerializeField] private Image _progressBarImage;
    [SerializeField] private TextMeshProUGUI _progressBarPercentText;
    private StringBuilder _percentProgressBar = new StringBuilder();
    
    public void SetLaserProgressBarValue(float value)
    {
        _progressBarImage.fillAmount = value / 100f;
        _percentProgressBar.Clear();
        _percentProgressBar.Append((int)value + "%");
        _progressBarPercentText.text = _percentProgressBar.ToString();
    }
}
