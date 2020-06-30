using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementControlller : MonoBehaviour
{
    public PlayServices playServices;
    public ScoreController scoreController;

    private void Awake()
    {
        playServices = GameObject.Find("GPS").GetComponent<PlayServices>();
    }

    public void CheckInkrementalAhivements()
    {
        ScoreContainer scoreConatiner = scoreController.scoreContainer;
        playServices.IncrementAchievement(GPGSIds.achievement_incremental_achievement_1, (int)(scoreConatiner.BumperScore));
        playServices.IncrementAchievement(GPGSIds.achievement_incremental_achievement_2, (int)(scoreConatiner.SingshotScore));
        playServices.IncrementAchievement(GPGSIds.achievement_incremental_achievement_3, (int)(scoreConatiner.TriggerScore));
        playServices.IncrementAchievement(GPGSIds.achievement_incremental_achievement_4, (int)(scoreConatiner.TeleportScore));
        playServices.IncrementAchievement(GPGSIds.achievement_incremental_achievement_5, (int)(scoreConatiner.BlackHolerScore));
        if (scoreController.levelController.score >= 5000)
        {
            playServices.UnlockAchievement(GPGSIds.achievement_achievement_3);
        }
        if (scoreController.levelController.score >= 50000)
        {
            playServices.UnlockAchievement(GPGSIds.achievement_achievement_4);
        }
    }

    public void FirstTeleportAchivement()
    {
        playServices.UnlockAchievement(GPGSIds.achievement_achievement_1);
    }

    public void FirstBlackholeAchivement()
    {
        playServices.UnlockAchievement(GPGSIds.achievement_achievement_2);
    }

    public void FirstScoreAchivement()
    {
        playServices.UnlockAchievement(GPGSIds.achievement_achievement_3);
    }

    public void SecoondScoreAchivement()
    {
        playServices.UnlockAchievement(GPGSIds.achievement_achievement_4);
    }

    public void FirstTiltAchivement()
    {
        playServices.UnlockHiddenAchievement(GPGSIds.achievement_hidden_achievement_1);
    }

    public void PinchToZoomAchivement()
    {
        playServices.UnlockHiddenAchievement(GPGSIds.achievement_hidden_achievement_2);
    }
}
