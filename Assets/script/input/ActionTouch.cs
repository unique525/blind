using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using System.Collections;
using System.Collections.Generic;

public class ActionTouch : MonoBehaviour
{
	
	public Vector2 screenPosition;
	public List<Vector2> framePositions = new List<Vector2> ();
	public bool active = false;
	public bool ching = false;
	public Touch touch;
	
	public int nowFrameIndex;
	
	void Start ()
	{
		this.screenPosition = this.GetComponent<RectTransform> ().position;
		framePositions.Add (this.screenPosition);
		framePositions.Add (this.screenPosition + new Vector2 (60, 20));
		framePositions.Add (this.screenPosition + new Vector2 (120, 40));
		
		
		//GameObject sub1 =  Resources.Load("sub") as GameObject;
		//sub1.GetComponent<RectTransform>().SetParent(GameObject.Find("Canvas"));
		//sub1.GetComponent<RectTransform>().position=framePositions[1];
		//GameObject sub2 =  Resources.Load("sub") as GameObject;
		//sub2.GetComponent<RectTransform>().SetParent(Canvas);
		//sub2.GetComponent<RectTransform>().position=framePositions[2];
		
		
	}
	
	void Update ()
	{
		if (Input.touchCount > 0) {
			touch = Input.touches [0];
			Debug.Log (touch.position + "--" + framePositions [0]);
			if (active == false && Vector2.Distance (touch.position, framePositions [0]) < 20) {
				Debug.Log (Input.touches [0].position);
				active = true;
				nowFrameIndex = 0;
			}
			
			if (active) {
				Debug.Log (touch.phase);
				switch (touch.phase) {
				case TouchPhase.Ended:
					if (!ching) {
						Debug.Log ("Action(no chi)");
					}
					active = false;
					break;
				case TouchPhase.Moved:
					if (Vector2.Distance (touch.position, framePositions [nowFrameIndex + 1]) < 50) {
						ching = true;
						nowFrameIndex++;
						Debug.Log ("Frame to:" + nowFrameIndex);
						if (nowFrameIndex == framePositions.Count) {
							Debug.Log ("Action(chi)");
						}
						active = false;
					}
					break;
				}
			}
		}
	}
	
	
	public void SetActionFrame (int frameIndex)
	{
		if (Mathf.Abs (nowFrameIndex - frameIndex) == 1) {
			nowFrameIndex = frameIndex;
			Debug.Log ("frame:" + frameIndex);
		}
	}
	
	
	
}
