using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainRotation : MonoBehaviour
{
    void Update()
    {
        Vector4 parentRotation = transform.parent.eulerAngles;
        float y = Math.Abs(parentRotation.y - 360f) + transform.parent.eulerAngles.y;
        transform.eulerAngles = new Vector3(0f, y, 0f);
    }
}
