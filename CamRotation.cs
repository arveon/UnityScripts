using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotation : MonoBehaviour {

	private Vector2 mouseLook;

	public float sensitivity = 10f;

	GameObject character;

	// Use this for initialization
	void Start ()
	{
		character = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector2 mouse_delta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
		mouse_delta *= sensitivity;

		mouseLook += mouse_delta;

		transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
		character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

	}
}
