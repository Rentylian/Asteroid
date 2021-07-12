using UnityEngine;

public class Alien : MonoBehaviour, IEnemy, ITeleportable
{
    [SerializeField] private Rigidbody2D _rd;

    [SerializeField] private float _speedFly = 0.15f;

    public Rigidbody2D Rigidbody => _rd;

    public void Move()
    {
        _rd.MovePosition(Vector2.MoveTowards(_rd.position, PlayerData.Instance.Rigidbody.position, _speedFly)); 
    }
    void Update()
    {
        Move();
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
