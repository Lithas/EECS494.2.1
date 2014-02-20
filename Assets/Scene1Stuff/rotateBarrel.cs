using UnityEngine;
using System.Collections;

public class rotateBarrel : MonoBehaviour {

	public float sensitivity;
	public float upperLimit;
	public float lowerLimit;

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
		bool turnRight = Input.GetKey (KeyCode.RightArrow);
		bool turnLeft = Input.GetKey (KeyCode.LeftArrow);
		bool turnUp = Input.GetKey (KeyCode.UpArrow);
		bool turnDown = Input.GetKey (KeyCode.DownArrow);
		Debug.Log (this.transform.localRotation.x);
		if (turnUp && !turnDown && this.transform.localRotation.x > upperLimit) {
			transform.RotateAround(this.collider.bounds.center,Vector3.left, Time.deltaTime * sensitivity);
		}
		else if(turnDown && !turnUp && this.transform.localRotation.x < lowerLimit){
			transform.RotateAround(this.collider.bounds.center,Vector3.right, Time.deltaTime * sensitivity);
		}
	}
}
