using Athanor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Pinball
{
	public class SlingShot : MonoBehaviour
	{
		[Header("Components")]
		public CollisionEventForwarder collisionEventForwarder;
		public ScoreObstacle scoreObstacle;

		[Header("Variables")]
		public FloatReference power = new FloatReference(5f);
		public Vector3 baseLaunchDirection;
		public FloatReference relativeDirectionFactor;

		private void Awake()
		{
			collisionEventForwarder.OnCollisionEnterEvent += OnTriggerAreaCollisionEnter;
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawLine(transform.position, transform.position + baseLaunchDirection * 0.1f);
		}

		private void OnTriggerAreaCollisionEnter(Collision collision)
		{
			if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ball"))
			{
				ShootBall(collision);
			}
		}

		private void ShootBall(Collision collision)
		{
			Vector3 launchDirection = (baseLaunchDirection.normalized + (collision.collider.transform.position - transform.position).normalized * relativeDirectionFactor).normalized;
			Vector3 launchVelocity = launchDirection * power;

			scoreObstacle.Hit();
			collision.collider.attachedRigidbody.velocity = launchVelocity;
		}
	}
}
