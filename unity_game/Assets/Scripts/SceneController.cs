using UnityEngine;
using System.Collections;
using System;
public class SceneController : MonoBehaviour {
	
	//public GameObject environment;
	public GameObject player;
	public int mapId;
	public UILabel playTimeLabel;
	MiniMap map;
	float playTime=0;
	// Use this for initialization
	void Start () {
	map=player.GetComponentInChildren<MiniMap>();
		switch(mapId){
		case 1:
			map.InitializeMap(MapDatas.map1);
			break;
		case 2:
			map.InitializeMap(MapDatas.map2);
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	playTime+=Time.deltaTime;
		double t = Math.Round (playTime, 2);
		playTimeLabel.text="Play time: "+t+" sec";
	}
}
