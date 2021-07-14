using UnityEngine;

public interface ITeleportable
{
    void ToTeleport(Vector2 position);
}

public interface IEnemy
{
    void Destroy();
}

public interface IEnemyPool
{
    GameObject Gameobject { get; }
    int GetPoolSize();
    int GetActiveElements();
    void ToPlaceObject(Vector2 position);
}

