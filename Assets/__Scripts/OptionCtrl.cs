using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OptionCtrl : MonoBehaviour {

	[System.Serializable]
	public class Options{
		public string 		name;
		public GameObject 	type;
	}

	[System.Serializable]
	public class Tab{
		public string 		name;
		public Options[] 	optionList;
	}
	

	public Tab[] tabs;

	public Material tagMaterial;
	public Material buttonMaterial;
	public Material slateMaterial;

	public Font font;

	public GameObject guiText;

	private Vector3 cubeDimensions = 	new Vector3(10, 9, 1);
	private Vector3 tagLoc =			new Vector3(-4.3f,4.5f, -.6f); 
	// Use this for initialization
	void Start () {
		List<GameObject> slates = new List<GameObject> ();
		int i = 0;
		foreach(Tab tab in tabs){
			GameObject slate = GameObject.CreatePrimitive(PrimitiveType.Cube);
			slate.transform.localScale = cubeDimensions;
			Vector3 newPos = this.transform.position;
			newPos.y -= .5f;
			newPos.z -= .1f;
			slate.transform.position = newPos;
			slate.renderer.material = slateMaterial;

			GameObject tag = GameObject.CreatePrimitive(PrimitiveType.Quad);
			tag.transform.localScale = new Vector3(1,.5f,.5f);
			tag.transform.parent = slate.transform;
			tagLoc.x += i+.05f;
			tag.transform.position = slate.transform.position + tagLoc;
			tag.renderer.material = tagMaterial;

			//GameObject label = Instantiate(guiText, tag.transform.position, tag.transform.rotation);

			GUI.Label(, "Label text");

			slates.Add(slate);

			i++;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
