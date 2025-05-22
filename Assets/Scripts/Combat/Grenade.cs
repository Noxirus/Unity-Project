using System.Collections;
using UnityEngine;

public class Grenade : Projectile
{
    [SerializeField] private int numberOfBounces = 3;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(transform.up * projectileSpeed, ForceMode.Impulse);
    }
    
    private void Start()
    {
        StartCoroutine(ExplosionCountdown());
    }

    IEnumerator ExplosionCountdown()
    {
        yield return new WaitForSeconds(projectileLifeTime);
        Explode();
    }

    private void OnCollisionEnter(Collision other)
    {
        numberOfBounces--;
        if (numberOfBounces == 0)
        {
            Explode();
        }
    }

    void Explode()
    {
        Debug.Log("Kaboom!");
        // Sphere cast all, damage anything it hits.
        // Maybe add a impulse force to surrounding objects
        // Play Particle effects here
        
        Destroy(gameObject);
    }
}
