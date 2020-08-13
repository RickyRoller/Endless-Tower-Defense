using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float time;
    public GameObject objectToDestroy;
    void Start()
    {
        StartCoroutine(DestroyAfterTime());
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(time);
        var gm = objectToDestroy != null ? objectToDestroy : gameObject;
        Destroy(gm);
    }
}
