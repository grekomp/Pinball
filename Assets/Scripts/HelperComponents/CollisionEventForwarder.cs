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

		private void OnCollisionEnter(Collision collision)
		{
			OnCollisionEnterEvent?.Invoke(collision);
		}
	}
}
