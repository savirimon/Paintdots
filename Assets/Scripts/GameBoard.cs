using UnityEngine;
using System.Collections;

public class GameBoard : MonoBehaviour {

	public int rows;
	public int cols;
	GameObject[,] board;
	
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
				newDrop.transform.position = new Vector2(j,i);
				newDrop.GetComponent<Paintdrop>().SetLocation(i,j);
				newDrop.GetComponent<Paintdrop>().board = this;
				board[i,j] = newDrop;
			}
		}
	}

	//pass in the location of missing drop
	public void FillIn(int row, int col){

		if(row == 7){
			Debug.Log("row is highest");
			Debug.Log("instantiate drop");
			Debug.Log("Row: " + row + " Col: " + col);
			GameObject newDrop = (GameObject)Instantiate(Resources.Load("Drop"));
			Debug.Log("set position");
			newDrop.transform.position = new Vector2(col, row);
			newDrop.GetComponent<Paintdrop>().SetLocation(row,col);
			newDrop.GetComponent<Paintdrop>().board = this;
			Debug.Log("save drop");
			board[row, col] = newDrop;
		}else{
			Debug.Log("Row: " + row + " Col: " + col);
			//move the drop one row above it, down
						Debug.Log("move drop above one row down");
			float tempY = board[row+1, col].transform.position.y;
			/*
			while(tempY != row){
				board[row+1, col].transform.position = new Vector2(col, tempY);
				tempY -= .1f;
			}*/
			board[row+1, col].transform.position = new Vector2(col, row);
			board[row+1, col].GetComponent<Paintdrop>().SetLocation(row, col);
			//copy the drop
			Debug.Log("Copy the temp drop");
			GameObject tempDrop = board[row+1, col];


			//destroy the original in the list
			Debug.Log("delete");
			//board[row+1,col].GetComponent<Paintdrop>().Delete();
			board[row+1, col] = null;


			//save it in the board
			Debug.Log("save it on the board");
			board[row, col] = tempDrop;


			FillIn(row+1, col);
		}

	}

	void CheckMatches(){

	}

	void CheckHorMatches(){

	}

	void CheckVertMatches(){
		
	}


}
