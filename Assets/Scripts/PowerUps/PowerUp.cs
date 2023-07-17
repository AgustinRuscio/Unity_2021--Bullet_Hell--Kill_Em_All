using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    private Action<PowerUp> _destroyMethod;

    public abstract void Buff(PlayerModel playerToBuff);

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<PlayerModel>();

        if (player != null)
        {
            Buff(player);
            DestroyPowerUp();
        }
    }

    public void Initialize(Vector3 initPosition, Action<PowerUp> destroyMethod)
    {
        transform.position = initPosition;
        _destroyMethod = destroyMethod;
    }

    public void ReturnPowerUp() { }

    protected void DestroyPowerUp() => _destroyMethod(this);
}
