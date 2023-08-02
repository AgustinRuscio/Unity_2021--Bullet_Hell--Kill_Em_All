//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class KamikazeEnemy : Enemy
{
    [SerializeField]
    private ParticleSystem _explosionParticles;

    [SerializeField]
    private AudioSource _explosionSound;

    [SerializeField]
    private AudioSource _tikingSound;

    private GenericTimer _timer;

    [SerializeField]
    private float _coolDown;

    [SerializeField]
    private float _explosionRadius;

    int explosive;

    private void Awake()
    { 
        _deathSound = GetComponent<AudioSource>();
        _timer = new GenericTimer().SetCoolDown(_coolDown);
    }

    protected override void Update()
    {
        base.Update();
        _timer.RunTimer();

        if (_timer.CheckCoolDown())
            Attack();
    }

    protected override void Attack()
    {
        if(explosive == 0)
        {
            _tikingSound.volume = 0f;
            _explosionParticles.Play();
            _explosionSound.Play();

            Collider[] deathZone = Physics.OverlapSphere(transform.position, _explosionRadius);

            for (int i = 0; i < deathZone.Length; i++)
            {
                PlayerModel damageable = deathZone[i].GetComponent<PlayerModel>();

                if (damageable != null && !damageable.shield)
                    damageable.TakeDamage(FlyWeightPointer.KamekaseEnemiesAtributs.kamekazeEnemyDamage);
            }

            explosive++;
            Death();
        }
    }

    protected override void MoveToPlayer()
    {
        if(_life > 0)
        {
            Vector3 dir = _player.position - transform.position;
            Vector3 dirWithOffset = dir + _offSet;
            dirWithOffset.Normalize();

            dirWithOffset *= FlyWeightPointer.KamekaseEnemiesAtributs.meleeEnemyBaseSpeed;

            dirWithOffset.y = 0;

            transform.forward = Vector3.Lerp(transform.forward, dir, FlyWeightPointer.KamekaseEnemiesAtributs.meleeEnemyRotationSpeed * Time.deltaTime);

            _rigidBody.velocity = dirWithOffset;

            if (Vector3.Distance(transform.position, _player.position) > _explosionRadius)
            {
                _timer.ResetTimer();
                _tikingSound.Stop();
            }
            else
            {
                _timer.RunTimer();

                if(!_tikingSound.isPlaying)
                    _tikingSound.Play();
            }
        }
    }

    protected override void SetLife() => _life = FlyWeightPointer.KamekaseEnemiesAtributs.meleeEnemyMaxLife;
}