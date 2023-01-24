using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableMarble : Obstacle
{
    public static List<PickableMarble> PickableMarbles = new List<PickableMarble>();
    
    private void Start()
    {
        PickableMarbles.Add(this);
    }

    public override void Hit()
    {
        base.Hit();
        PickableMarbles.Remove(this);
        if (PickableMarbles.Count == 0)
        {
            GameManager.Instance.Victory();
        }
    }
}
