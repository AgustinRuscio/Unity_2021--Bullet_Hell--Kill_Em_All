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

    [SerializeField]
    protected AttackZone _attackZone;

    protected float _life = FlyWeightPointer.EnemiesAtributs.enemyMaxLife;


    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _player = FindObjectOfType<PlayerModel>().transform;


        _view = new EnemyView(_animator);
    }


    public void Initialize(Vector3 initPosition, Action<Enemy> destroyMethod)
    {
        transform.position = initPosition;
        _destroyMethod = destroyMethod;
    }

    public void ReturnEnemy() => _life = FlyWeightPointer.EnemiesAtributs.enemyMaxLife; 

    protected void DestroyEnemy() => _destroyMethod(this);

    protected abstract void MoveToPlayer();
    protected abstract void Attack();

    private void Death()
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

    private void Update()
    {
        MoveToPlayer();
    }

    public void TakeDamage(float damage)
    {
        _life -= damage;

        Debug.Log("Hurt");

        if(_life <= 0)
        {
            Death();
        }
    }


}
