using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pinball
{
	public class Plunger : MonoBehaviour
	{
		[Header("Components")]
		public Transform ballSpawnPoint;
		public LevelController levelController;
		public CollisionEventForwarder triggerArea;
		private AudioController audioController;

		[Header("Variables")]
		public Vector3Reference launchDirection;
		public FloatReference launchForce;
		public FloatReference normalizedPlungerTension;
		[Space]
		public Ball ballPrefab;


		[Header("Runtime variables")]
		public Ball readyBall;

		private List<Ball> balls = new List<Ball>();

		#region Initialization
		private void Awake()
		{
			triggerArea.OnTriggerEnterEvent += OnTriggerEnter;
			triggerArea.OnTriggerExitEvent += OnTriggerExit;
			levelController = GameObject.Find("LevelManagment").GetComponent<LevelController>();
			audioController = GameObject.Find("Main Camera").GetComponent<AudioController>();
		}
		#endregion


		#region Detecting balls
		protected void OnTriggerEnter(Collider other)
		{
			var ball = other.GetComponent<Ball>();
			if (ball != null)
			{
				readyBall = ball;
				if (levelController.ActualLevelPhase == LevelPhase.Game)
				{
					levelController.SetPhase(LevelPhase.Start);
				}
			}
		}
		protected void OnTriggerExit(Collider other)
		{
			if (other.gameObject == readyBall.gameObject)
			{
				readyBall = null;
			}
		}
		#endregion


		#region Launching balls
		[ContextMenu("Spawn Ball")]
		public void SpawnBall()
		{
			if (readyBall == null)
			{
				balls.Add(Instantiate(ballPrefab, ballSpawnPoint.position, ballSpawnPoint.rotation));
			}
		}
		public void LaunchPreparedBall()
		{
			if (readyBall)
			{
				audioController.BallShot();
				readyBall.rigidbody.AddForce(GetCurrentLaunchForceVector(), ForceMode.Impulse);
			}
		}
		#endregion


		#region Controlling the plunger
		public void SetPlungerTension(float normalizedTension)
		{
			normalizedPlungerTension.Value = normalizedTension;
		}
		[ContextMenu("Release Plunger")]
		public void ReleasePlunger()
		{
			LaunchPreparedBall();
			normalizedPlungerTension.Value = 0;
		}

		private Vector3 GetCurrentLaunchForceVector()
		{
			return launchDirection.Value * launchForce.Value * normalizedPlungerTension.Value;
		}
		#endregion
	}
}
