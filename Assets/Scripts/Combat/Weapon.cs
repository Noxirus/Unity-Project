using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int maxAmmo;
    private int _currentAmmo;
    [SerializeField] private float fireRate = .2f;
    [SerializeField] private bool bAutomatic = false;
    [SerializeField] protected Transform muzzle;

    private void Start()
    {
        _currentAmmo = maxAmmo;
    }

    virtual public void Fire()
    {
        _currentAmmo--;
        // Start shooting cooldown
        // Play sound effect
        // Spawn particle at muzzle location
    }

    protected bool CanShoot()
    {
        return _currentAmmo > 0;
    }
}
