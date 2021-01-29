using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventManager
{
    private static readonly ObjectEvent<GameEvent> s_objectEvent = new ObjectEvent<GameEvent>();
    public static ObjectEvent<GameEvent> GameEvent { get { return s_objectEvent; } }
}
