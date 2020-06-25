using Pinball;
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
    private const int START_LIVES = 3;
    public int lives = START_LIVES;
    public bool canTriggerFlippers = true;
    public UIGameController UIController;
    public MessageDisplayer messageDisplayer;
    public Plunger plunger;
    private LevelPhase actualLevelPhase;

    public LevelPhase ActualLevelPhase {
        get { return actualLevelPhase; }
        set { actualLevelPhase = value; }
    }

    private void Start()
    {
        SetPhase(LevelPhase.Start);
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
            StartGame();
        } else
        {
            HideStartUI();
            if (actualLevelPhase == LevelPhase.Tilt)
            {
                Tilt();
            }
            if (actualLevelPhase == LevelPhase.Game)
            {
                Game();
            }
            if (actualLevelPhase == LevelPhase.GameOver)
            {
                GameOver();
            }
        }

    }

    public void RestartGame()
    {
        lives = START_LIVES;
        score = 0;
        SetPhase(LevelPhase.Start);
    }

    public void StartGame()
    {
        ShowStartUI();
        plunger.SpawnBall();
        canTriggerFlippers = false;
    }

    public void Game()
    {
        canTriggerFlippers = true;
    }

    public void RemoveLife()
    {
        messageDisplayer.SetText("Fail !");
        lives--;
        if (lives == 0)
        {
            SetPhase(LevelPhase.GameOver);
        } else
        {
            SetPhase(LevelPhase.Start);
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

    private void Tilt()
    {
        canTriggerFlippers = false;
        messageDisplayer.SetText("TILT !");
    }

    private void GameOver()
    {
        canTriggerFlippers = false;
        UIController.GameOver();
    }
}
