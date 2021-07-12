using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement _playerMovement;
    [SerializeField]
    private LaserHandler _laserController;
    [SerializeField]
    private BulletPool _bulletPool;
    void Update()
    {
        if (!GameManager.Instance.GameIsPause)
        {
            ToCheckMovementInput();
            ToCheckRotationInput();
            ToCheckWeaponInput();
        }
    }

    void ToCheckRotationInput()
    {
        // Use "horizontal" axis for direction rotation
        _playerMovement.RotateShip(Input.GetAxis("Horizontal"));
    }

    void ToCheckMovementInput()
    {
        
        if (Input.GetAxis("Vertical") > 0)
        {
            _playerMovement.MoveShip();
        }
    }
    void ToCheckWeaponInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _bulletPool.ToPlaceObject(PlayerData.Instance.Rigidbody.position);
        }

        if (Input.GetMouseButtonDown(1))
        {
           _laserController.ShotLaser();
        }
    }
}
