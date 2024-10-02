using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCalculator : PickUp
{
    [SerializeField]
    bool isAddingTime = true;
    [SerializeField]
    int time = 5;
    public override void Picked()
    {
        int sign = 1;
        if (!isAddingTime)
        {
            sign = -1;
        }
        else
        {
            sign = 1;
        }
        GameManager.gameManager.AddTime(time * sign);
        base.Picked();
    }
}
