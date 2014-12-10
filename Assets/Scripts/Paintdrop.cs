using UnityEngine;
using System.Collections;

public class Paintdrop : MonoBehaviour {

	public Color color;
	private Color red = Color.red;
	private Color yellow = new Color(1,1,0);
	private Color blue = Color.blue;
	private Color orange = new Color(1, (float)165/(float)255, 0);
	private Color green = Color.green;
	private Color purple = new Color((float)160/(float)255, (float)32/(float)255, (float)240/(float)255);

	// Use this for initialization
	void Start () {
		if(color == null){
			AssignColor();
		}

		if (color != renderer.material.color) {
			renderer.material.SetColor ("_Color", color);
		}
		Color col = color;
		col.a = 0.5f;
		color = col;
		renderer.material.color = col;

	}
	
	// Update is called once per frame
	void Update () {
		//update color, if necessary
		//if (color != renderer.material.color) {
			renderer.material.SetColor ("_Color", color);
		//}


		Color col = color;
		col.a = 0.5f;
		color = col;
		renderer.material.color = col;
	}

	void AssignColor(){
		int rand = Random.Range (0, 2);
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
			}
		}

	void SetColor(Color c){
		this.color = c;
		}

	void OnTriggerEnter2D(Collider2D other){
			if (other.tag == "Drop") {
				Paintdrop d = other.gameObject.GetComponent<Paintdrop>();
				Debug.Log("drop");
				d.SetColor(purple);
				SetColor(green);
				GameObject.Destroy(this.gameObject);
			}

		}

	void AddColor(Color c){
		//primary combinations

		//red
		if (this.color == red) {
				if(c == blue){
					SetColor (purple);
				}else if(c == yellow){
					SetColor (orange);
				}
		}

		//yellow
		if (this.color == yellow) {
			if (c == yellow) {
				if(color == blue){
					SetColor (green);
				}else if(color == red){
					SetColor (orange);
				}
			} else if (c == blue) {
				
			}
		}
		//blue + red


		}

}
