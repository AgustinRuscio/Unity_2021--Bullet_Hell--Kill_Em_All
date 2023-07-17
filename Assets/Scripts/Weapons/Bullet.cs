using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Bullet : MonoBehaviour
{
    private Action<Bullet> _destroyMethod;

    protected Rigidbody _rigidBody;

    private GenericTimer _timer;

    Vector3 _originalFwd;

    protected float _damage = FlyWeightPointer.BulletAtributs.bulletBaseDamage;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _timer = new GenericTimer().SetCoolDown(FlyWeightPointer.BulletAtributs.bulletLifeTime);
    }

    void Update()
    {
        _timer.RunTimer();

        Vector3 dir = transform.forward;
        dir = dir.normalized;
        dir *= FlyWeightPointer.BulletAtributs.bulletSpeed;
        dir.y = 0;

        _rigidBody.velocity = dir;

        if (_timer.CheckCoolDown())
            DestroyBullet();
    }


    public void Initialize(Vector3 initPosition ,Action<Bullet> destroyMethod, Vector3 fwd, Quaternion rotation, float multuplayer)
    {
        transform.position = initPosition;
        transform.rotation = rotation;
        _destroyMethod = destroyMethod;
        _originalFwd = transform.forward;
        transform.forward = fwd;
        _damage *= multuplayer;
    }

    public void ReturnBullet() { _timer.ResetTimer(); _rigidBody.velocity = Vector3.zero; transform.rotation = Quaternion.Euler(0,0,0); transform.forward = _originalFwd; }

    protected void DestroyBullet() => _destroyMethod(this);
}