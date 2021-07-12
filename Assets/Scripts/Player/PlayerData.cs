using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public Rigidbody2D Rigidbody
    {
        get ;
        private set;
    }

    public Transform Transform
    {
        get;
        private set;
    }
    public static PlayerData Instance
    {
        get;
        private set;
    }

    void Awake()
    {
        Instance = this;
        Rigidbody = GetComponent<Rigidbody2D>();
        Transform = GetComponent<Transform>();
    }
}
