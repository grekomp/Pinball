using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MessageDisplayer : MonoBehaviour
{
    public Text display;

    public void SetText(string message, float duration = 2.5f)
    {
        display.text = message;
        StartCoroutine(DisplayTextForSeconds(duration));
    }

    private IEnumerator DisplayTextForSeconds(float seconds)
    {
        display.gameObject.SetActive(true);
        yield return new WaitForSeconds(seconds);
        display.gameObject.SetActive(false);
    }
}
