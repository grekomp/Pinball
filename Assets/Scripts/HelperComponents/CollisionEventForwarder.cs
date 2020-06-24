using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Pinball
{
	public class CollisionEventForwarder : MonoBehaviour
	{
		public event Action<Collision> OnCollisionEnterEvent;
		public event Action<Collider> OnTriggerEnterEvent;
		public event Action<Collider> OnTriggerExitEvent;


		private void OnCollisionEnter(Collision collision)
		{
			OnCollisionEnterEvent?.Invoke(collision);
		}

		private void OnTriggerEnter(Collider other)
		{
			OnTriggerEnterEvent?.Invoke(other);
		}

		private void OnTriggerExit(Collider other)
		{
			OnTriggerExitEvent?.Invoke(other);
		}
	}
}
