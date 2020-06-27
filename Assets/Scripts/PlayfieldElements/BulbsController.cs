using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbsController : MonoBehaviour
{
    public List<Bulb> bulbs = new List<Bulb>();

    private void Awake()
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            bulbs.Add(transform.GetChild(i).GetComponent<Bulb>());
        }
    }
    public void TurnOn(float time)
    {
        float timePerBulb = time / bulbs.Count;
        StartCoroutine(LightBulbs(timePerBulb));
    }

    private IEnumerator LightBulbs(float seconds)
    {
        for (int i = 0; i < bulbs.Count; i++)
        {
            bulbs[i].Switch();
            yield return new WaitForSeconds(seconds);
            bulbs[i].Switch();
        }
    }
}
