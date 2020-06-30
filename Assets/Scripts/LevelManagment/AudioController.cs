using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource flipper;
    public AudioSource bumper;
    public AudioSource slingshot;
    public AudioSource tilt;
    public AudioSource trigger;
    public AudioSource fail;
    public AudioSource gameOver;
    public AudioSource teleport;
    public AudioSource ballShot;

    public void PlayObstalce(ScoreType type)
    {
        switch (type) {
            case ScoreType.Bumper:
                bumper.Play();
                break;
            case ScoreType.Singshot:
                slingshot.Play();
                break;
            case ScoreType.Trigger:
                trigger.Play();
                break;
        }
    }

    public void Tilt()
    {
        tilt.Play();
    }

    public void Flipper()
    {
        flipper.Play();
    }

    public void Fail()
    {
        fail.Play();
    }

    public void GameOver()
    {
        gameOver.Play();
    }

    public void Teleport()
    {
        teleport.Play();
    }

    public void BallShot()
    {
        ballShot.Play();
    }
}
