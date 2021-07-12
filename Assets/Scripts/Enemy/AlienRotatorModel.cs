using UnityEngine;

public class AlienRotatorModel : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(PlayerData.Instance.Transform);       
    }
}
