using UnityEngine;

public class VisualRepresentation : MonoBehaviour
{

    [SerializeField] private GameObject _polygonalView;
    [SerializeField] private GameObject _spriteView;

    
    void OnEnable()
    {
        // Change visual view by event
        EventsHolder.VisualViewBeenChanged += SetCurrentView;
        // Set visual view when object became active
        SetCurrentView();
    }
    void OnDisable()
    {
        EventsHolder.VisualViewBeenChanged -= SetCurrentView;
    }

    void SetCurrentView()
    {
        if (VisualRepresentationDataHandler.Instance.CurrentView == VisualRepresentationDataHandler.VisualView.Polygonal)
            ChangeVisualToPolygonalView();
        else
            ChangeVisualView();
    }

    void ChangeVisualView()
    {
        _polygonalView.gameObject.SetActive(false);
        _spriteView.gameObject.SetActive(true);
    }
    void ChangeVisualToPolygonalView()
    {
        _polygonalView.gameObject.SetActive(true);
        _spriteView.gameObject.SetActive(false);
    }

}
