using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OptionCtrl : MonoBehaviour {

	[System.Serializable]
	public class Options{
		public string 		optionName;
		public int			value;
		public int			maxValue;
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
	private Vector3 optOffset = 		new Vector3(0f,-.5f,0f);
	private int	maxFont = 				35;

	private int curSlate = 				0;
	private List<GameObject> slates = new List<GameObject> ();
	private List<List<GameObject>> options = new List<List<GameObject>> ();
	// Use this for initialization
	void Start () {
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
				fontMod = (int)(name.Length)/2;

			int fontSize = maxFont - fontMod;

			tMesh.fontSize = fontSize;
			
			label.transform.parent = tag.transform;
			label.transform.position = tag.transform.position + labelOffset;
			float slateLeft = slate.collider.bounds.center.x - slate.collider.bounds.size.x/2;
			float slateTop = slate.collider.bounds.center.y + slate.collider.bounds.size.y/2;
			int j = 1;
			List<GameObject> optList = new List<GameObject>();
			foreach(Options opt in tab.optionList){
				GameObject optName = Instantiate(prefabText) as GameObject;
				TextMesh OPTtMesh = optName.GetComponent<TextMesh>();
				OPTtMesh.color = new Color(158, 210, 255);
				OPTtMesh.text = opt.optionName + "\t\t" + opt.value.ToString();
				OPTtMesh.alignment = TextAlignment.Left;
				OPTtMesh.anchor = TextAnchor.LowerLeft;
				OPTtMesh.tabSize = 300;
				optName.transform.parent = slate.transform;
				optName.transform.position = tag.transform.position + optOffset*j + new Vector3(.6f,-.55f,-1f);
				optList.Add(optName);
				j++;
			}
	
			slates.Add(slate);

			i++;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		int i = 0;
		foreach(GameObject slate in slates){
			if(i != curSlate)
				slate.SetActive(false);
		
		}
	}


}
	