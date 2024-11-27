using System;
using KHALMStudio.Scripts.EventSystem;
using UnityEngine;

public class EventInvoker : MonoBehaviour
{
    private void Start()
    {
        EventAggregator.Publish(new Event(20));
    }
}
