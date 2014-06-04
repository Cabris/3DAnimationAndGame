using UnityEngine;
using System.Collections;
using System;

public class MiniMap : MonoBehaviour
{
	
	bool opened;
	public UILabel guiText;
	public GameObject mapEle_base_prefab;
	public GameObject mapEle_wall_prefab;
	public GameObject mapEle_home_prefab;
	public GameObject mapEle_mc_prefab;
	public GameObject mapEle_711_prefab;
	public GameObject mapEle_post_prefab;
	public GameObject playerPos_prefab;
	Renderer[] mapRenderers;
	public float size;
	double  countTime = 0;
	public Transform player;
	GameObject playerPos;
	float w;
	float h;
	int mapW;
	int mapH;
	bool isInitialMap= false;
	PlayerPath path;
	
	// Use this for initialization
	void Start ()
	{
		isOpen = false;
		path=player.GetComponent<PlayerPath>();
		path.OnPathAdded+=onPathAdded;
		//isInitialMap = false;
		//	mapRenderers=GetComponentsInChildren<Renderer> ();
		//	InitializeMap (MapDatas.map2);
	}
	
	public void InitializeMap (int[,] mapData)
	{
		//size=new Vector2(mapW*eleSize,mapH*eleSize);
		mapW = mapData.GetLength (1);
		mapH = mapData.GetLength (0);
		//float eleSize = size;
		Vector3 _size = new Vector3 (size, size, size);
		w = size * mapW;
		h = size * mapH;
		for (int i=0; i<mapH; i++)
			for (int j=0; j<mapW; j++) {
				Vector3 elePos = new Vector3 ((-w / 2) + j * size * 1.07f, 0, (-h / 2) + i * size * 1.07f);
				createMapEle (mapEle_base_prefab, elePos, new Vector3 (size, size * 0.05f, size));
			
				int type = mapData [i, j];
				int _i = mapH - i;
				elePos = new Vector3 ((-w / 2) + j * size * 1.07f, size * 1.07f / 2f, (-h / 2) + _i * size * 1.07f);
				switch (type) {
				case 0://wall
					createMapEle (mapEle_wall_prefab, elePos, _size);
					break;
				case 1:
					break;
				case 2://home
					createMapEle (mapEle_home_prefab, elePos, _size);
					break;
				case 3://麥當勞
					createMapEle (mapEle_mc_prefab, elePos, _size);
					break;
				case 4://7-11
					createMapEle (mapEle_711_prefab, elePos, _size);
					break;
				case 5://郵局
					createMapEle (mapEle_post_prefab, elePos, _size);
					break;
				}
				//mapEle.transform.localScale=new Vector3(0.5f,0.5f,0.5f);
			}	
		playerPos = GameObject.Instantiate (playerPos_prefab) as GameObject;
		playerPos.transform.parent = this.transform;
		playerPos.transform.localScale = _size;
		mapRenderers = GetComponentsInChildren<Renderer> ();
		isInitialMap = true;
	}
	
	void createMapEle (GameObject prefab, Vector3 pos, Vector3 scale)
	{
		GameObject mapEle_base = GameObject.Instantiate (prefab) as GameObject;
		mapEle_base.transform.parent = this.transform;
		mapEle_base.transform.localPosition = pos;
		mapEle_base.transform.localScale = scale;
	}

	//int _i = 0, _j = 0;
	// Update is called once per frame
	void Update ()
	{
		if (isInitialMap) {
			foreach (Renderer r in mapRenderers)
				r.enabled = isOpen;
			//playerPos.renderer.enabled = isOpen;
			if (isOpen) {
				countTime += Time.deltaTime;
			}
			
			Vector3 p = posInMap(player.transform.position);
			playerPos.transform.localPosition = p;
			
		}
		if (isOpen) {
			showOpenTime ();
		} else {
			guiText.text = "Press 'M' to open map";
		}
	}
	
	Vector3 posInMap(Vector3 pos){
		float _i = (2f * pos.z / 15f);
		float	_j = (2f * pos.x / 15f);
		Vector3 p = new Vector3 ((-w / 2) + _j * size * 1.07f, 
			size * 1.07f / 2f, (h / 2) + _i * size * 1.07f);
	return p;
	}
	
	void showOpenTime ()
	{
		double t = Math.Round (countTime, 2);
		guiText.text = "Map has been open for :" + t.ToString () + "sec";
		//testGUI.guiText.text = Random.Range(0,100).ToString();
	}
	
	public bool isOpen {
		get{ return opened;}
		set {
			opened = value;
			if (opened) {
				float pr = player.rotation.eulerAngles.y;
				//transform.Rotate(new Vector3(0,pr,0));
				Quaternion q2 = Quaternion.Euler (new Vector3 (0, -pr, 0));
				Quaternion q1 = Quaternion.Euler (new Vector3 (300, 0, 0));
				q1 *= q2;
				TweenRotation t = TweenRotation.Begin (gameObject, 0.25f, q1);
				t.onFinished += onFinished;
			} else {
				Quaternion q = Quaternion.Euler (new Vector3 (0, 0, 0));
				transform.localRotation = q;
			}
		}
	}
	
	void onFinished (UITweener tween)
	{
		Destroy (tween);
	}
	
	void onPathAdded(Vector3 pos){
		Vector3 _size = new Vector3 (size*0.3f,size*0.3f, size*0.3f);
		GameObject playerPath = GameObject.Instantiate (playerPos_prefab) as GameObject;
		playerPath.transform.parent = this.transform;
		playerPath.transform.localScale = _size;
		Vector3 p=posInMap(pos);
		playerPath.transform.localPosition=p;
		playerPath.renderer.enabled=isOpen;
		mapRenderers = GetComponentsInChildren<Renderer> ();
	}

	
}
