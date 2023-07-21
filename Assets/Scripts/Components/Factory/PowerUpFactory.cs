//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using System;
using UnityEngine;

public class PowerUpFactory
{
    private ObjectPool<PowerUp> _powerUpPool;

    private int _enemyPreWarm = 50;

    public PowerUpFactory(PowerUp powerUp) => _powerUpPool = new ObjectPool<PowerUp>(powerUp, _enemyPreWarm, Factory, TurnOn, TurnOff);

    public PowerUp MakePowerUp(Vector3 powerUpPosition, Action reduce)
    {
        PowerUp newPowerUp = _powerUpPool.GetObjects();
        newPowerUp.Initialize(powerUpPosition, ReturnPowerUp, reduce);
        return newPowerUp;
    }

    private PowerUp Factory(PowerUp prefab)
    {
        PowerUp newPowerUp = MonoBehaviour.Instantiate(prefab);
        return newPowerUp;
    }

    private void ReturnPowerUp(PowerUp powerUpToReturn) => _powerUpPool.ReturnObjects(powerUpToReturn);

    private void TurnOn(PowerUp powerUp) => powerUp.gameObject.SetActive(true);

    private void TurnOff(PowerUp powerUp)
    {
        powerUp.ReturnPowerUp();
        powerUp.gameObject.SetActive(false);
    }
}