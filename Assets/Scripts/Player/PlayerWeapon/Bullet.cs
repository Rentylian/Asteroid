using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rd;
    [SerializeField] private float _speedBullet = 50;


    public Rigidbody2D Rigidbody => _rd;
    
    void OnEnable()
    {
        Shot();
        StartCoroutine(DisableObject());
    }

    IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
    void Shot()
    {
        _rd.AddForce(_speedBullet * PlayerData.Instance.transform.up, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<IEnemy>(out var enemy))
        {
            // To call special conditions of destruction
            if (col.TryGetComponent<Asteroid>(out var asteroid))
            {
                asteroid.DestroyWithFragmentCreation();
            }
            else
            {
                enemy.Destroy();
            }
        }
        // Disable object after any collision
        gameObject.SetActive(false);
    }
}
