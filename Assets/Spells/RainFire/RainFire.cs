using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainFire : MonoBehaviour
{
    public RainFireStats stats;
    public GameObject projectile;

    void Start()
    {
        StartCoroutine(Cast());
    }


    void Update()
    {
        
    }

    IEnumerator Cast()
    {
        while (gameObject.activeSelf)
        {
            Vector3 origin = gameObject.transform.position;
            Vector3 randomPosition = AbilityUtilities.RandomPointInCircle(origin, stats.radius);

            SpawnFire(randomPosition);
            yield return new WaitForSeconds(stats.castSpeed);
        }
    }

    private void SpawnFire(Vector3 point)
    {
        projectile.GetComponent<RainFireProjectile>().destination = point;
        Vector3 spawnPoint = new Vector3(point.x, stats.startY, point.z);
        Instantiate(projectile, spawnPoint, gameObject.transform.rotation);
    }


    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, stats.radius);
    }
}
