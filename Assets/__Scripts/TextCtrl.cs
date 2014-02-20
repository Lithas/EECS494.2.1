using UnityEngine;
using System.Collections;

public class TextCtrl : MonoBehaviour {

	public string itemName;
	public int firstLevel;
	public string cameraName;
	public float speed;

	private Quaternion startRot;
	private Quaternion targetRot;
	public float time = 0;

	private Color baseColor;

	private Camera theCamera;
	private bool turnCamera;

	void Start(){
		baseColor = renderer.material.color;
		if(cameraName != ""){
			theCamera = GameObject.Find(cameraName).camera;
			startRot = theCamera.transform.rotation;
		}
	}
	void Update(){
		if(turnCamera){
			Vector3 target = GameObject.Find ("Option Menu").transform.position;
			Vector3 dir = target - theCamera.transform.position;
			Quaternion targetRotation = Quaternion.LookRotation(dir);
			Quaternion old = theCamera.transform.rotation;
			theCamera.transform.rotation = Quaternion.Slerp(theCamera.transform.rotation, targetRotation, Time.deltaTime * time);
			time += .01f;
			if(Quaternion.Angle(theCamera.transform.rotation, targetRotation) < .01){
				Debug.Log("done");
				turnCamera = false;
			}
		}
	}
	void OnMouseEnter(){
		//highlight
		renderer.material.color = Color.yellow;
	}

	void OnMouseExit(){
		renderer.material.color = baseColor;
	}

	void OnMouseUp(){
		Debug.Log (itemName);
		switch(itemName){
			case "Play":
				StartGame();
				break;
			case "Options":
				OpenOptions();
				break;
			case "Quit":
				Quit();
				break;
			//ADD ADDITIONAL SCREENS
			//OR FUNCTIONS HERE AS YOU 
			//WANT THEM
			default:
					break;
		}
	}
	


	void StartGame(){
		Application.LoadLevel(firstLevel);
	}
	void OpenOptions(){
		RotateCamera();
	}

	void Quit(){
		Application.Quit();
	}

	void RotateCamera(){
		turnCamera = true;
		//transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smooth);
	}

	//IF YOU HAVE MORE OPTIONS,
	//YOU'LL NEED MORE FUNCTIONS,
	//GO CRAZY
}