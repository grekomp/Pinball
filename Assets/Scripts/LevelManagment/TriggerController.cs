using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public List<GameObject> triggers = new List<GameObject>();

    public void ResetAllTriggers()
    {
        triggers.ForEach(trigger => {
            trigger.GetComponent<Trigger>().Reset();
        });
    }

    public void AddTrigger(GameObject trigger)
    {
        triggers.Add(trigger);
    }
}
