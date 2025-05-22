using UnityEngine;

public class ProjectileWeapon : Weapon
{
    [SerializeField] private Projectile projectile;

    public override void Fire()
    {
        if (!CanShoot()) return;
        base.Fire();
        Instantiate(projectile, muzzle.transform.position, muzzle.transform.rotation);
    }
}
