using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TmpInput : MonoBehaviour
{
	[Header("Options")]
	public KeyCode leftKey;
	public KeyCode rightKey;
	public KeyCode spawnExtraBallKey;


	[Header("Variables")]
	public BoolReference leftPressed;
	public BoolReference rightPressed;


	[Header("Events")]
	public GameEventHandler onLeftPressed;
	public GameEventHandler onLeftReleased;
	public GameEventHandler onRightPressed;
	public GameEventHandler onRightReleased;
	public GameEventHandler onSpawnExtraBallPressed;


	public void Update()
	{
		leftPressed.Value = Input.GetKey(leftKey);
		rightPressed.Value = Input.GetKey(rightKey);

		if (Input.GetKeyDown(leftKey)) onLeftPressed.Raise();
		if (Input.GetKeyUp(leftKey)) onLeftReleased.Raise();

		if (Input.GetKeyDown(rightKey)) onRightPressed.Raise();
		if (Input.GetKeyUp(rightKey)) onRightReleased.Raise();

		if (Input.GetKeyDown(spawnExtraBallKey)) onSpawnExtraBallPressed.Raise();
	}
}
