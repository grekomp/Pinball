using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInput : MonoBehaviour
{
	public GameObject camera;
	public GameObject joystickPrefab;
	public Slider slider;

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

		CheckSideClick();

		DetectNudge();

		SetPlugerStreanght();
	}

	public void Zoom(float value)
	{
		camera.transform.position = camera.transform.position + new Vector3(0, 0, value / 50.0f);
	}

	private void SetPlugerStreanght()
	{
		slider.value = -joystick.Vertical;
	}

	private void CheckSideClick()
	{
		bool leftClickState = false;
		bool rightClickState = false;

		foreach (Touch touch in Input.touches)
		{
			if (touch.position.x < (Screen.width / 2))
			{
				leftClickState = true;
			}
			else
			{
				rightClickState = true;
			}

			if (touch.phase == TouchPhase.Ended)
			{
				Debug.Log((touch.position.x < (Screen.width / 2)) ? "Left click !" : "Right click !");
				//return (touch.position.x < (Screen.width / 2)) ? ClickSide.Left : ClickSide.Right;
			}
		}

		leftClick.Value = leftClickState;
		rightClick.Value = rightClickState;
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
				Debug.Log("Shake left");
			}
			if (acceleration.x > 0.4)
			{
				Debug.Log("Shake right");
			}
		}
	}
}
