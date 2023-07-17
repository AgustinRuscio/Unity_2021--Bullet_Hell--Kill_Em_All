using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLife_PowerUp : PowerUp
{
    [SerializeField]
    private float LifeToAdd;

    public override void Buff(PlayerModel playerToBuff)
    {
        playerToBuff.AddLife(LifeToAdd);
    }
}
