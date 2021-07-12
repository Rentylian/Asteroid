using UnityEngine;

public class AlienPool : MonoBehaviour, IEnemyPool
{

    [SerializeField] private Alien _prefab;
    [SerializeField] private int _poolSize = 2;

    private Pool<Alien> _alienPool;

    public GameObject Gameobject { get; private set; }
    private void Awake()
    {
        _alienPool = new Pool<Alien>(_prefab, _poolSize, transform);
        Gameobject = gameObject;
    }


    public int GetPoolSize()
    {
        return _alienPool.GetPoolSize();
    }

    public int GetActiveElements()
    {
        return _alienPool.GetActiveElementsCount();
    }

    public void ToPlaceObject(Vector2 position)
    {
        var alien = _alienPool.GetFreeElement();
        alien.Rigidbody.position = position;
    }
}
