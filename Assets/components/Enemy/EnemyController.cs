using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyStats stats;
    public Vector3 destination;
    public Units unitList;

    private void OnEnable()
    {
        unitList.Add(gameObject);
    }

    private void OnDestroy()
    {

        unitList.Remove(gameObject);
    }

    void Update()
    {
        if (transform.position != destination && destination != null)
        {
            LookAtTarget();
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        Vector3 position = Vector3.MoveTowards(transform.position, destination, stats.speed * Time.deltaTime);
        GetComponent<Rigidbody>().MovePosition(position);
    }

    private void LookAtTarget()
    {
        transform.LookAt(destination);
    }

    public void ApplyDamage(float damage)
    {
        Debug.Log("Took Damage: " + damage);
        if (stats.health - damage <= 0)
        {
            Destroy(gameObject);
        }
        stats.health -= damage;
    }
}
