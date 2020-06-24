using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pinball
{
	public class HittableTarget : MonoBehaviour
	{
		[Header("Variables")]
		public BoolReference isHittable;

		[Header("Events")]
		public GameEventHandler onHit;


		#region Hit detection
		private void OnCollisionEnter(Collision collision)
		{
			if (isHittable && collision.gameObject.layer == LayerMask.NameToLayer("Ball"))
			{
				isHittable.Value = false;
				onHit.Raise(this, collision.gameObject);
			}
		}
		#endregion

		#region State setting
		public void SetHittable(bool hittable)
		{
			isHittable.Value = hittable;
		}
		#endregion
	}
}
