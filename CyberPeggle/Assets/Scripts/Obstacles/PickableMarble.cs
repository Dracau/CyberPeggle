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
        MenuManager.instance.hud.UpdateMarblesTaken(0, PickableMarbles.Count);
    }

    public override void Hit()
    {
        base.Hit();
        PickableMarbles.Remove(this);
        MenuManager.instance.hud.UpdateMarblesTaken(PickableMarbles.Count, 0);
        if (PickableMarbles.Count == 0)
        {
            GameManager.Instance.Victory();
        }
    }
}
