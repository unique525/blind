using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		GameObject button = Instantiate (Resources.Load ("button")) as  GameObject;
		//RectTransform rect = button.GetComponent<RectTransform> ();
		//rect.SetParent (gameObject.GetComponent<RectTransform> ());
		button.transform.SetParent (transform);
		

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
