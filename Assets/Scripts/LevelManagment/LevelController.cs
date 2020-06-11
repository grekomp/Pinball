using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelPhase {
    Start,
    Game,
    Tilt,
    GameOver,
    Pause
}


public class LevelController : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    public bool canTriggerFlippers = true;
    public UIGameController UIController;
    public MessageDisplayer messageDisplayer;
    private LevelPhase actualLevelPhase;

    public LevelPhase ActualLevelPhase {
        get { return actualLevelPhase; }
        set { actualLevelPhase = value; }
    }

    private void Start()
    {
        actualLevelPhase = LevelPhase.Start;
    }

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            SetPhase(LevelPhase.Start);
        }
        if (Input.GetKeyDown("2"))
        {
            SetPhase(LevelPhase.Game);
        }
        if (Input.GetKeyDown("3"))
        {
            SetPhase(LevelPhase.Tilt);
        }
        if (Input.GetKeyDown("4"))
        {
            SetPhase(LevelPhase.GameOver);
        }
    }

    public void SetPhase(LevelPhase phase)
    {
        actualLevelPhase = phase;
        canTriggerFlippers = true;
        if (actualLevelPhase == LevelPhase.Start)
        {
            ShowStartUI();
        } else
        {
            HideStartUI();
            if (actualLevelPhase == LevelPhase.Tilt)
            {
                Tilt();
            }
            if (actualLevelPhase == LevelPhase.GameOver)
            {
                GameOver();
            }
        }

    }

    public void ShowStartUI()
    {
        UIController.SetOnStartUiVisibility(true);
    }

    public void HideStartUI()
    {
        UIController.SetOnStartUiVisibility(false);
    }

    public void IncreaseScore(int value)
    {
        score += value;
    }

    public void DecreaseScore(int value)
    {
        score -= value;
    }

    private void Tilt()
    {
        canTriggerFlippers = false;
        messageDisplayer.SetText("TILT !");
    }

    private void GameOver()
    {
        canTriggerFlippers = false;
        Debug.Log("Game OVer !");
    }
}
