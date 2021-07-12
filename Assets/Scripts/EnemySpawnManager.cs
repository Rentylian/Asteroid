using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _poolsContainer;

    private IEnemyPool[] _poolsWithEnemy = new IEnemyPool[3];
    private List<IEnemyPool> _respawnObjects = new List<IEnemyPool>();
    private IEnemyPool _asteroidFragmentPool;

    private float _distanceBetweenSpawningObjectAndPlayer = 20f;

    [SerializeField] private float _timeForRespawnObjects = 2;
    [SerializeField] private float _timeForSpawnObjects = 20;
    void Start()
    {
        // Get all pool with container
        _poolsWithEnemy = _poolsContainer.GetComponentsInChildren<IEnemyPool>(_poolsContainer);
        // Find asteroid fragment pool
        foreach (var v in _poolsWithEnemy)
        {
            if (v.Gameobject.gameObject.TryGetComponent<AsteroidFragmentPool>(out var asteroidFragment))
                _asteroidFragmentPool = v;
        }
        
        _respawnObjects = _poolsWithEnemy.ToList();
        // Delete pool asteroidFragment because it have special condition for spawning
        _respawnObjects.Remove(_asteroidFragmentPool);

        StartCoroutine(RespawnEnemyAtTimeIntervals());
        StartCoroutine(SpawnNewEnemyAtTimeIntervals());
    }
    IEnumerator SpawnNewEnemyAtTimeIntervals()
    {
        // Set time interval for placement object from pool
        yield return new WaitForSeconds(_timeForSpawnObjects);
        // Place all object in pool for expand the pool
        ToPlaceObjectsInPool();
        // Choosing a random pool
        int randomPool = Random.Range(0, _respawnObjects.Count);
        // Spawn new element from random pool
        _respawnObjects[randomPool].ToPlaceObject(PositionForPlacedObject());
        // Loop  coroutine 
        yield return StartCoroutine(SpawnNewEnemyAtTimeIntervals());
    }

    IEnumerator RespawnEnemyAtTimeIntervals()
    {
        // Set time interval for placement object from pool
        yield return new WaitForSeconds(_timeForRespawnObjects);
        ToPlaceObjectsInPool();
        // Loop  coroutine 
        yield return StartCoroutine(RespawnEnemyAtTimeIntervals());
    }

    void ToPlaceObjectsInPool()
    {
        foreach (var poolObject in _respawnObjects)
        {
            // Place all inactive object in pool
            while (PoolHaveInactiveEnemies(poolObject))
            {
                poolObject.ToPlaceObject(PositionForPlacedObject());
            }
        }
    }

    bool PoolHaveInactiveEnemies(IEnemyPool pool)
    {
        // if less items active than the base pool size
        if (pool.GetPoolSize() > pool.GetActiveElements())
        {
            return true;
        }

        return false;
    }
    Vector2 PositionForPlacedObject()
    {
        float positionObjectX = Random.Range(CameraDataHandler.Instance.BottomLeftCornerCamera.x, 
                                                CameraDataHandler.Instance.BottomRightCornerCamera.x);
        float positionObjectY = Random.Range(CameraDataHandler.Instance.TopLeftCornerCamera.y, 
                                                CameraDataHandler.Instance.TopRightCornerCamera.y);
        Vector2 randomPosition = new Vector2(positionObjectX, positionObjectY);
        // New object not should spawn close to Player
        if (Vector2.Distance(randomPosition, PlayerData.Instance.Rigidbody.position) <
            _distanceBetweenSpawningObjectAndPlayer)
        {
            return PositionForPlacedObject();
        }
        return randomPosition;

    }

    void OnEnable()
    {
        EventsHolder.AsteroidBeenDestroyed += PlaceAsteroidFragment;
    }
    void OnDisable()
    {
        EventsHolder.AsteroidBeenDestroyed -= PlaceAsteroidFragment;
    }

    // Use for to placed fragment 
    void PlaceAsteroidFragment(Vector2 position)
    {
        // Generate random count fragment
        int random = Random.Range(1, 4);
        float offsetFromCenterObject = 0.2f;

        for (int i = 0; i < random; i++)
        {
            _asteroidFragmentPool.ToPlaceObject(PositionObjectWithOffset(position, offsetFromCenterObject));
        }
    }

    // Return position object indented from sented position 
    Vector2 PositionObjectWithOffset(Vector2 position, float range)
    {
        float xPos = position.x + Random.Range(-range, range);
        float yPos = position.y + Random.Range(-range, range);
        return new Vector2(xPos, yPos);
    }





}
