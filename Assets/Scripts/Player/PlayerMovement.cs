using UnityEngine;

public class PlayerMovement : MonoBehaviour, ITeleportable
{
    private PlayerData playerData;
    [SerializeField] private float _rotationSpeed = 2f;
    [SerializeField] private float _movementSpeed = 2f;
    private float _maxSpeed = 10;
    void Awake()
    {
        if(TryGetComponent<PlayerData>(out var data))
        {
            playerData = data;
        }
    }


    public void RotateShip(float directionRotation)
    {

        playerData.Rigidbody.MoveRotation(playerData.Rigidbody.rotation + _rotationSpeed * -directionRotation);
    }
    public void MoveShip()
    {
        // Limit max speed ship by velocity
        playerData.Rigidbody.velocity = new Vector2(Mathf.Clamp(playerData.Rigidbody.velocity.x, 
                                                                    -_maxSpeed, 
                                                                    _maxSpeed),
                                                    Mathf.Clamp(playerData.Rigidbody.velocity.y, 
                                                                    -_maxSpeed, 
                                                                    _maxSpeed));
        playerData.Rigidbody.AddForce(transform.up * _movementSpeed);
        
    }

    public void ToTeleport(Vector2 position)
    {
        playerData.Rigidbody.position = position;
    }
}
