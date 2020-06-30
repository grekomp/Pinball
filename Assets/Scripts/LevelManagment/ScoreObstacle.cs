using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pinball;

public class ScoreObstacle : MonoBehaviour
{
    public ScoreType scoreType;
    public ScoreController scoreController;
    public AudioController audioController;

    private void Awake()
    {
        scoreController = GameObject.Find("LevelManagment").GetComponent<ScoreController>();
        audioController = GameObject.Find("Main Camera").GetComponent<AudioController>();
    }

    public void Hit()
    {
        scoreController.IncreaseScore(scoreType);
        audioController.PlayObstalce(scoreType);
    }
}
