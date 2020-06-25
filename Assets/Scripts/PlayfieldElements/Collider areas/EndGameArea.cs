using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pinball;

public class EndGameArea : MonoBehaviour
{

	public LevelController levelControler;

	protected void OnTriggerEnter(Collider other)
	{
		var ball = other.GetComponent<Ball>();
		if (ball != null)
		{
			levelControler.RemoveLife();
			Destroy(other.gameObject);
		}
	}
}
