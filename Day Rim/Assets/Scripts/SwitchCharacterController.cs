using UnityEngine;
using System.Collections;

public class SwitchCharacterController : MonoBehaviour {

    public GameObject activeCharacter;
    public GameObject felixGameObject;
    public GameObject feliGameObject;

    private PlayerCharacterController felix;
    private PlayerCharacterController feli;

	// Use this for initialization
	void Start () 
    {
        felix = felixGameObject.GetComponent<PlayerCharacterController>();
        feli = feliGameObject.GetComponent<PlayerCharacterController>();

        setActiveCharacter();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyUp(KeyCode.S))
        {
            felix.activeCharacter = !felix.activeCharacter;
            feli.activeCharacter = !feli.activeCharacter;

            setActiveCharacter();

            Debug.Log(activeCharacter.gameObject.name);
        }	
    }

    void setActiveCharacter()
    {
        if (feli.activeCharacter)
        {
            felix.activeCharacter = false;
            activeCharacter = feliGameObject;
        }
        else if (felix.activeCharacter)
        {
            feli.activeCharacter = false;
            activeCharacter = felixGameObject;
        }
    }
}
