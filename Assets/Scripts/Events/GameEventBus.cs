using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public enum GameEvents
{
    StartState, CharSelectionState, PrepareState,
    ControllableState, CheckingState, GameEndState
}

public class GameEventBus : MonoBehaviour
{
    private static readonly IDictionary<GameEvents, UnityEvent> Events
        = new Dictionary<GameEvents, UnityEvent>();

    public static void SubscribeEvent(GameEvents eventType, UnityAction listener)
    {
        UnityEvent thisEvent;

        if (Events.TryGetValue(eventType, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Events.Add(eventType, thisEvent);
        }
    }

    public static void UnsubscribeEvent(GameEvents eventType, UnityAction listener)
    {
        UnityEvent thisEvent;

        if (Events.TryGetValue(eventType, out thisEvent))
            thisEvent.RemoveListener(listener);
    }

    public static void PublishEvent(GameEvents eventType, UnityAction listener)
    {
        UnityEvent thisEvent;

        if (Events.TryGetValue(eventType, out thisEvent))
            thisEvent.Invoke();
    }
}
