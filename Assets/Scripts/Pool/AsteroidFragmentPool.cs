using UnityEngine;

public class AsteroidFragmentPool : MonoBehaviour, IEnemyPool
{

  
    [SerializeField] private AsteroidFragment _prefab;
    [SerializeField] private int _poolSize = 20;


    private Pool<AsteroidFragment> _asteroidFragmentPool;

    public GameObject Gameobject { get; private set; }

    private void Awake()
    {
        _asteroidFragmentPool = new Pool<AsteroidFragment>(_prefab, _poolSize, transform);
        Gameobject = gameObject;

    }

    public int GetPoolSize()
    {
        return _asteroidFragmentPool.GetPoolSize();
    }

    public int GetActiveElements()
    {
        return _asteroidFragmentPool.GetActiveElementsCount();
    }

   
    public void ToPlaceObject(Vector2 position)
    {
        //Debug.Log("place AsteroidFragment");
        var asteroidFragment = _asteroidFragmentPool.GetFreeElement();
        asteroidFragment.Rigidbody.position = position;
    }
}
