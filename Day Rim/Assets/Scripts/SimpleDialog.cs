using UnityEngine;
using System.Collections;

public class SimpleDialog : MonoBehaviour {

	public string[] questions;
	public string[] answers;

	bool DisplayDialog = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUILayout.BeginArea (new Rect (700, 600, 400, 400));

	}


	void onTriggerEnter ()
	{
		DisplayDialog = true;
	}

	void onTriggerExit ()
	{
		DisplayDialog = false;
	}
}
