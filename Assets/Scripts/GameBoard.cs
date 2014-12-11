using UnityEngine;
using System.Collections;

//ugly code is ugly
public class GameBoard : MonoBehaviour {

	public int rows;
	public int cols;
	public GUIText t;
	public AudioClip beep;
	public AudioClip eep;
	GameObject[,] board;
	
	// Use this for initialization
	void Start () {
		board = new GameObject[rows,cols]; //8 rows and 8 columns
		InitializeBoard();
		Debug.Log("initialize board");
	}
	
	// Update is called once per frame
	void Update () {

		for(int i = 0; i < rows; i++){
			HorRowMatch(i);
			VertColMatch(i);
		}

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
			int rand = Random.Range(0,3);
			if(rand > 0 ){
				Debug.Log("white drop");
				newDrop.GetComponent<Paintdrop>().SetColor(Color.white);
			}

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

	void CheckHorMatches(){
		for(int i = 0; i < rows; i++){//row
			bool match = false;
			int count = 0;

			//column
			for(int j = 0; j < 5; j++){

			}
			/*
			GameObject curr = (GameObject)board[i,startCol];
			GameObject next = (GameObject)board[i, startCol + count];
			Paintdrop currDrop = curr.GetComponent<Paintdrop>();
			Paintdrop nextDrop = curr.GetComponent<Paintdrop>();

			while(!(currDrop.IsPrimary()) && currDrop.IsSameColor(nextDrop) && count < matches - 1){
				count++;
				curr = next;
				next = (GameObject)board[i, startCol + count];
			}*/
		}
	}

	void HorRowMatch(int row){
		int matches = 0;
		for(int col = 0; col <= 5; col++){
			Paintdrop curr = board[row,col].GetComponent<Paintdrop>();
			Paintdrop next = board[row, col+matches].GetComponent<Paintdrop>();

			while(!curr.IsPrimary() && curr.IsSameColor(next) && (col + matches) < cols - 1){
				matches++;
				curr = next;
				next = board[row, col + matches].GetComponent<Paintdrop>();
			}

			if(matches >= 5){
				Debug.Log("match");
				Debug.Log("cleared");

				for(int i = 0; i < 5; i++){
					board[row,col + i].GetComponent<Paintdrop>().Delete();
					FillIn(row,col + i);
					t.GetComponent<DisplayScore>().score++;
				}

			}else if(matches >= 4){
					for(int i = 0; i < 4; i++){
					board[row,col + i].GetComponent<Paintdrop>().Delete();
					FillIn(row,col+i);
						t.GetComponent<DisplayScore>().score++;
				}

			}else if(matches >=3){
					for(int i = 0; i < 3; i++){
					board[row,col+i].GetComponent<Paintdrop>().Delete();
					FillIn(row,col+i);
						t.GetComponent<DisplayScore>().score++;
				}

			}
			matches = 0;
		}
	}

		void VertColMatch(int col){
		int matches = 0;
		for(int row = 0; row < 5; row++){
			Paintdrop curr = board[row,col].GetComponent<Paintdrop>();
			Paintdrop next = board[row+matches, col].GetComponent<Paintdrop>();

			while(!curr.IsPrimary() && curr.IsSameColor(next) && (row+matches) < rows - 1){

				curr = next;
				next = board[row+matches, col].GetComponent<Paintdrop>();
				matches++;
			}

			if(matches > 5){
				Debug.Log("match");
				Debug.Log("cleared");
				for(int i = 0; i <= 5; i++){
					board[row + i,col].GetComponent<Paintdrop>().Delete();
					FillIn(row + i,col);
					t.GetComponent<DisplayScore>().score++;
				}

			}else if(matches > 4){
					for(int i = 0; i <= 4; i++){
					board[row + i,col].GetComponent<Paintdrop>().Delete();
					FillIn(row + i,col);
					t.GetComponent<DisplayScore>().score++;
				}

			}else if(matches > 3){
					for(int i = 3; i >= 0; i--){
					board[row + i,col].GetComponent<Paintdrop>().Delete();
					FillIn(row + i,col);
					t.GetComponent<DisplayScore>().score++;
				}

			}
			matches = 0;
		}
	}

	void HorRowMatch5(int row){
		int matches = 1;
		for(int col = 0; col < 3; col++){
			Paintdrop curr = board[row,col].GetComponent<Paintdrop>();
			Paintdrop next = board[row, col+matches].GetComponent<Paintdrop>();
			while(!curr.IsPrimary() && curr.IsSameColor(next) && matches < 5){
				matches++;
				curr = next;
				next = board[row, col + matches].GetComponent<Paintdrop>();
			}

			if(matches >= 5){
				//Debug.Log("match");
				for(int i = 0; i <= 5; i++){
					board[row,i].GetComponent<Paintdrop>().Delete();
					FillIn(row,i);
				}
			}else if(matches >= 4){

			}else if(matches >=3){
				
			}
			matches = 1;
			
		}
	}

	void HorRowMatch4(int row){
		int matches = 1;

		for(int col = 0; col < 4; col++){
			Paintdrop curr = board[row,col].GetComponent<Paintdrop>();
			Paintdrop next = board[row, col+matches].GetComponent<Paintdrop>();

			while(!curr.IsPrimary() && curr.IsSameColor(next) && matches < 4){
				matches++;
				curr = next;
				next = board[row, col + matches].GetComponent<Paintdrop>();
			}

			if(matches >= 4){
				Debug.Log("match");
				for(int i = 0; i <= 4; i++){
					board[row,i].GetComponent<Paintdrop>().Delete();
					FillIn(row,i);
				}
			}
			
		}
	}

	void HorRowMatch3(int row){
		int matches = 1;

		for(int col = 0; col < 5; col++){
			Paintdrop curr = board[row,col].GetComponent<Paintdrop>();
			Paintdrop next = board[row, col+matches].GetComponent<Paintdrop>();

			while(!curr.IsPrimary() && curr.IsSameColor(next) && matches < 3){
				matches++;
				curr = next;
				next = board[row, col + matches].GetComponent<Paintdrop>();
			}

			if(matches >= 3){
				Debug.Log("match");
				for(int i = 0; i <= 3; i++){
					board[row,i].GetComponent<Paintdrop>().Delete();
					FillIn(row,i);
				}
			}
		}
	}


}
