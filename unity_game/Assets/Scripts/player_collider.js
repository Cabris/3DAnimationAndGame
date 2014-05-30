#pragma strict
var seven_11:boolean;
var postOffice:boolean;
var mcdonald: boolean;

function Start () 
{
	seven_11 = false;
	postOffice = false;
}

function Update () 
{

}

function OnTriggerEnter(collision : Collider)
{
	if(collision.name=="7-11")
	{
		seven_11 = true;
		Debug.Log("7-11 true");
	}
	else if(collision.name=="postoffice")
	{
		postOffice = true;
		Debug.Log("post true");
	}
	else if(collision.name=="mcdonald")
	{
		mcdonald = true;
		Debug.Log("m true");
	}
	
}

function OnGUI()
{
	if(seven_11==false)
	GUILayout.Label(" 7-11 not found");
	else if(seven_11==true)
	GUILayout.Label(" 7-11 is found");
	
	if(postOffice==false)
	GUILayout.Label(" post office not found");
	else if(postOffice==true)
	GUILayout.Label(" post Office is found");
	
	if(mcdonald==false)
	GUILayout.Label(" mcdonald not found");
	else if(mcdonald==true)
	GUILayout.Label(" mcdonald is found");
}