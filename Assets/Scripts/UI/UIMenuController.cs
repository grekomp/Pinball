using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuController : MonoBehaviour
{

    public PlayServices playServices;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenLeaderboard()
    {
        playServices.ShowLeaderboardsUI();
    }

    public void OpenAchivements()
    {
        playServices.ShowAchievementsUI();
    }
}
