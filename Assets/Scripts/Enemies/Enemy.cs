//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Enemy : MonoBehaviour, IDamageable
{
    private Action<Enemy> _destroyMethod;
    private Action _reduce;

    protected Transform _player;

    [SerializeField]
    protected ParticleSystem _deathParticles;

    [SerializeField]
    protected SkinnedMeshRenderer _renderer;

    protected EnemyView _view;

    protected Rigidbody _rigidBody;

    [SerializeField]
    protected Vector3 _offSet;

    [SerializeField]
    private Animator _animator;


    protected float _life;

    protected abstract void SetLife();


    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _player = FindObjectOfType<PlayerModel>().transform;

        _view = new EnemyView(_animator);
    }


    public void Initialize(Vector3 initPosition, Action<Enemy> destroyMethod, Action reducingMethod)
    {
        transform.position = initPosition;
        _destroyMethod = destroyMethod;
        _reduce = reducingMethod;
    }

    private void DeleteFromList() => _reduce?.Invoke();


    public void ReturnEnemy()
    {
        DeleteFromList();
        _life = FlyWeightPointer.EnemiesAtributs.meleeEnemyMaxLife;
    }

    protected void DestroyEnemy() => _destroyMethod(this);

    protected abstract void MoveToPlayer();
    protected abstract void Attack();

    protected virtual void Death()
    {
        _renderer.enabled = false;
        _deathParticles.Play();

        StartCoroutine(Wait());
    }


    IEnumerator Wait()
    {
        while (_deathParticles.isPlaying)
        {
            yield return null;
        }

        DestroyEnemy();
    }

    protected virtual void Update()
    {
        MoveToPlayer();
    }

    public void TakeDamage(float damage)
    {
        _life -= damage;

        if(_life <= 0)
            Death();
    }
}