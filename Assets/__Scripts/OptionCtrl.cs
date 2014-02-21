using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OptionCtrl : MonoBehaviour {

	[System.Serializable]
	public class Options{
		public string 		optionName;
		public string		value;
	}

	[System.Serializable]
	public class Tab{
		public string 		tabName;
		public Options[] 	optionList;
	}
	

	public Tab[] tabs;

	public Material tagMaterial;
	public Material buttonMaterial;
	public Material slateMaterial;

	public Font font;

	public GameObject prefabText;

	private Vector3 cubeDimensions = 	new Vector3(10, 9, 1);
	private Vector3 tagLoc =			new Vector3(-4.3f,4.5f, -.6f); 
	private Vector3 labelOffset = 		new Vector3(0.07379949f,-0.1475982f,-0.4176922f);
	private int	maxFont = 				35;
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

			GameObject label = Instantiate(prefabText) as GameObject;

			TextMesh tMesh = label.GetComponent<TextMesh>();
			tMesh.color = new Color(158, 210, 255);
			tMesh.text = tab.tabName;
			int fontMod = 0;

			if(name.Length >= 2)
				fontMod = (name.Length - 2)*2;

			int fontSize = maxFont - fontMod;

			tMesh.fontSize = fontSize;
			
			label.transform.parent = tag.transform;
			label.transform.position = tag.transform.position + labelOffset;
			//label.transform.localScale = Vector3.one * Random.Range(0.01f,0.1f);
			float slateLeft = slate.collider.bounds.center.x - slate.collider.bounds.size.x/2;
			float slateTop = slate.collider.bounds.center.y + slate.collider.bounds.size.y/2;
			int j = 1;
			foreach(Options opt in tab.optionList){
				GameObject optName = Instantiate(prefabText) as GameObject;
				TextMesh OPTtMesh = optName.GetComponent<TextMesh>();
				OPTtMesh.color = new Color(158, 210, 255);
				OPTtMesh.text = opt.optionName;
				optName.transform.parent = slate.transform;
				optName.transform.position = optName.transform.po + optOffset;


				j++;
			}
	
			slates.Add(slate);

			i++;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*void OnGui(){
		foreach(Tab tab in tabs){
			foreach(Options opt in tab.optionList){
				Rect optionSize =  new Rect(slateLeft + 2, slateTop + 5*j, 5, 10);
				GUI.TextField(optionSize, opt.value);
				j++;
			}
		}
	}*/
}
	