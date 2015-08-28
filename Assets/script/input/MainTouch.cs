using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainTouch : MonoBehaviour
{


	public List<int> activefingers = new List<int> ();
	public List<ActionTouch> actionTouchList = new List<ActionTouch>();
	public Touch touch;
	public int fingerId;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.touchCount > 0) {
			for (int i=0; i<Input.touchCount; i++) {
				touch = Input.touches [i];
				fingerId=touch.fingerId;
				if (!(activefingers.Contains (fingerId))) {


					/** button **/
					if (true) {
						for(int j=0;j<actionTouchList.Count;j++){
							if(Vector2.Distance(touch.position,actionTouchList.transform.position)<=60){

							};
						}
						break;
					}

				
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
