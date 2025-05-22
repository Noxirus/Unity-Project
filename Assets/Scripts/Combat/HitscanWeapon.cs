using UnityEngine;

public class HitscanWeapon : Weapon
{
    [SerializeField] float range = 100f;
    [SerializeField] private LayerMask targetMask;
    [SerializeField] private ParticleSystem hitParticles;
    
    public override void Fire()
    {
        if (!CanShoot()) return;
        base.Fire();
        
        Debug.DrawRay(muzzle.transform.position, muzzle.transform.up * range, Color.red, 5f);
        if (Physics.Raycast(muzzle.transform.position, muzzle.transform.up, out RaycastHit hit, range, targetMask))
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                Destroy(hit.transform.gameObject);
            }
            Instantiate(hitParticles, hit.point, Quaternion.identity);
        }
    }
}
