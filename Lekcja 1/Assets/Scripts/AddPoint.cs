using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoint : PickUp
{
    [SerializeField]
    int points = 1;

    public override void Picked()
    {
        GameManager.gameManager.AddPoints(points);
        base.Picked();
    }
}
