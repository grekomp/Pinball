using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScoreType
{
    Bumper = 30,
    Singshot = 20,
    Trigger = 10,
    Telleport = 50,
    BlackHole = 80
}

public class ScoreContainer {
    private int _bumper = 0;
    private int _slingshot = 0;
    private int _trigger = 0;
    private int _teleport = 0;
    private int _blackhole = 0;

    public ScoreContainer() { }

    public int BumperScore { get => _bumper; }
    public int SingshotScore { get => _slingshot; }
    public int TriggerScore { get => _trigger; }
    public int TeleportScore { get => _teleport; }
    public int BlackHolerScore { get => _blackhole; }


    public void AddPoints(ScoreType type, int value)
    {
        switch(type)
        {
            case ScoreType.Bumper:
                _bumper += value;
                break;
            case ScoreType.Singshot:
                _slingshot += value;
                break;
            case ScoreType.Trigger:
                _trigger += value;
                break;
            case ScoreType.Telleport:
                _teleport += value;
                break;
            case ScoreType.BlackHole:
                _blackhole += value;
                break;
        }
    }
}

public class ScoreController : MonoBehaviour
{
    public LevelController levelController;
    public AchivementControlller achivementControlller;
    public ScoreContainer scoreContainer = new ScoreContainer();

    public void IncreaseScore(ScoreType value)
    {
        if (value == ScoreType.Telleport)
        {
            achivementControlller.FirstTeleportAchivement();
        }
        if (value == ScoreType.BlackHole)
        {
            achivementControlller.FirstBlackholeAchivement();
        }
        scoreContainer.AddPoints(value, (int)value);
        levelController.score += (int)value;
    }

}
