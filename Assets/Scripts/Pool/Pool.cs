using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    public T prefab { get; }
    public Transform container { get; }

    private List<T> _pool;
    private Vector2 _spawnPoint = new Vector2(1000, 1000);
    public Pool(T prefab, int count, Transform container = null)
    {
        this.prefab = prefab;
        this.container = container;
        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        _pool = new List<T>();
        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActive = false)
    {
        var createdObject = Object.Instantiate(prefab, container);
        createdObject.transform.position = _spawnPoint;
        createdObject.gameObject.SetActive(isActive);
        _pool.Add(createdObject);
        return createdObject;
    }

    private bool HasFreeElement(out T freeElement)
    {
        foreach (var element in _pool)
        {
            if (!element.gameObject.activeInHierarchy)
            {
                freeElement = element;
                element.transform.position = _spawnPoint;
                element.gameObject.SetActive(true);
                return true;
            }
        }

        freeElement = null;
        return false;
    }

    public int GetPoolSize()
    {
        return _pool.Count;
    }

    public int GetActiveElementsCount()
    {
        return _pool.FindAll(x => x.gameObject.activeInHierarchy).Count;
    }

    public T GetFreeElement(bool elementEnabled = true)
    {
        if (HasFreeElement(out var freeElement))
            return freeElement;
        else
        {
            return CreateObject(elementEnabled);
        }
    }
}
