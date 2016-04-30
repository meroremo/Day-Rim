using UnityEngine;
using System.Collections;

public class TouchInputManager : MonoBehaviour 
{
    public GameObject CharacterController;
    private SwitchCharacterController switchCharacterController;

	// Use this for initialization
	void Start () 
    {
        switchCharacterController = CharacterController.GetComponent<SwitchCharacterController>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void switchCharacterOnButton()
    {
        switchCharacterController.switchActiveCharacter();
    }
}
