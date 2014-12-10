using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	Paintdrop held;

	Vector3 heldLastPos;


	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("player");
		if (Input.GetMouseButtonDown(0)){
			Debug.Log ("click");
			RaycastHit hit;
			if(Physics.Raycast (camera.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity)){
				Debug.Log("hit");
				if(hit.transform.tag == "Drop"){
					Debug.Log("drop");
					Paintdrop p = hit.transform.gameObject.GetComponent<Paintdrop>();
					GrabDrop(p);
					Debug.Log ("grabbed");
				}
			}
		}

		if(Input.GetMouseButtonUp(0)){
			ReleaseDrop();
		}

		if(held != null){
			Debug.Log ("drop not null");
			Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePoint.y = 0;
			held.transform.position = mousePoint;
		}
	}

	void GrabDrop(Paintdrop drop){
		Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePoint.y = 0;

		held = drop;
		heldLastPos = held.transform.position;
	}

	void ReleaseDrop(){
		if(held != null){
			held = null;
		}
	}
}
