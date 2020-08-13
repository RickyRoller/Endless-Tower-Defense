using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyOn : MonoBehaviour
{
    public GameEvent Event;
    public GameObject objectToDestroy;
    private void OnEnable()
    {
        Event.RegisterListener(OnEventTriggered);
    }

    private void OnDisable()
    {
        Event.UnRegisterListener(OnEventTriggered);
    }

    bool OnEventTriggered()
    {
        var gm = objectToDestroy != null ? objectToDestroy : gameObject;
        Destroy(gm);
        return false;
    }
}
