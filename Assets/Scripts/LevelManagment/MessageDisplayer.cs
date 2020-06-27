using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MessageDisplayer : MonoBehaviour
{
    public GameObject displayer;
    public Text displayText;

    public void SetText(string message, float duration = 2.5f)
    {
        displayText.text = message;
        StartCoroutine(DisplayTextForSeconds(duration));
    }

    public void HideMessage()
    {
        displayer.gameObject.SetActive(false);
    }

    private IEnumerator DisplayTextForSeconds(float seconds)
    {
        displayer.gameObject.SetActive(true);
        yield return new WaitForSeconds(seconds);
        displayer.gameObject.SetActive(false);
    }
}
