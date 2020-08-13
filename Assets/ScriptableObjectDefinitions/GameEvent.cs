using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();
    private List<Func<bool>> progListeners = new List<Func<bool>>();

    public void Trigger()
    {
        for(int i = listeners.Count -1; i >= 0; i--)
        {
            listeners[i].OnEventTriggered();
        }
        for(int i = progListeners.Count -1; i >= 0; i--)
        {
            progListeners[i]();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }

    public void RegisterListener(Func<bool> listener)
    {
        if (!progListeners.Contains(listener))
            progListeners.Add(listener);
    }

    public void UnRegisterListener(GameEventListener listener)
    {
        if (listeners.Contains(listener))
            listeners.Remove(listener);
    }

    public void UnRegisterListener(Func<bool> listener)
    {
        if (progListeners.Contains(listener))
            progListeners.Remove(listener);
    }
}
