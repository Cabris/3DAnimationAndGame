using UnityEngine;
using System.Collections;
using System;

public class Menu : MonoBehaviour
{
	System.Random rnd = new System.Random ();
	public UIEventListener eventListener;
	// Use this for initialization
	void Start ()
	{
		eventListener.onClick += ButtonClick;
	}
	
	void ButtonClick (GameObject button)
	{
		Debug.Log ("GameObject " + button.name);
		int i = rnd.Next(1,3);
		
		switch (i) {
		case 1:
			Application.LoadLevel ("map1");
			break;
		case 2:
			Application.LoadLevel ("map2");
			break;
		}
		Debug.Log(i);
	}

}
