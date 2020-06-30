using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NudgeSide
{
    Left,
    Right
}

public class NudgeController : MonoBehaviour
{
    public GameObject boardPivot;
    public AnimationCurve animationCurve;
    public LevelController levelController;
    public MessageDisplayer messageDisplayer;
    public bool isMoving = false;
    public float nudgeTime = 0.05f;
    public float nudgeDistance = 0.01f;
    private float startTime;
    private List<float> nudgingHistory = new List<float>();
    private NudgeSide nudgeSide;

    public void Awake()
    {
        animationCurve.keys[1].value = nudgeDistance;
        animationCurve.keys[1].time = nudgeTime / 2;
        animationCurve.keys[2].time = nudgeTime;
    }

    void Update()
    {

        if (Input.GetKeyDown("1"))
        {
            Nudge(NudgeSide.Left);
        }
        if (Input.GetKeyDown("2"))
        {
            Nudge(NudgeSide.Right);
        }

        if (isMoving == true)
        {
            MoveBaord();
        }
    }

    public void Nudge(NudgeSide side)
    {
        if (isMoving == false)
        {
            startTime = Time.time;
            nudgingHistory.Add(startTime);
            nudgeSide = side;
            isMoving = true;
            if (IsTilted(startTime))
            {
                levelController.SetPhase(LevelPhase.Tilt);
            }
        }
    }

    public void MoveBaord()
    {
        int direction = (nudgeSide == NudgeSide.Right) ? 1 : -1;
        boardPivot.transform.position = new Vector3(animationCurve.Evaluate(Time.time - startTime) * direction, 0f, 0f);
        if ((Time.time - startTime) > animationCurve.keys[2].time)
        {
            isMoving = false;
        }
    }

    private bool IsTilted(float time)
    {
        // Clear old timestamps
        List<float> nudgesToDelete = new List<float>();
        nudgingHistory.ForEach(nudge => {
            if (time - nudge > 5f)
            {
                nudgesToDelete.Add(nudge);
            }
        });
        nudgesToDelete.ForEach(nudge => nudgingHistory.Remove(nudge));

        int nudgeCount = 0;
        float lastNudge = -1;
        nudgingHistory.ForEach(nudge => {
            if (lastNudge != -1)
            {
                if ((nudge - lastNudge) <= 1.5f)
                {
                    nudgeCount++;
                }
            }
            lastNudge = nudge;
        });

        if (nudgeCount == 1)
        {
            messageDisplayer.SetText("Danger !");
        }

        if (nudgeCount >= 2)
        {
            nudgingHistory.Clear();
            return true;
        } else
        {
            return false;
        }
    }
}
