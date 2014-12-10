using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour {

	void OnMouseDrag(){
		collider2D.isTrigger = false;
		Screen.showCursor = false;
		Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pos.z = gameObject.transform.position.z;
		gameObject.transform.position = pos;

	}

	void OnMouseUp(){
		Screen.showCursor = true;
		collider2D.isTrigger = true;
	}
}
