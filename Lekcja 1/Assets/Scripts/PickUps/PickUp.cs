using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0f, 5f, 0f));
    }

    public virtual void Picked()
    {
        Debug.Log("Picked!");
        Destroy(gameObject);
    }
}
