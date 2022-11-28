using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    private List<GameObject> objectsUnderCooldown = new List<GameObject>();
    [SerializeField] private float cooldown;
    public bool TryWarp(GameObject go){
        if(objectsUnderCooldown.Contains(go)){
            return false;
        }
        objectsUnderCooldown.Add(go);
        StartCoroutine(StartCooldown(go));
        return true;
    }

    private IEnumerator StartCooldown(GameObject go)
    {
        yield return new WaitForSeconds(cooldown);
        objectsUnderCooldown.Remove(go);
    }
}
