using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private int _poolCount = 6;
    [SerializeField] private Bullet _prefab;


    private Pool<Bullet> _bulletPool;


    private void Start()
    {
        _bulletPool = new Pool<Bullet>(_prefab, _poolCount, transform);
    }

    public void ToPlaceObject(Vector2 position)
    {
        var bullet = _bulletPool.GetFreeElement();
        bullet.Rigidbody.position = position;
    }

}
