using UnityEngine;
using System.Collections;

public class GameBoard : MonoBehaviour {

	public int rows;
	public int cols;
	private GameObject[,] board;
	
	// Use this for initialization
	void Start () {
		board = new GameObject[rows,cols]; //8 rows and 8 columns
		InitializeBoard();
		Debug.Log("initialize board");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitializeBoard(){
		for(int i = 0; i < rows; i++){
			for(int j = 0; j < cols; j++){
				//randomly generate a drop
				GameObject newDrop = (GameObject)Instantiate(Resources.Load("Drop"));
				newDrop.transform.position = new Vector2(i,j);
				board[i,j] = newDrop;
			}
		}
	}

}
