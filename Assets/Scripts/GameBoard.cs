using UnityEngine;
using System.Collections;

public class GameBoard : MonoBehaviour {

	public int rows;
	public int cols;
	private Paintdrop[,] board;
	
	// Use this for initialization
	void Start () {
		board = new Paintdrop[rows,cols]; //8 rows and 8 columns
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitializeBoard(){
		for(int i = 0; i < rows; i++){
			for(int j = 0; j < cols; j++){
				//randomly generate a drop
				board[i,j] = RandomColorDrop();
			}
		}
	}

	Paintdrop RandomColorDrop(){
		return new Paintdrop();
	}
}
