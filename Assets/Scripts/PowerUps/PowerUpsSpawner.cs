using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsSpawner : MonoBehaviour
{
    [SerializeField]
    private float _coolDown;

    private GenericTimer _timer;

    private PowerUpFactory Factory;

    [SerializeField]
    private PowerUp _powerUpPrefab;

    private int _counter;

    [SerializeField]
    private int _maxSpawned;

    [SerializeField]
    private Transform[] _spawnPoints;

    private void Awake()
    {
        _timer = new GenericTimer().SetCoolDown(_coolDown);

        Factory = new PowerUpFactory(_powerUpPrefab);
    }

    private void Update()
    {
        _timer.RunTimer();

        if (_timer.CheckCoolDown() & _counter < _maxSpawned)
        {
            int i = Random.Range(0, _spawnPoints.Length);

            Factory.MakePowerUp(_spawnPoints[i].position);
            _timer.ResetTimer();
            _counter++;
        }
    }
}
