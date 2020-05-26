using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
	[Header("Settings")]
	public FloatReference extensionSpeed;
	public FloatReference retractionSpeed;
	public Vector3 rotationInactive;
	public Vector3 rotationActive;


	[Header("Components")]
	public new Rigidbody rigidbody;


	[Header("Input Variables")]
	public BoolReference flipperOn;


	[Header("Runtime Variables")]
	public float animationNormalizedTime = 0f;


	#region Animation
	public void Update()
	{
		UpdateAnimationTime();
		UpdateRotation();
	}
	public void UpdateAnimationTime()
	{
		animationNormalizedTime += (flipperOn ? extensionSpeed : -retractionSpeed) * Time.deltaTime;
		animationNormalizedTime = Mathf.Clamp01(animationNormalizedTime);
	}
	public void UpdateRotation()
	{
		rigidbody.MoveRotation(transform.parent.rotation * Quaternion.Euler(Vector3.Lerp(rotationInactive, rotationActive, animationNormalizedTime)));
	}
	#endregion
}
