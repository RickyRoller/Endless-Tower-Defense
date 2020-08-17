using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Vector3 destination;
    public float speed;
    public float radius;
    public float damage;
    public GameObject scorchMark;

    public GameObject debugSphere;
    public bool renderDebug = false;

    private bool hasCollided = false;
    private bool hasForce = false;
    private Quaternion _rotation;
    void Start()
    {
        if (destination != null)
        {
            transform.LookAt(destination);
        }
    }

    void Update()
    {
        if (_rotation != transform.rotation)
        {
            _rotation = transform.rotation;
        }
        else if (!hasForce)
        {
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed);
            hasForce = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        string tag = collider.gameObject.tag;
        if (tag == "Environment" || tag == "Enemy" && !hasCollided)
        {
            hasCollided = true;

            RenderScorch();
            if (renderDebug) RenderDebug();
            AbilityUtilities.DamageInArea(transform.position, radius, damage);
            Destroy(gameObject);
        }
    }

    private void RenderScorch()
    {
        Vector3 position = transform.position;
        position.y = -0.48f;
        float scale = radius * 2;
        scorchMark.transform.localScale = new Vector3(scale, 1, scale);
        Instantiate(scorchMark, position, Quaternion.identity);
    }

    private void RenderDebug()
    {
        debugSphere.GetComponent<DebugSphere>().radius = radius;
        Instantiate(debugSphere, transform.position, transform.rotation);
    }
}
