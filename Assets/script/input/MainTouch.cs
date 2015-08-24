using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainTouch : MonoBehaviour
{

	public List<ActionTouch> actionTouchs = new List<ActionTouch> ();

	public List<Touch> activeTouch = new List<Touch> ();
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.touchCount > 0) {
			Touch touch;
			for (int i=0; i<Input.touchCount; i++) {
				touch = Input.touches [i];
				if (!(activeTouch.Contains (touch))) {


					/** button 
					if (true) {

						break;
					}**/

				
					/** weakpoint 
					if (true) {
					
						break;
					}**/

				
					/** move **/
					if (touch.position.x < Screen.width / 2) {
						if (true) {	//行动是否已经分配了touch

						}
						break;
					}


				}
			}
		}
	}
}
