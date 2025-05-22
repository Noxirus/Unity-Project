using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Details")]
    [SerializeField] private float fireRate = .2f;
    [SerializeField] private bool bAutomatic = false;
    [SerializeField] protected Transform muzzle;
    [SerializeField] private int maxAmmo;
    private int _currentAmmo;
    private bool _onCooldown;
    private bool _autoActive;
    
    private void Start()
    {
        _currentAmmo = maxAmmo;
    }

    private void Update()
    {
        if (_autoActive)
        {
            Fire();
        }
    }

    public virtual void Fire()
    {
        _currentAmmo--;
        StartCoroutine(FireCooldown());
        if(bAutomatic) _autoActive = true;
    }

    public void StopFiring()
    {
        _autoActive = false;
    }

    protected bool CanShoot()
    {
        return _currentAmmo > 0 && !_onCooldown;
    }

    IEnumerator FireCooldown()
    {
        _onCooldown = true;
        yield return new WaitForSeconds(fireRate);
        _onCooldown = false;
    }
}
