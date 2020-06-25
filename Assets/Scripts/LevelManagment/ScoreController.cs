using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScoreType
{
    Bumper = 20,
    Singshot = 30,
    Trigger = 40,
}

public class ScoreController : MonoBehaviour
{
    public LevelController levelController;

    public void IncreaseScore(ScoreType value)
    {
        levelController.score += (int)value;
    }

}
