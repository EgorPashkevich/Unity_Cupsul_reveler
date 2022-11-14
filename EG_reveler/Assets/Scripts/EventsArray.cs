using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsArray : MonoBehaviour
{
   public UnityEvent[] Event;

   public void StartEvent(int Index){
    Event[Index].Invoke();
   }
}
