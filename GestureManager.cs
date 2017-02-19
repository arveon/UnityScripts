using UnityEngine;
using System.Collections;

public class GestureManager : MonoBehaviour {

	GameObject currentTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		GameObject prevTarget = currentTarget;

		Vector3 headPosition = GameObject.Find("Camera").transform.position;
		Vector3 headRotation = GameObject.Find("Camera").transform.forward;
		headRotation.y = GameObject.Find("Camera").transform.forward.y;
		headRotation *= 10;

		Debug.DrawRay(headPosition, headRotation, Color.yellow);

		RaycastHit hitInfo;
		if (Physics.Raycast(headPosition, headRotation, out hitInfo))
		{
			if (hitInfo.collider.gameObject.name != "Cursor")
			{
				currentTarget = hitInfo.collider.gameObject;
			}
			currentTarget.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.yellow);
		}
		else
		{
			if(currentTarget != null)
				currentTarget.GetComponent<MeshRenderer>().material.SetColor("_Color",  Color.red);
			currentTarget = null;
		}

		////do gesture recognizer magic
		//if(currentTarget != prevTarget)
		//{

		//}

	}
}
//Debug.Log("cam global: " + headPosition);
//Debug.Log("cam real: " + Global.playerPosition);
//Vector3 headRotation = Global.headRotation;
//Vector3 headRotation = Camera.main.transform.forward;

//Debug.Log(headPosition.x + " " + headPosition.y + " " + headPosition.z);