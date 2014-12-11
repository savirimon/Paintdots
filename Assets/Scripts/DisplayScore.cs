using UnityEngine;
using System.Collections;

public class DisplayScore : MonoBehaviour {
	public int numMoves = 0;
	public int score = 0;
	public GUIText moves;

	// Use this for initialization
	void Start () {
	}

	
	// Update is called once per frame
	void Update () {
		moves.text = "Moves Achieved: " + numMoves + "      Score: " + score;
	}
}
