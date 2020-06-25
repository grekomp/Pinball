using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pinball;

public class StartGameArea : MonoBehaviour
{

	public LevelController levelControler;

	protected void OnTriggerExit(Collider other)
	{
		var ball = other.GetComponent<Ball>();
		if (ball != null && levelControler.ActualLevelPhase == LevelPhase.Start)
		{
			levelControler.SetPhase(LevelPhase.Game);
		}
	}
}