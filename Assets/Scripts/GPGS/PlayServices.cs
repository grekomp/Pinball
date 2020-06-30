using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.UI;

public class PlayServices : MonoBehaviour
{
    public static PlayServices Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        SignIn();
    }

    void SignIn()
    {
        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) => {
            if (result.Equals(SignInStatus.Success))
            {
                Debug.Log("The user has been authenticated correctly.");
            }
            else
            {
                Debug.LogError("An error while authenticating.");
            }
        });
    }

    #region Achievements
    public void UnlockAchievement(string achivId)
    {
        Social.ReportProgress(achivId, 100, success => { });
    }

    public void UnlockHiddenAchievement(string achivId)
    {
        Social.ReportProgress(achivId, 100, success => { });
    }

    public void IncrementAchievement(string achivId, int value)
    {
        PlayGamesPlatform.Instance.IncrementAchievement(achivId, value, success => { });
    }

    public void ShowAchievementsUI()
    {
        Social.ShowAchievementsUI();
    }
    #endregion /Achievements

    #region Leaderboards
    public void AddScoreToDescLeaderboard(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_leaderboard_1_student_4, success => { });
    }

    public void AddScoreToAscLeaderboard(int score)
    {
        Social.ReportScore(score, GPGSIds.leaderboard_leaderboard_2_student_4, success => { });
    }
    public void ShowLeaderboardsUI()
    {
        Social.ShowLeaderboardUI();
    }
    #endregion /Leaderboards
}
