using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour {

	public GameBoard board;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//reset
		if (Input.GetKeyDown (KeyCode.Return)) {
			Reset();
		}
	}

	void Reset(){
		Application.LoadLevel(Application.loadedLevel);	
	}

	void CheckMatches(){

	}

	void CheckHorMatches(){

	}

	void CheckVertMatches(){
		
	}

	
}
