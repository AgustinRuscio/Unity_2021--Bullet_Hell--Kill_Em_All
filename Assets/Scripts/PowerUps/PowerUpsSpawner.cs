//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


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

    [SerializeField]
    private bool _active;

    private void Awake()
    {
        if (_active)
        {
            _timer = new GenericTimer().SetCoolDown(_coolDown);

            Factory = new PowerUpFactory(_powerUpPrefab);
        }
    }

    public void Reduce() => _counter--;
    

    private void Update()
    {
        if (_active)
        {
            _timer.RunTimer();

            if (_timer.CheckCoolDown() & _counter < _maxSpawned)
            {
                int i = Random.Range(0, _spawnPoints.Length);

                Factory.MakePowerUp(_spawnPoints[i].position, Reduce);
                _timer.ResetTimer();
                _counter++;
            }
        }
    }
}