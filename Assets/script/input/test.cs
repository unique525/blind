using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{
	Animator animator;
	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator> ();
		

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey (KeyCode.A)) {
			animator.CrossFade ("normal", 0.1f);
			animator.speed = 1;
		} else if (Input.GetKey (KeyCode.D)) {
			animator.speed = 1;
		} else {
			animator.speed = 0;
		}
	}
}
