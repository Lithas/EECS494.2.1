using UnityEngine;
using System.Collections;

public class rotateTurret : MonoBehaviour {

	public float sensitivity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool turnRight = Input.GetKey (KeyCode.RightArrow);
		bool turnLeft = Input.GetKey (KeyCode.LeftArrow);
		bool turnUp = Input.GetKey (KeyCode.UpArrow);
		bool turnDown = Input.GetKey (KeyCode.DownArrow);


		if (turnRight && !turnLeft) {
			transform.RotateAround(this.collider.bounds.center,Vector3.up,Time.deltaTime * sensitivity);
		}
		else if(turnLeft && !turnRight){
			transform.RotateAround(this.collider.bounds.center,Vector3.down, Time.deltaTime * sensitivity);
		}
	}
}
