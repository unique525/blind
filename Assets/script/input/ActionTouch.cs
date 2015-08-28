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
	public int fingerId=0;
	
	public int nowFrameIndex;
	
	void Start ()
	{
		this.screenPosition = this.GetComponent<RectTransform> ().position;
		framePositions.Add (this.screenPosition);
		framePositions.Add (this.screenPosition + new Vector2 (60, 20));
		framePositions.Add (this.screenPosition + new Vector2 (120, 40));
		

		//for test
		GameObject sub1 = Instantiate(Resources.Load("sub")) as GameObject;
		sub1.transform.SetParent(GameObject.Find("Canvas").transform);
		sub1.transform.position=framePositions[1];
		GameObject sub2 =  Instantiate(Resources.Load("sub")) as GameObject;
		sub2.transform.SetParent(GameObject.Find("Canvas").transform);
		sub2.transform.position=framePositions[2];
		//end
		
	}
	
	void Update ()
	{
		if (Input.touchCount > 0) {
			if(active){
				if(fingerId>0){
					for(int i=0;i<Input.touchCount;i++){
					}
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
