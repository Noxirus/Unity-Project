using UnityEngine;

public class RangedWeapon : Weapon
{
    [Header("Weapon Details")]
    [SerializeField] private bool bAutomatic;
    [SerializeField] protected Transform muzzle;
    private bool _autoActive;
    
    [Header("Ammunition Details")]
    [SerializeField] private int maxAmmo;
    [SerializeField] private int ammoCost = 1;
    private int _currentAmmo;
    
    private void Start()
    {
        _currentAmmo = maxAmmo;
    }
    
    void Update()
    {
        if (_autoActive)
        {
            Use();
        }
    }

    public override void Use()
    {
        base.Use();
        _currentAmmo = Mathf.Clamp(_currentAmmo - ammoCost, 0, maxAmmo);
        Debug.Log(_currentAmmo);
        if(bAutomatic) _autoActive = true;
    }
    
    public override void StopUsing()
    {
        if(bAutomatic) _autoActive = false;
    }
    
    protected bool CanShoot()
    {
        return _currentAmmo >= ammoCost && !_onCooldown;
    }
}
