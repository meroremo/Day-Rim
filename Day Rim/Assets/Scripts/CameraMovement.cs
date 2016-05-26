using UnityEngine;
using System.Collections;

public class CameraMovement1 : MonoBehaviour {

	public bool orientation = false;
	//private DeviceOrientation lastOrientation;
	private DeviceOrientation currentOrientation;
	public Camera cam;
	public GameObject back;


	// Use this for initialization
	void Start () {

		//lastOrientation = Input.deviceOrientation;
		currentOrientation = Input.deviceOrientation;

	}


	// Update is called once per frame
	void Update () {

		DeviceOrientation devOr = Input.deviceOrientation;


		//Wenn das erfüllt ist darf gedreht werden
		if (devOr != DeviceOrientation.Unknown && orientation == true && devOr != currentOrientation)
		{


			if (devOr == DeviceOrientation.Portrait)
			{				
				if(currentOrientation == DeviceOrientation.LandscapeRight)
				{
					cam.transform.Rotate(new Vector3(0,0,90));
					cam.transform.position = (new Vector3(0,0,-10));
				}

				currentOrientation = DeviceOrientation.Portrait;
				
				orientation = false;
				
			}
			else if (devOr == DeviceOrientation.LandscapeRight ) 
			{
				if(currentOrientation == DeviceOrientation.Portrait)
				{
					cam.transform.Rotate(new Vector3(0,0,-90));
					cam.transform.position = (new Vector3(0,-6,-10));
				}

				currentOrientation = DeviceOrientation.LandscapeRight;
				
				orientation = false;
				
			}



		} // endif
		else if( devOr != DeviceOrientation.Unknown && devOr != currentOrientation && devOr != DeviceOrientation.PortraitUpsideDown && devOr != DeviceOrientation.LandscapeLeft)
		{
			orientation = true;
		}







		//Screen.orientation = ScreenOrientation.Landscape;
		//		Debug.Log (DeviceOrientation);

		/*DeviceOrientation orientation = Input.deviceOrientation;
		if (orientation == DeviceOrientation.LandscapeLeft)
		{
			Screen.orientation = ScreenOrientation.LandscapeLeft;
		}
		else if (orientation == DeviceOrientation.LandscapeRight)
		{
			Screen.orientation = ScreenOrientation.LandscapeRight;
		}
*/

		//!!!! Gibt die aktuelle Orientierung des Screens zurück
		//Debug.Log (Input.deviceOrientation);

		// AUsrichtung des Tablets
		//Debug.Log ("X:" + Input.acceleration.x + " " + "Y:" + Input.acceleration.y + " " + "Z:" + Input.acceleration.z);

		//TOUCHPOSITION 
		//if(Input.touchCount > 0)
		//	Debug.Log (Input.GetTouch(0).position.x + "   " +  Input.GetTouch(0).position.y);
	}



}
