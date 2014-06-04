using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

	public UIEventListener eventListener;
	// Use this for initialization
	void Start ()
	{
	eventListener.onClick+=ButtonClick;
	}
	
	void ButtonClick (GameObject button)
	{
		Debug.Log ("GameObject " + button.name);
		int i=Random.Range(1,2);
		switch(i){
		case 1:
			Application.LoadLevel("map1");
			break;
		case 2:
			Application.LoadLevel("map2");
			break;
		}
	}

}
