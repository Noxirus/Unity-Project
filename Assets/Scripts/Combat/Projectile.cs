using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Base Projectile Settings")]
    [SerializeField] protected float projectileSpeed = 10f;
    [SerializeField] protected float projectileLifeTime = 3f;
    [SerializeField] protected ParticleSystem impactParticles;
    
    private void Start()
    {
        Destroy(gameObject, projectileLifeTime);
    }
}
