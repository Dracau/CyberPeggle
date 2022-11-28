using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public virtual void Hit()
    {
        Debug.Log(gameObject.name + " was hit");
        Destroy(gameObject);
    }
}
