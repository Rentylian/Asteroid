using UnityEngine;

public class BorderTeleporter : MonoBehaviour
{

    private float _offsetForTeleportableObject = 1.5f;
    private float _offsetFromBorderScreen = 5f;
    private Vector2 _heading;
    private Vector3 _directionToCenter;
    private BoxCollider2D _boxCollider;
    void Start()
    {
        if(TryGetComponent<BoxCollider2D>(out var col))
            _boxCollider = col;
        CalculateDirectionToCenterOfScreen();
        ToPlaceBorderOnBorderScreenAndSetSize();
        // To shift border from center screen
        transform.position -= _directionToCenter * _offsetFromBorderScreen;
        
    }

    void CalculateDirectionToCenterOfScreen()
    {
        _heading = CameraDataHandler.Instance.CameraPosition - transform.position;
        var distance = _heading.magnitude;
        _directionToCenter = _heading / distance;
    }
    // Use center point for define position border
    void ToPlaceBorderOnBorderScreenAndSetSize()
    {
        // 
        float colliderAdditionalSize = _offsetFromBorderScreen * 2;
        // Right border
        if (transform.position.x > CameraDataHandler.Instance.CameraPosition.x)
        {
            transform.position = new Vector2(CameraDataHandler.Instance.TopRightCornerCamera.x, 
                                                CameraDataHandler.Instance.CameraPosition.y);
            // Collider size includes offset from screen corner
            _boxCollider.size = new Vector2(1, CameraDataHandler.Instance.WidthBetweenCornerY + colliderAdditionalSize);
        }
        // Left border
        if (transform.position.x < CameraDataHandler.Instance.CameraPosition.x)
        {
            transform.position = new Vector2(-CameraDataHandler.Instance.TopRightCornerCamera.x, 
                                                    CameraDataHandler.Instance.CameraPosition.y);
            _boxCollider.size = new Vector2(1, CameraDataHandler.Instance.WidthBetweenCornerY + colliderAdditionalSize);
        }
        // Top border
        if (transform.position.y > CameraDataHandler.Instance.CameraPosition.y)
        {
            transform.position = new Vector2(CameraDataHandler.Instance.CameraPosition.x, 
                                                CameraDataHandler.Instance.TopRightCornerCamera.y);
            _boxCollider.size = new Vector2(CameraDataHandler.Instance.WidthBetweenCornerX + colliderAdditionalSize, 1);
        }
        // Bottom border
        if (transform.position.y < CameraDataHandler.Instance.CameraPosition.y)
        {
            transform.position = new Vector2(CameraDataHandler.Instance.CameraPosition.x,
                                                CameraDataHandler.Instance.BottomLeftCornerCamera.y);
            _boxCollider.size = new Vector2(CameraDataHandler.Instance.WidthBetweenCornerX + colliderAdditionalSize, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<ITeleportable>(out var obj))
        {
            var mirroredPosition = col.transform.position * -1;
            var offsetFromBorder = -_directionToCenter * _offsetForTeleportableObject;
            obj.ToTeleport(mirroredPosition + offsetFromBorder);
        }
    }
}
