using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour
{
	
	public bool	seven_11;
	public bool	 postOffice;
	public bool	 mcdonald;
	
	public UICheckbox cb711;
	public UICheckbox cbMc;
	public UICheckbox cbPost;
	
	// Use this for initialization
	void Start ()
	{
		seven_11 = false;
		postOffice = false;
		mcdonald = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void	OnTriggerEnter (Collider collision)
	{
		if (collision.name == "7-11") {
			seven_11 = true;
			cb711.isChecked=true;
			Debug.Log ("7-11 true");
		} else if (collision.name == "postoffice") {
			postOffice = true;
			cbPost.isChecked=true;
			Debug.Log ("post true");
		} else if (collision.name == "mcdonald") {
			mcdonald = true;
			cbMc.isChecked=true;
			Debug.Log ("m true");
		}
	}
}
