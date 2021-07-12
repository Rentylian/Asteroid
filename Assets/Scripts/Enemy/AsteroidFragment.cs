using UnityEngine;

public class AsteroidFragment : MonoBehaviour, IEnemy, ITeleportable
{
    [SerializeField] private Rigidbody2D _rd;
    [SerializeField] private float _speedFly = 8f;

    public Rigidbody2D Rigidbody => _rd;

    void OnEnable()
    {
        Move();
    }

    private void Move()
    {
        // Use normalize for same speed on all objects
        var directionFly = StaticFunctions.GetRandomDirection();
        _rd.AddForce(directionFly * _speedFly, ForceMode2D.Impulse);
    }
    
    public void Destroy()
    {
        gameObject.SetActive(false);
        EventsHolder.OnScoreBeenIncreased();
    }

    public void ToTeleport(Vector2 position)
    {
        _rd.position = position;
    }
}
