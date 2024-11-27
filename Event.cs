using UnityEngine;

public struct Event
{
    public int Value { get; private set; }

    public Event(int value)
    {
        Value = value;
    }
}
