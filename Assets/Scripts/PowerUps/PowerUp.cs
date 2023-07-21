//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using System;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    private Action<PowerUp> _destroyMethod;
    private Action reducing;

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

    public void Initialize(Vector3 initPosition, Action<PowerUp> destroyMethod, Action reduce)
    {
        transform.position = initPosition;
        _destroyMethod = destroyMethod;
        reducing = reduce;
    }

    private void DeleteFromList() => reducing?.Invoke();
    
    public void ReturnPowerUp() { DeleteFromList(); }

    protected void DestroyPowerUp() => _destroyMethod(this);
}