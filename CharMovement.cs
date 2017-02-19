using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
	public float movement_speed = 5f;


	// Use this for initialization
	void Start ()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Global.playerPosition = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		float x_mov = Input.GetAxis("Horizontal") * movement_speed * Time.deltaTime;
		float z_mov = Input.GetAxis("Vertical") * movement_speed * Time.deltaTime;
		float y_mov = Input.GetAxis("Jump") * movement_speed * Time.deltaTime;

		transform.Translate(x_mov, y_mov, z_mov);
		Global.playerPosition += new Vector3(x_mov, y_mov, z_mov);
		//Debug.Log(Global.playerPosition.x + " " + Global.playerPosition.y + " " + Global.playerPosition.z);

		if (Input.GetKeyDown(KeyCode.Escape))
			Cursor.lockState = CursorLockMode.None;
	}
}
