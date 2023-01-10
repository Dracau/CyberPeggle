using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    public void CheckWin()
    {
        StartCoroutine(CheckWinCoroutine());
    }
    private IEnumerator CheckWinCoroutine()
    {
        yield return new WaitForFixedUpdate();
        if (transform.childCount == 0)
        {
            GameManager.Instance.Victory();
        }
    }
}
