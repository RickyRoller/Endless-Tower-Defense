using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainFireProjectile : MonoBehaviour
{
    public RainFireProjectileStats stats;
    public Vector3 destination;
    public RaycastHit[] hits = new RaycastHit[10];
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 position = Vector3.MoveTowards(transform.position, destination, stats.speed * Time.deltaTime);
        GetComponent<Rigidbody>().MovePosition(position);

        // Projectile went under the map
        if (transform.position.y <= -1)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "Environment" || tag == "Enemy")
        {
            Vector3 direction = transform.forward;
            int hitCount = Physics.SphereCastNonAlloc(
                transform.position,
                stats.explosionRadius,
                direction,
                hits,
                Mathf.Infinity,
                LayerMask.GetMask("Enemies")
            );

            if (hitCount > 0)
            {
                foreach (RaycastHit hit in hits)
                {
                    if (hit.collider != null)
                    {
                        GameObject enemy = hit.transform.gameObject;
                        enemy.SendMessage("ApplyDamage", stats.damage);
                    }
                }
            }
            Destroy(gameObject);
        }
    }
}
