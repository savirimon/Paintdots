using UnityEngine;
using System.Collections;

//ugly code is ugly
public class Paintdrop : MonoBehaviour {

	public Color color;
	public GameBoard board;
	public bool matchingGame;
	private Vector2 location;
	private Color red = Color.red;
	private Color yellow = new Color(1,1,0);
	private Color blue = Color.blue;
	private Color orange = new Color(1, 0.57f, 0);
	private Color green = Color.green;
	private Color purple = new Color((float)160/(float)255, (float)32/(float)255, (float)240/(float)255);
	private Color poop = new Color((float)42/(float)255, (float)42/(float)255, (float)42/(float)255);
	private Color white = Color.white;

	// Use this for initialization
	void Start () {
		//if(!this.IsWhite())
			AssignColor();


		transform.renderer.material.color = color;
		
		Color col = color;
		col.a = 1f;
		color = col;
		renderer.material.color = col;

	}
	
	// Update is called once per frame
	void Update () {
		//update color, if necessary
		//if (color != renderer.material.color) {
			renderer.material.color = color;
		//}


		Color col = color;
		col.a = 0.5f;
		color = col;
		renderer.material.color = col;
	}

	public void AssignColor(){
		int rand = Random.Range (0, 4);
			switch(rand){
			case 0:
				this.color = red;
				break;
			case 1:
				this.color = yellow;
				break;
			case 2:
				this.color = blue;
				break;
			case 3:
				this.color = white;
				break;
			}
		}

	public void SetColor(Color c){
		this.color = c;
		}

	public void SetLocation(int row, int col){
		location = new Vector2(col, row);
	}

	void OnTriggerEnter2D(Collider2D other){

		Debug.Log("trigger" + other.tag);
			if (other.tag == "Drop") {
				Debug.Log("get other drop");
				Paintdrop d = other.GetComponent<Paintdrop>();
				if(this.IsAdjacent(d)){
					AudioSource.PlayClipAtPoint(board.beep, new Vector3(0,0,0));
					board.t.GetComponent<DisplayScore>().numMoves++;
					d.AddColor(this);
					Screen.showCursor = true;
					//if(matchingGame){
						board.FillIn(this.Row(), this.Col());
					//}

					this.Delete();
				}

			}

		}

	public void Delete(){
		//transform.parent.GetComponent<Renderer>().enabled = false;
		renderer.enabled = false;
		GameObject.Destroy(this.gameObject);
	}

	void AddColor(Paintdrop drop){

		//primary combinations
		if(this.IsWhite() && drop.IsWhite()){
			drop.AssignColor();
			this.AssignColor();
		}else if(this.IsWhite() || drop.IsWhite()){
			int rand = Random.Range(0,5);
			switch(rand){
				case 0:
					drop.SetColor(poop);
					this.SetColor(poop);
					break;
				case 1: 
					drop.AssignColor();
					this.AssignColor();
					break;
				case 3:
					drop.AssignColor();
					this.AssignColor();
					break;
				case 4:
					drop.AssignColor();
					this.AssignColor();
					break;
			}

		}

		if(!this.IsPrimary()){
			SetColor(poop);
			board.t.GetComponent<DisplayScore>().score-= 5;AudioSource.PlayClipAtPoint(board.eep, new Vector3(0,0,0));
		}
		
		if(this.IsBlue()){
			if(drop.IsRed()){
				SetColor(purple);
			}

			if(drop.IsYellow()){
				SetColor(green);
			}

			if(!drop.IsPrimary()){
				SetColor(poop);
				board.t.GetComponent<DisplayScore>().score-=5;AudioSource.PlayClipAtPoint(board.eep, new Vector3(0,0,0));
			}
		}

		if(this.IsRed()){
			if(drop.IsBlue()){
				SetColor(purple);
			}

			if(drop.IsYellow()){
				SetColor(orange);
			}

			if(!drop.IsPrimary()){
				SetColor(poop);
				board.t.GetComponent<DisplayScore>().score -=5;AudioSource.PlayClipAtPoint(board.eep, new Vector3(0,0,0));
			}
		}

		if(this.IsYellow()){
			if(drop.IsBlue()){
				SetColor(green);
			}

			if(drop.IsRed()){
				SetColor(orange);
			}

			if(!drop.IsPrimary()){
				SetColor(poop);
				board.t.GetComponent<DisplayScore>().score-=5;
				AudioSource.PlayClipAtPoint(board.eep, new Vector3(0,0,0));
			}
		}

	}

	public bool IsSameColor(Paintdrop d){
		return ((this.color.r == d.color.r) && (this.color.g == d.color.g) && (this.color.b == d.color.b));
	}

	public bool IsPrimary(){
		return this.IsRed() || this.IsBlue() || this.IsYellow();
	}

	bool IsRed(){
		return (this.color.r == red.r && this.color.g == red.g && this.color.b == red.b);
	}

	bool IsBlue(){
		return (this.color.r == blue.r && this.color.g == blue.g && this.color.b == blue.b);
	}

	bool IsYellow(){
		return (this.color.r == yellow.r && this.color.g == yellow.g && this.color.b == yellow.b);
	}

	bool IsWhite(){
		return (this.color.r == white.r && this.color.g == white.g && this.color.b == white.b);
	}

	public int Row(){
		return (int)location.y;
	}

	public int Col(){
		return (int)location.x;
	}

	bool IsAdjacent(Paintdrop d){
		if(Mathf.Abs(d.Row() - this.Row()) + Mathf.Abs(d.Col() - this.Col()) <= 1){
			return true;
		}
		return false;
	}
}
