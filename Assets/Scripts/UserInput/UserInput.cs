﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UserInput : MonoBehaviour
{
	public GameObject camera;
	public GameObject joystickPrefab;
	public Slider slider;
	public NudgeController nudgeController;
	public AchivementControlller achivementController;

	[Space]
	public BoolReference leftClick;
	public BoolReference rightClick;

	private FixedJoystick joystick;

	float accelerometerUpdateInterval = 1.0f / 60.0f;
	// The greater the value of LowPassKernelWidthInSeconds, the slower the
	// filtered value will converge towards current input sample (and vice versa).
	float lowPassKernelWidthInSeconds = 1.0f;
	// This next parameter is initialized to 2.0 per Apple's recommendation
	float shakeDetectionThreshold = 1.0f;
	float lowPassFilterFactor;
	Vector3 lowPassValue;

	public enum ClickSide
	{
		Left,
		Right,
		None
	}

	private void Awake()
	{
		joystick = joystickPrefab.GetComponent<FixedJoystick>();
	}

	void Start()
	{
		lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
		shakeDetectionThreshold *= shakeDetectionThreshold;
		lowPassValue = Input.acceleration;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.touchCount >= 2)
		{
			Zoom(CalcualatePinchDistance());
		}

		DetectNudge();

		SetPlugerStreanght();
	}

	public void Zoom(float value)
	{
		achivementController.PinchToZoomAchivement();
		//camera.transform.position = camera.transform.position + new Vector3(0, 0, value / 50.0f);
	}

	private void SetPlugerStreanght()
	{
		slider.value = -joystick.Vertical;
	}

	private float CalcualatePinchDistance()
	{
		Touch touchOne = Input.GetTouch(0);
		Touch touchTwo = Input.GetTouch(1);
		Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
		Vector2 touchTwoPrevPos = touchTwo.position - touchTwo.deltaPosition;
		float previousMagnitude = (touchOnePrevPos - touchTwoPrevPos).magnitude;
		float currentMagnitude = (touchOne.position - touchTwo.position).magnitude;
		return currentMagnitude - previousMagnitude;
	}

	private void DetectNudge()
	{
		Vector3 acceleration = Input.acceleration;
		lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
		Vector3 deltaAcceleration = (acceleration - lowPassValue);

		if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
		{
			if (acceleration.x < -0.4)
			{
				nudgeController.Nudge(NudgeSide.Left);
			}
			if (acceleration.x > 0.4)
			{
				nudgeController.Nudge(NudgeSide.Right);
			}
		}
	}
}
