using UnityEngine;
using System.Collections;

public class CanvasNavigator : MonoBehaviour {

    public static bool inventar_isActive = false;
    private Animation inventar;
    public GameObject Inventar_Panel;

    // Use this for initialization
    void Start () {
        inventar = Inventar_Panel.GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OpenDialog()
    {
        if (!inventar_isActive)
        {
            inventar.Play("Inventar_IN");
            inventar_isActive = true;
            //hier in GameMode Inventar wechseln

        }
        else
        {
            inventar.Play("Inventar_OUT");
            inventar_isActive = false;
            //hier in GameMode INGame wechseln
        }
    }
}
