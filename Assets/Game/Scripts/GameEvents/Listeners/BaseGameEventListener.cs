using UnityEngine;
using UnityEngine.Events;

public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour, IGameEventListener<T> where E : BaseGameEvent<T> where UER : UnityEvent<T>
{
    [SerializeField] private E gameEvent;

    public E GameEvent { get => gameEvent; set => gameEvent = value; }

    [SerializeField] private UER unityEventResponse;

    private void OnEnable()
    {
        gameEvent?.Subscribe(this);
    }

    private void OnDisable()
    {
        gameEvent?.Unsubscribe(this);
    }

    public void OnEventRaised(T item)
    {
        unityEventResponse?.Invoke(item);
    }
}