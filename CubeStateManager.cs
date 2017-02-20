using UnityEngine;
using System.Collections;

public class CubeStateManager : MonoBehaviour {

	Constants.State state;
	Vector3 originalScale;
	Vector3 deltaScale;
	float dis;
	bool distanceSet;


	// Use this for initialization
	void Start () {
		state = Constants.State.None;
		deltaScale = new Vector3(0.01f, 0.01f, 0.01f);
		originalScale = transform.localScale;
		distanceSet = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch(state)
		{
			case Constants.State.None:
				//GetComponent<Renderer>().material.color = Color.yellow;
				//GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
				foreach(Renderer rend in GetComponentsInChildren<Renderer>())
				{
					rend.material.color = Color.white;
				}
				break;
			case Constants.State.Targeted:
				//GetComponent<Renderer>().material.color = Color.yellow;
				//GetComponent<MeshRenderer>().material.SetColor("_Color", Color.yellow);
				foreach (Renderer rend in GetComponentsInChildren<Renderer>())
				{
					rend.material.color = Color.yellow;
				}
				break;
			case Constants.State.Selected:
				//GetComponent<Renderer>().material.color = Color.red;
				//GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
				foreach (Renderer rend in GetComponentsInChildren<Renderer>())
				{
					rend.material.color = Color.red;
				}
				break;
		}

		if (state == Constants.State.Selected)
		{
			transform.localScale = originalScale + deltaScale;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			transform.position = ray.GetPoint(dis);
			//transform.rotation = Camera.main.transform.rotation;

			//needed here because doesn't change above, for some reason
			foreach (Renderer rend in GetComponentsInChildren<Renderer>())
			{
				rend.material.color = Color.red;
			}
		}
		else
			transform.localScale = originalScale;
	}

	public void Target(float distance)
	{
		if (!distanceSet)
		{
			dis = distance;
			distanceSet = true;
		}
		if (state != Constants.State.Selected)
			state = Constants.State.Targeted;
	}

	public void Dehighlight()
	{
		distanceSet = false;
		state = Constants.State.None;
	}

	public void Select()
	{
		state = Constants.State.Selected;
	}

}
