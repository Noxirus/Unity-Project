using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Details")]
    [SerializeField] private float fireRate = .2f;
    [SerializeField] private bool bAutomatic = false;
    [SerializeField] protected Transform muzzle;
    [SerializeField] private int maxAmmo;
    private int _currentAmmo;

    private void Start()
    {
        _currentAmmo = maxAmmo;
    }

    public virtual void Fire()
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
