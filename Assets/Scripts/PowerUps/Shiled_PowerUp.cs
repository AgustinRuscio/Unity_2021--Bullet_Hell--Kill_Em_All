using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiled_PowerUp : PowerUp
{
    [SerializeField]
    private float _shieldTime;

    public override void Buff(PlayerModel playerToBuff)
    {
        playerToBuff.ShieldOn(_shieldTime);
    }
}
