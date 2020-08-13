using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceOnClick : MonoBehaviour
{
    public Vector3 point;
    public bool looking = false;
    public Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (looking)
        {
            looking = false;
            //_rigidbody.velocity = new Vector3(0f, 0f, 0f);
            //_rigidbody.AddRelativeForce(Vector3.forward * 80);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f, LayerMask.GetMask("PlayableArea")))
            {
                point = hit.point;
                //point.y += 5f;
                transform.LookAt(point);
                //_rigidbody.velocity = new Vector3(0f, 0f, 0f);
                _rigidbody.AddRelativeForce(Vector3.forward * 500);
                looking = true;
            }
        }
    }
}
