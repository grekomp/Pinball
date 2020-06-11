using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.UI;

public class PlayServices : MonoBehaviour
{
    public static PlayServices Instance;

    public Text text;

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
                text.text = "The user has been authenticated correctly.";
                Debug.Log("The user has been authenticated correctly.");
            }
            else
            {

                text.text = "An error while authenticating.";
//                text.text = PlayGamesPlatform.Instance.GetUserEmail();
                Debug.LogError("An error while authenticating.");
            }
        });
    }

    #region Achievements
    public void UnlockAchievement()
    {
        Debug.Log("Unlock Achievement");
        Social.ReportProgress(GPGSIds.achievement_achievement_1, 100, success => { });
    }

    public void UnlockHiddenAchievement()
    {
        Debug.Log("Unlock Hidden Achievement");
        Social.ReportProgress(GPGSIds.achievement_hidden_achievement_1, 100, success => { });
    }

    public void IncrementAchievement()
    {
        Debug.Log("Unlock Increment Achievement");
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_incremental_achievement_1, 5, success => { });
    }

    public void ShowAchievementsUI()
    {
        Debug.Log("Show Achievements");
        Social.ShowAchievementsUI();
    }
    #endregion /Achievements

    #region Leaderboards
    public void AddScoreToDescLeaderboard()
    {
        Debug.Log("Add Score To Desc Leaderboard");
        Social.ReportScore(Random.Range(0, 100), GPGSIds.leaderboard_leaderboard_1_student_4, success => { });
    }

    public void AddScoreToAscLeaderboard()
    {
        Debug.Log("Add Score To Asc Leaderboard");
        Social.ReportScore(Random.Range(0, 100), GPGSIds.leaderboard_leaderboard_2_student_4, success => { });
    }
    public void ShowLeaderboardsUI()
    {
        Debug.Log("Show Leaderboards");
        Social.ShowLeaderboardUI();
    }
    #endregion /Leaderboards
}
