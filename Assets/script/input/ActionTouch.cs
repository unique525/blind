using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

using System.Collections;
using System.Collections.Generic;

public class ActionTouch : MonoBehaviour
{
	public Vector2 screenPosition;


	public Vector2 startPosition;
	public Vector2 lastPosition;
	public List<Vector2> standSubPositions = new List<Vector2> ();
	public List<Vector2> subPositions = new List<Vector2> ();
	public int indexOfNext=-1;

	//public float distanceFromLastPosition;
	public float distanceToNextInLastFrame;
	public float distancePerSpeed=5;

	public bool active = false;
	public bool ching = false;
	public Touch touch;
	public int fingerId=-1;
	
	public float pointerLineDistance=10;
	public float leftPointerLine=0;
	public float rightPointerLine=0;
	public int pointer=0;
	void Start ()
	{
		this.screenPosition = this.GetComponent<RectTransform> ().position;
		standSubPositions.Add (new Vector2(90, -30));
		standSubPositions.Add (new Vector2(180, -60));
		

	}
	
	void Update ()
	{
		if (Input.touchCount > 0) {
			if(active){
				if(fingerId>=0){
					for(int i=0;i<Input.touchCount;i++){
						if(Input.touches[i].fingerId==fingerId){
							touch=Input.touches[i];
							switch(touch.phase){
							case (TouchPhase.Ended):
								this.UnsetFinger();
								break;
							case (TouchPhase.Moved):
								this.FingerMove();
								break;
							}
						}
					}
				}
			}
		}
	}

	
	public void SetFinger(int fingerId){
		this.active=true;
		this.fingerId=fingerId;
		this.startPosition=touch.position;

		this.leftPointerLine=touch.position.x-pointerLineDistance;
		this.rightPointerLine=touch.position.x+pointerLineDistance;

		//Debug.Log (touch.position);
		//Debug.Log (leftPointerLine);
		//Debug.Log(rightPointerLine);
	}

	public void UnsetFinger(){
		this.active=false;
		this.fingerId=-1;
		this.startPosition=Vector2.zero;
		this.pointer=0;
	}

	public void FingerMove(){

		//this.distanceFromLastPosition=Vector2.Distance(this.lastPosition,touch.position);
		this.lastPosition=touch.position;

		if(pointer==0){
			if(touch.position.x<=leftPointerLine){
				pointer=-1;
				SetSubPoint(pointer);
				//Debug.Log ("Left");
			}else if(touch.position.x>=rightPointerLine){
				pointer=1;
				SetSubPoint(pointer);
				//Debug.Log ("Right");
			}else{
				//do nothing
			}
		}else{
			if(indexOfNext>=0){
				float distance=Vector2.Distance(touch.position,subPositions[indexOfNext]);
				float speed=(distanceToNextInLastFrame-distance)/distancePerSpeed;
				if(speed>0){
					Debug.Log (distanceToNextInLastFrame+"-"+distance+"-"+speed);
					distanceToNextInLastFrame=distance;
				}
			}
		}
	}


	public void SetSubPoint(int pointer){

		for(int i=0;i<standSubPositions.Count;i++){
			subPositions.Add(screenPosition + new Vector2(pointer*standSubPositions[i].x,standSubPositions[i].y));
		}
		indexOfNext=0;
		distanceToNextInLastFrame=Vector2.Distance(subPositions[indexOfNext],touch.position);



		//for test
		GameObject sub;
		for(int i=0;i<subPositions.Count;i++){
			sub = Instantiate(Resources.Load("sub")) as GameObject;
			sub.transform.SetParent(GameObject.Find("Canvas").transform);
			sub.transform.position=subPositions[i];
		}
		//end

		
	}
}
