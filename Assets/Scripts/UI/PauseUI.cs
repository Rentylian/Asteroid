using UnityEngine;
public class PauseUI : MonoBehaviour
{
    [SerializeField] private GameObject _containerPauseScreen;
    public void CallPauseScreen(bool active)
    {
        Time.timeScale = active ? 0 : 1;
        _containerPauseScreen.SetActive(active);
        EventsHolder.OnGamePauseChangedState(active);
    }


    public void ChangeVisualViewButton()
    {
        EventsHolder.OnVisualViewBeenChanged();
    }

}
