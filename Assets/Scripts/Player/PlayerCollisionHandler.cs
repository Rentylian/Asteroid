using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<IEnemy>(out var enemy))
        {
            EventsHolder.OnPlayerBeenDefeated();
        }
    }

}
