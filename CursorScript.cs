using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour {
	private MeshRenderer meshRenderer;
	// Use this for initialization
	void Start () 
	{
		meshRenderer = this.transform.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 headPosition = GameObject.Find("Camera").transform.position;
		Vector3 headRotation = GameObject.Find("Camera").transform.forward;
		headRotation.y = GameObject.Find("Camera").transform.forward.y;
		headRotation *= 10;


		RaycastHit hitInfo;
		if (Physics.Raycast(headPosition, headRotation, out hitInfo))
		{
			if (hitInfo.collider.gameObject.name != "Cursor")
			{
				meshRenderer.enabled = true;
				transform.position = hitInfo.point;
				transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
				Debug.Log("hits");
			}
		}
		else
			meshRenderer.enabled = false;
	}
}
