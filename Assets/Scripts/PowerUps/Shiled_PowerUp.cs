//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


using UnityEngine;

public class Shiled_PowerUp : PowerUp
{
    [SerializeField]
    private float _shieldTime;

    public override void Buff(PlayerModel playerToBuff) => playerToBuff.ShieldOn(_shieldTime);
}