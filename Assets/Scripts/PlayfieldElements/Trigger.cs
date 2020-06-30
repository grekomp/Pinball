using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pinball;

public class Trigger : MonoBehaviour
{
    public bool isTriggered = false;
    public ScoreController scoreControler;
    public TriggerController triggerControler;
    public ScoreType scoreType = ScoreType.Trigger;
    public AudioController audioController;
    public GameObject bulb;
    public Material on;
    public Material off;


    private void Awake()
    {
        scoreControler = GameObject.Find("LevelManagment").GetComponent<ScoreController>();
        triggerControler = GameObject.Find("LevelManagment").GetComponent<TriggerController>();
        audioController = GameObject.Find("Main Camera").GetComponent<AudioController>();
        triggerControler.AddTrigger(transform.gameObject);
    }

    private void Hit()
    {
        scoreControler.IncreaseScore(scoreType);
        isTriggered = !isTriggered;
        //audioController.PlayObstalce(scoreType);
        ChangeColor();
    }

    protected void OnTriggerEnter(Collider other)
    {
        var ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            Hit();
        }
    }

    public void Reset()
    {
        isTriggered = false;
        ChangeColor();
    }

    private void ChangeColor()
    {
        bulb.GetComponent<MeshRenderer>().material = isTriggered ? on : off;
    }
}
