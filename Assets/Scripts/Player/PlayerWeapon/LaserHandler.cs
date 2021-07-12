using System.Collections;
using UnityEngine;

public class LaserHandler : MonoBehaviour
{
    [SerializeField] private LaserUI _laserUI;
    [SerializeField] private Laser _laser;
    private float _laserCharge = 100;
    private float _laserRechargeRate = 20f;
    private bool _laserIsCharge = true;
    private float LaserCharge
    {
        get => _laserCharge;
        set
        {
            value = Mathf.Clamp(value, 0, 100);
            _laserCharge = value;
        }
    }

    void Start()
    {
        // Update progress bar laser
        _laserUI.SetLaserProgressBarValue(LaserCharge);
    }


    IEnumerator ToRechargeLaser()
    {
        while (LaserCharge < 100)
        {
            LaserCharge += _laserRechargeRate * Time.deltaTime;
            _laserUI.SetLaserProgressBarValue(LaserCharge);
            yield return null;
        }

        _laserIsCharge = true;
        
    }

    public void ShotLaser()
    {
        if (_laserIsCharge)
        {
            _laser.Shot();
            LaserCharge = 0;
            _laserIsCharge = false;
            StartCoroutine(ToRechargeLaser());
        }
        
    }
}
