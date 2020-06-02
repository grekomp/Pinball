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

		[Header("Variables")]
		public FloatReference power = new FloatReference(5f);
		public Vector3 baseLaunchDirection;
		public FloatReference relativeDirectionFactor;

		private void Awake()
		{
			collisionEventForwarder.OnCollisionEnterEvent += OnCollisionEnter;
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawLine(transform.position, transform.position + baseLaunchDirection * 0.1f);
		}

		private void OnCollisionEnter(Collision collision)
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

			collision.collider.attachedRigidbody.velocity = launchVelocity;
		}
	}
}
