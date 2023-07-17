using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBullet : Bullet
{
    [SerializeField]
    private ParticleSystem _particleSystem;

    [SerializeField]
    private float _radius;


    private void OnCollisionEnter(Collision collision)
    {
        _rigidBody.velocity = Vector3.zero;

        _particleSystem.transform.position = transform.position;
        _particleSystem.Play();

        var enemies = Physics.OverlapSphere(transform.position, _radius);

        foreach (var enemy in enemies)
        {
            var damageable = enemy.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
                damageable.TakeDamage(_damage);
        }

        if (!_particleSystem.isPlaying)
            DestroyBullet();
        
    }
}