using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionPanel : MonoBehaviour
{

	//public List<Vector2> actionButtons = new List<Vector2>();
	// Use this for initialization
	void Start ()
	{
		GameObject button = Instantiate (Resources.Load ("button")) as  GameObject;
		button.transform.SetParent (transform);
		//button.transform.position = new Vector2 (100, 0);
		button.transform.position = new Vector2 (440, 150);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
