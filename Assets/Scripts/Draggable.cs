using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour {
	public float offset = 1f;
	private float count = 0f;
	private Vector3 prev;
	private Vector3 curr;

	void OnMouseDrag(){
		curr = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		curr.z = gameObject.transform.position.z;
		collider2D.isTrigger = false;
		collider2D.tag = "Moving";
		Screen.showCursor = false;
		/*
		if(prev != null){
			if(Mathf.Abs(curr.x - prev.x) > Mathf.Abs(curr.y - prev.y)){
				count += Mathf.Abs(curr.x - prev.x);
				gameObject.transform.position = new Vector2(curr.x, Mathf.Round(prev.y));
			}else{
				gameObject.transform.position = new Vector2(Mathf.Round(prev.x), curr.y);
			}

				prev = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				prev.z = gameObject.transform.position.z;
			}*/

		gameObject.transform.position = curr;
	}

	void OnMouseUp(){
		Screen.showCursor = true;
		collider2D.isTrigger = true;
		collider2D.tag = "Drop";
	}
}
