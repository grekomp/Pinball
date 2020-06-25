using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIGameController : MonoBehaviour
{
    public GameObject onGameUI;
    public GameObject onStartUI;
    public GameObject pauseUI;
    public GameObject gameOverUI;
    public Text score;
    public Text lives;
    public LevelController LC;

    private LevelPhase lastLevelPhase;

    private void Update()
    {
        score.text = "Score: " + LC.score;
        lives.text = "x " + LC.lives;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PauseGame()
    {
        lastLevelPhase = LC.ActualLevelPhase;
        LC.ActualLevelPhase = LevelPhase.Pause;
        pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        LC.ActualLevelPhase = lastLevelPhase;
        pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void SetOnStartUiVisibility(bool visibility)
    {
        onStartUI.SetActive(visibility);
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        gameOverUI.SetActive(false);
        LC.RestartGame();
    }
}
