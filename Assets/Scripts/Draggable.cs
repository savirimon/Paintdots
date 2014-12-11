using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour {
	public float offset = 1f;
	private float count = 0f;
	private Vector3 prev;
	private Vector3 curr;

	void OnMouseDrag(){
		prev = gameObject.transform.position;
		curr = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		curr.z = gameObject.transform.position.z;
		collider2D.isTrigger = false;
		collider2D.tag = "Moving";
		Screen.showCursor = false;

		gameObject.transform.position = curr;
	}

	void OnMouseUp(){
		gameObject.transform.position = new Vector2((float)gameObject.GetComponent<Paintdrop>().Col(), (float)gameObject.GetComponent<Paintdrop>().Row());
		Screen.showCursor = true;
		collider2D.isTrigger = true;
		collider2D.tag = "Drop";
	}
}
