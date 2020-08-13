using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainArrowsArrow : MonoBehaviour
{
    public Vector3 target;
    public float speed;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position != target && transform.position.y > 0.3)
        {
            LookAtTarget();
            MoveToTarget();
        }
    }
    private void MoveToTarget()
    {
        Vector3 position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        _rigidbody.MovePosition(position);
    }

    private void LookAtTarget()
    {
        transform.LookAt(target);
    }

    //private void OnTriggerEnter(Collider collider)
    //{
    //    int layer = collider.gameObject.layer;
    //    if (layer == LayerMask.NameToLayer("PlayableArea") && !hasCollided)
    //    {
    //        _rigidbody.freezeRotation = true;
    //        hasCollided = true;
    //    }
    //}
}
