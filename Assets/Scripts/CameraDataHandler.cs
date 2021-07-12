using UnityEngine;

public class CameraDataHandler : MonoBehaviour
{
    private Camera _camera;

    public static CameraDataHandler Instance { get ; private set; }

    public Vector3 CameraPosition { get; private set; }
    public Vector3 TopRightCornerCamera { get; private set; }
    public Vector3 TopLeftCornerCamera { get; private set; }
    public Vector3 BottomLeftCornerCamera { get; private set; }
    public Vector3 BottomRightCornerCamera { get; private set; }
    public float WidthBetweenCornerX { get; private set; }
    public float WidthBetweenCornerY { get; private set; }
    void Awake()
    {
        Instance = this;
        if (TryGetComponent<Camera>(out var camera))
        {
            _camera = camera;
        }
        GetCornerCameraInWorldSpace();
        GetWidthAndHeightScreenInWorldSpace();
    }
    void GetCornerCameraInWorldSpace()
    {
        TopLeftCornerCamera = _camera.ViewportToWorldPoint(new Vector2(0, 1));
        TopRightCornerCamera = _camera.ViewportToWorldPoint(new Vector2(1, 1));
        BottomRightCornerCamera = _camera.ViewportToWorldPoint(new Vector2(1, 0));
        BottomLeftCornerCamera = _camera.ViewportToWorldPoint(new Vector2(0, 0));
        CameraPosition = _camera.transform.position;
    }

    void GetWidthAndHeightScreenInWorldSpace()
    {
        WidthBetweenCornerX = Vector2.Distance(BottomLeftCornerCamera, BottomRightCornerCamera);
        WidthBetweenCornerY = Vector2.Distance(BottomLeftCornerCamera, TopLeftCornerCamera);
    }
}
