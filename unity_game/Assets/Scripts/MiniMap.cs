using UnityEngine;
using System.Collections;
using System;

public class MiniMap : MonoBehaviour
{
	
	bool opened;
	public GUIText guiText;
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
	float w ;
		float h;
	int mapW ;
		int mapH;
	// Use this for initialization
	void Start ()
	{
		isOpen = false;
		InitializeMap (MapDatas.map2);
		mapRenderers = GetComponentsInChildren<Renderer> ();
		playerPos=GameObject.Instantiate(playerPos_prefab) as GameObject;
		playerPos.transform.parent=this.transform;
	}
	
	void InitializeMap (int[,] mapData)
	{
		//size=new Vector2(mapW*eleSize,mapH*eleSize);
		mapW = mapData.GetLength (1);
		 mapH = mapData.GetLength (0);
		float eleSize = size;
		 w = size * mapW;
		 h = size * mapH;
		for (int i=0; i<mapH; i++)
			for (int j=0; j<mapW; j++) {
				Vector3 elePos = new Vector3 ((-w / 2) + j * eleSize * 1.07f, 0, (-h / 2) + i * eleSize * 1.07f);
				createMapEle (mapEle_base_prefab, elePos, new Vector3 (eleSize, eleSize * 0.05f, eleSize));
			
				int type = mapData [i, j];
			int _i=mapH-i;
				elePos = new Vector3 ((-w / 2) + j * eleSize * 1.07f, eleSize * 1.07f / 2f, (-h / 2) + _i * eleSize * 1.07f);
				Vector3 _size = new Vector3 (eleSize, eleSize, eleSize);
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
	}
	
	void createMapEle (GameObject prefab, Vector3 pos, Vector3 scale)
	{
		GameObject mapEle_base = GameObject.Instantiate (prefab) as GameObject;
		mapEle_base.transform.parent = this.transform;
		mapEle_base.transform.localPosition = pos;
		mapEle_base.transform.localScale = scale;
	}
	public int _i=0,_j=0;
	// Update is called once per frame
	void Update ()
	{
		foreach (Renderer r in mapRenderers)
			r.enabled = isOpen;
		playerPos.renderer.enabled=isOpen;
		if (isOpen) {
			countTime += Time.deltaTime;
		}
		
		//int i=0,j=0;
		
		_i=(int)(2*player.transform.position.z/15);
		_j=(int)(2*player.transform.position.x/15);
		Vector3 p = new Vector3 ((-w / 2) + _j * size * 1.07f, 
			size * 1.07f / 2f, (h / 2) + _i * size * 1.07f);
		playerPos.transform.localPosition=p;
		Vector3 _size = new Vector3 (size, size, size);
		playerPos.transform.localScale=_size;
	}
	
	void OnGUI ()
	{
		if (isOpen) {
			showOpenTime ();
		} else {
			guiText.text = "M : 開啟地圖";
		}
	}
	
	void showOpenTime ()
	{
		double t = Math.Round (countTime, 3);
		guiText.text = "已開啟地圖:" + t.ToString () + "秒";
		//testGUI.guiText.text = Random.Range(0,100).ToString();
	}
	
	public bool isOpen {
		get{ return opened;}
		set {
			opened = value;
			if (opened) {
				float pr=player.rotation.eulerAngles.y;
				//transform.Rotate(new Vector3(0,pr,0));
				Quaternion q2=Quaternion.Euler(new Vector3(0,-pr,0));
				Quaternion q1=Quaternion.Euler(new Vector3(300,0,0));
				q1*=q2;
				TweenRotation t= TweenRotation.Begin(gameObject,0.25f,q1);
				t.onFinished+=onFinished;
			} else {
				Quaternion q=Quaternion.Euler(new Vector3(0,0,0));
				transform.localRotation=q;
			}
		}
	}
	
	void onFinished (UITweener tween){
		Destroy(tween);
	}
	
	int[,] _mapData = new int[,] {
		{0,0,0,0,0,0,0,0,0},
		{0,9,1,1,1,1,1,1,0},
		{0,0,0,0,0,0,0,1,0},
		{0,1,1,1,0,1,1,1,0},
		{0,1,0,0,0,1,0,0,0},
		{0,1,1,1,1,1,0,1,0},
		{0,1,0,0,0,0,0,1,0},
		{0,1,1,1,1,1,1,1,0},
		{0,0,0,0,0,0,0,0,0}
	};
	
	
}
