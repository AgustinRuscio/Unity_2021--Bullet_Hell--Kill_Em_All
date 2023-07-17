using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float _coolDown;

    private GenericTimer _timer;

    private EnemyFactory _enemyFactory;

    [SerializeField]
    private Enemy _enemyPrefab;

    private int _enemyCounter;

    [SerializeField]
    private int _maxEnemies;

    [SerializeField]
    private Transform[] _spawnPoints;

    private void Awake()
    {
        _timer = new GenericTimer().SetCoolDown(_coolDown);

        _enemyFactory = new EnemyFactory(_enemyPrefab);
    }

    private void Update()
    {
        _timer.RunTimer();

        if (_timer.CheckCoolDown() & _enemyCounter < _maxEnemies)
        {
            int i = Random.Range(0, _spawnPoints.Length);

            _enemyFactory.MakeEnemy(_spawnPoints[i].position);
            _timer.ResetTimer();
            _enemyCounter++;
        }
    }
}
