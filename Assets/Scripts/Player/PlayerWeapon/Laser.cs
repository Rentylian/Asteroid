using System.Collections;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer _laserLine;
    private float _laserLineLength = 100;
    int _layerMask = 1 << 8 | 1 << 9;
    private Vector2 _positionShot;
    private Vector2 _directionShot;
    void Start()
    {
        _laserLine = GetComponent<LineRenderer>();
    }

    public void Shot()
    {
        // Take position for shot and direction shot from PlayerData
        _positionShot = PlayerData.Instance.Rigidbody.position;
        _directionShot = PlayerData.Instance.Transform.up;
        // Use raycast for detection enemy
        Raycast(_positionShot, _directionShot);
        
        StartCoroutine(DrawLineRend());
    }

    void Raycast(Vector3 positionForShot, Vector3 directionShot)
    {
        RaycastHit2D[] rayhit = Physics2D.RaycastAll(positionForShot,
            directionShot, 50f, _layerMask);
        foreach (var v in rayhit)
        {
            if (v.collider.TryGetComponent<IEnemy>(out var enemy))
            {
                enemy.Destroy();
            }
            
        }
    }

    IEnumerator DrawLineRend()
    {
        // Create laserline by LineRenderer
        _laserLine.SetPosition(0, _positionShot);
        _laserLine.SetPosition(1, _positionShot + (_directionShot) * _laserLineLength);
        float timer = 0;
        while (timer < 1)
        {
            timer += Time.deltaTime * 2;
            // To move start point  of line renderer to end point for creation laser effect
            _laserLine.SetPosition(0, new Vector3(
                                                Mathf.Lerp(_laserLine.GetPosition(0).x,
                                                            _laserLine.GetPosition(1).x,
                                                            timer),
                                                Mathf.Lerp(_laserLine.GetPosition(0).y,
                                                            _laserLine.GetPosition(1).y,
                                                            timer),
                                                0));
            yield return null;
        }

    }
}
