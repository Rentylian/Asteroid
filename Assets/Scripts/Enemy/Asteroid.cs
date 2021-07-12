using UnityEngine;

public class Asteroid : MonoBehaviour, IEnemy, ITeleportable
{
    [SerializeField] private Rigidbody2D _rd;
    [SerializeField] private float _speedFly;
    public Rigidbody2D Rigidbody => _rd;

    void OnEnable()
    {
        Move();
    }

    private void Move()
    {
        var directionFly = StaticFunctions.GetRandomDirection();
        _rd.velocity = directionFly * _speedFly;
    }
    public void Destroy()
    {
        gameObject.SetActive(false);
        EventsHolder.OnScoreBeenIncreased();
    }

    public void DestroyWithFragmentCreation()
    {
        // Call event for creation fragmentAsteroid
        EventsHolder.OnAsteroidBeenDestroyed(_rd.position);
        // And apply usual logic for destroy 
        Destroy();
    }

    public void ToTeleport(Vector2 position)
    {
        _rd.position = position;
    }
}
