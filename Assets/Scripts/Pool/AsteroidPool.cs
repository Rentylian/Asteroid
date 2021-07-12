using UnityEngine;

public class AsteroidPool : MonoBehaviour, IEnemyPool
{

    [SerializeField] private Asteroid _prefab;
    [SerializeField] private int _poolSize = 8;

    private Pool<Asteroid> _asteroidPool;

    public GameObject Gameobject { get; private set; }

    private void Awake()
    {
        _asteroidPool = new Pool<Asteroid>(_prefab, _poolSize, transform);
        Gameobject = gameObject;
    }

    public int GetPoolSize()
    {
        return _asteroidPool.GetPoolSize();
    }

    public int GetActiveElements()
    {

        return _asteroidPool.GetActiveElementsCount();
        
    }

    public void ToPlaceObject(Vector2 position)
    {
        var asteroid = _asteroidPool.GetFreeElement();
        asteroid.Rigidbody.position = position;
    }
}
