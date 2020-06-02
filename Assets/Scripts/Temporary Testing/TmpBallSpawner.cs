using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TmpBallSpawner : MonoBehaviour
{
	[Header("Variables")]
	public GameObject ballPrefab;

	public void SpawnBall()
	{
		Instantiate(ballPrefab, transform.position, transform.rotation);
	}
}
