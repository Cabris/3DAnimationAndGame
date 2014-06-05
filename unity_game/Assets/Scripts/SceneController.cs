using UnityEngine;
using System.Collections;
using System;

public class SceneController : MonoBehaviour
{
	
	//public GameObject environment;
	public GameObject player;
	public int mapId;
	public UILabel playTimeLabel;
	MiniMap map;
	float playTime = 0;
	// Use this for initialization
	PlayerCollider pc;

	void Start ()
	{
		map = player.GetComponentInChildren<MiniMap> ();
		pc = player.GetComponent<PlayerCollider> ();
		switch (mapId) {
		case 1:
			map.InitializeMap (MapDatas.map1);
			break;
		case 2:
			map.InitializeMap (MapDatas.map2);
			break;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		bool f = pc.seven_11 && pc.mcdonald && pc.postOffice;
		
		playTime += Time.deltaTime;
		
		if (f) {
			map.isOpen=true;
			map.isFinished=true;
			
		} else {
			double t = Math.Round (playTime, 2);
			playTimeLabel.text = "Play time: " + t + " sec";
		}
		
		
		
		
	}
}
