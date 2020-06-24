using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Pinball
{
	[RequireComponent(typeof(Rigidbody))]
	public class Ball : MonoBehaviour
	{
		public new Rigidbody rigidbody;
	}
}
