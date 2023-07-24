//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected Transform _spawnPoint;

    [SerializeField]
    protected float _damageMultiplayer;

    protected float nextFireTime;

    [SerializeField]
    public float fireRate;

    [SerializeField]
    protected ParticleSystem _particleSystem;

    [SerializeField]
    protected AudioSource _audioSource;

    protected Action<bool> FireAnim;

    public void SetFireAnim(Action<bool> fire) => FireAnim = fire;
    
    public abstract void FireWeapon(params object[] parameters);
}