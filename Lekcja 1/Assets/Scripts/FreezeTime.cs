using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTime : PickUp
{
    [SerializeField]
    int freezeTime = 10;

    public override void Picked()
    {
        GameManager.gameManager.FreezeTime(freezeTime);
        base.Picked();
    }
}
