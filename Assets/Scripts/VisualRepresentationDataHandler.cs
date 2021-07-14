using UnityEngine;

public class VisualRepresentationDataHandler : MonoBehaviour
{

    public static VisualRepresentationDataHandler Instance { get; private set; }


    public enum VisualView
    {
        Polygonal,
        Sprite
    }

    public VisualView CurrentView { get; private set; } = VisualView.Sprite;


    void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        EventsHolder.VisualViewBeenChanged += ToChangeVisualView;
    }
    void OnDisable()
    {
        EventsHolder.VisualViewBeenChanged -= ToChangeVisualView;
    }


    void ToChangeVisualView()
    {
        if (CurrentView == VisualView.Sprite)
            CurrentView = VisualView.Polygonal;
        else if (CurrentView == VisualView.Polygonal)
            CurrentView = VisualView.Sprite;
    }
}
