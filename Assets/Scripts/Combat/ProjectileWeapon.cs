using UnityEngine;

public class ProjectileWeapon : RangedWeapon
{
    [Header("Projectile Details")]
    [SerializeField] private Projectile projectile;

    public override void Use()
    {
        if (!CanShoot()) return;
        base.Use();
        
        Instantiate(projectile, muzzle.transform.position, muzzle.transform.rotation);
    }
}
