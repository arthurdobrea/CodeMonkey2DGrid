using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Game Event", fileName = "New Game Event")]
public abstract class BaseGameEvent<T> : ScriptableObject
{
    private HashSet<IGameEventListener<T>> listeners = new HashSet<IGameEventListener<T>>();

    public void Raise(T item)
    {
        foreach (var globalEventListener in listeners)
        {
            globalEventListener.OnEventRaised(item);
        }
    }

    internal void Subscribe(IGameEventListener<T> listener)
    {
        listeners.Add(listener);
    }

    internal void Unsubscribe(IGameEventListener<T> listener)
    {
        listeners.Remove(listener);
    }
}