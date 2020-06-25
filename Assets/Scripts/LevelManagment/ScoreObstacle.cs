using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pinball;

public class ScoreObstacle : MonoBehaviour
{
    public ScoreType scoreType;
    public ScoreController scoreController;

    private void Awake()
    {
        scoreController = GameObject.Find("LevelManagment").GetComponent<ScoreController>();
    }

    public void Hit()
    {
        scoreController.IncreaseScore(scoreType);
    }
}
