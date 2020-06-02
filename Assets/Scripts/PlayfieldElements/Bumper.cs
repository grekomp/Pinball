using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pinball
{
	public class Bumper : MonoBehaviour
	{
		[Header("Variables")]
		public FloatReference power = new FloatReference(5f);

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.layer == LayerMask.NameToLayer("Ball"))
			{
				Vector3 launchDirection = (other.transform.position - transform.position).normalized;
				Vector3 launchVelocity = launchDirection * power;

				other.attachedRigidbody.velocity = launchVelocity;
			}
		}
	}
}