using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TmpInput : MonoBehaviour
{
	[Header("Options")]
	public KeyCode leftKey;
	public KeyCode rightKey;
	public KeyCode spawnExtraBallKey;

	[Header("Components")]
	public LevelController levelController;

	[Header("Variables")]
	public BoolReference leftPressed;
	public BoolReference rightPressed;


	[Header("Events")]
	public GameEventHandler onLeftPressed;
	public GameEventHandler onLeftReleased;
	public GameEventHandler onRightPressed;
	public GameEventHandler onRightReleased;
	public GameEventHandler onSpawnExtraBallPressed;

	bool leftClickState = false;
	bool rightClickState = false;

	public void Update()
	{
		leftPressed.Value = Input.GetKey(leftKey);
		rightPressed.Value = Input.GetKey(rightKey);
		/*
		if (levelController.canTriggerFlippers)
		{
			foreach (Touch touch in Input.touches)
			{
				if (touch.phase == TouchPhase.Began)
				{
					if ((touch.position.x < (Screen.width / 2)))
					{
						leftClickState = true;
						onLeftPressed.Raise();
					}
					else
					{
						rightClickState = true;
						onRightPressed.Raise();
					}
				}

				if (touch.phase == TouchPhase.Ended)
				{
					if ((touch.position.x < (Screen.width / 2)))
					{
						leftClickState = false;
						onLeftReleased.Raise();
					}
					else
					{
						rightClickState = false;
						onRightReleased.Raise();
					}
				}
			}
		} else
		{
			leftClickState = false;
			rightClickState = false;
		}

		leftPressed.Value = leftClickState;
		rightPressed.Value = rightClickState;*/
		
		if (Input.GetKeyDown(leftKey)) onLeftPressed.Raise();
		if (Input.GetKeyUp(leftKey)) onLeftReleased.Raise();

		if (Input.GetKeyDown(rightKey)) onRightPressed.Raise();
		if (Input.GetKeyUp(rightKey)) onRightReleased.Raise();
		
		if (Input.GetKeyDown(spawnExtraBallKey)) onSpawnExtraBallPressed.Raise();
	}
}
