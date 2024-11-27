using KHALMStudio.Scripts.EventSystem;
using UnityEngine;

public class Subscriber2 : MonoBehaviour
{
    private void OnEnable()
    {
        EventAggregator.Subscribe<Event>(OnEventThrown);
    }

    private void OnDisable()
    {
        EventAggregator.Unsubscribe<Event>(OnEventThrown);
    }

    private void OnEventThrown(Event obj)
    {
        Debug.Log($"{this.gameObject.name} " +
                  $"received the event. Value {obj.Value}");
    }
}
