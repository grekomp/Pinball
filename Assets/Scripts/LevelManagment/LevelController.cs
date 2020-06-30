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
    public TriggerController triggerControler;
    public Plunger plunger;
    public PlayServices playServices;
    public AchivementControlller achivementController;
    public AudioController audioController;
    private LevelPhase actualLevelPhase;

    public LevelPhase ActualLevelPhase {
        get { return actualLevelPhase; }
        set { actualLevelPhase = value; }
    }

    private void Awake()
    {
        playServices = GameObject.Find("GPS").GetComponent<PlayServices>();
        audioController = GameObject.Find("Main Camera").GetComponent<AudioController>();
    }

    private void Start()
    {
        SetPhase(LevelPhase.Start);
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
        triggerControler.ResetAllTriggers();
        lives--;
        if (lives == 0)
        {
            audioController.GameOver();
            SetPhase(LevelPhase.GameOver);
        } else
        {
            audioController.Fail();
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
        audioController.Tilt();
        canTriggerFlippers = false;
        messageDisplayer.SetText("TILT !");
        achivementController.FirstTiltAchivement();
        StartCoroutine(TiltGameOver());
    }

    private IEnumerator TiltGameOver()
    {
        yield return new WaitForSeconds(1f);
        SetPhase(LevelPhase.GameOver);
    }

    public void FlipperMoved()
    {
        if (canTriggerFlippers && actualLevelPhase != LevelPhase.GameOver && actualLevelPhase != LevelPhase.Pause && actualLevelPhase != LevelPhase.Tilt)
        {
            audioController.Flipper();
        }
    }

    private void GameOver()
    {
        achivementController.CheckInkrementalAhivements();
        playServices.AddScoreToDescLeaderboard(score);
        playServices.AddScoreToAscLeaderboard(score);
        canTriggerFlippers = false;
        messageDisplayer.HideMessage();
        UIController.GameOver();
    }
}
