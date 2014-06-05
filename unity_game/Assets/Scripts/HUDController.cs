using UnityEngine;
using System.Collections;

public class HUDController : MonoBehaviour
{
	public MiniMap map;
	public CharacterMotor cMotor;
	public MouseLook mLook;
	bool isOpenMap;
	// Use this for initialization
	void Start ()
	{
		map = GetComponentInChildren<MiniMap> ();
		isOpenMap=false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.M)) {
			isOpenMap=!isOpenMap;
		//	cMotor.canControl = !map.isOpen;
		//	mLook.canControl= !map.isOpen;
		}
		map.isOpen = isOpenMap;
		
	}
}
