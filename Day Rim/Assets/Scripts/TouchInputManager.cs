using UnityEngine;
using System.Collections;

public class TouchInputManager : MonoBehaviour 
{
    public GameObject CharacterController;
    public GameObject ItemInteraction;
    public GameObject NPCInteraction;
    public GameObject OtherInteraction;

    private SwitchCharacterController switchCharacterController;

    private GameObject selectedObject;
    private Ray ray;
    private RaycastHit rayHit;

	void Start () 
    {
        switchCharacterController = CharacterController.GetComponent<SwitchCharacterController>();

        SetInteraction(false);
	}
	
	void Update () 
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                if (Physics.Raycast(ray, out rayHit, Mathf.Infinity))
                {
                    GameObject hitObject = rayHit.transform.gameObject;
                    selectedObject = hitObject;
                    Debug.Log("HIT " + hitObject.name);


                    if (hitObject.tag == "ActiveCharacter" || hitObject.tag == "NPC")
                    {
                        SetInteraction(false);
                        NPCInteraction.SetActive(true);
                    }
                    else if (hitObject.tag == "PickableItem")
                    {
                        SetInteraction(false);
                        ItemInteraction.SetActive(true);
                    }
                    else if (hitObject.tag == "UnpickableItem")
                    {
                        SetInteraction(false);
                        OtherInteraction.SetActive(true);
                    }

                    // FUNKTIONIERT NOCH  NICHT
                    /* Vector3 position = hitObject.transform.position;
                     //Vector3 position = Camera.main.ScreenToWorldPoint(tmpPosition);

                     ItemInteraction.transform.position = position;

                     Debug.Log(hitObject.transform.position);
                     Debug.Log(ItemInteraction.transform.position);*/
                }
                else
                {
                    //SetInteraction(false);
                }
            }
        }
	}

    private void SetInteraction(bool state)
    {
        ItemInteraction.SetActive(state);
        NPCInteraction.SetActive(state);
        OtherInteraction.SetActive(state);
    }

    public void switchCharacterOnButton()
    {
        switchCharacterController.switchActiveCharacter();
    }

    public void LookAt() // Steuerung über das Element
    {
        SetInteraction(false);
        Debug.Log("Looking at " + selectedObject.name);
        // Look At Object/NPC Dialog aufrufen
    }

    public void LookAt2() // Steuerung über den Charakter
    {
        SetInteraction(false);
        Debug.Log("Looking at " + selectedObject.name);
        // Look At Object/NPC Dialog aufrufen
    }

    public void TalkTo() // Steuerung über das Element
    {
        SetInteraction(false);

        if (selectedObject.name == ActiveCharacter.activeCharacter.name)
        {
            Debug.Log("ICH SELBST");
            // Anschauen Dialog öffnen, da Spieler sonst mit sich selbst redet
        }
        else
        {
            // Dialogszene öffnen, wenn es nicht Felix oder Feli ist
        }

        Debug.Log("Talking to " + selectedObject.name);
    }

    public void TalkTo2() // Steuerung über den Charakter
    {
        SetInteraction(false);

        if (selectedObject.name == ActiveCharacter.activeCharacter.name)
        {
            Debug.Log("ICH SELBST");
            // Anschauen Dialog öffnen, da Spieler sonst mit sich selbst redet
        }
        else
        {
            // Dialogszene öffnen, wenn es nicht Felix oder Feli ist
        }

        Debug.Log("Talking to " + selectedObject.name);
    }

    public void PickUp() // Steuerung über das Element
    {
        SetInteraction(false);

        Debug.Log("Picked Up " + selectedObject.name);
        // Aufheben-Funktion der Itemverwaltung aufrufen
    }

    public void PickUp2() // Steuerung über den Charakter
    {
        SetInteraction(false);

        Debug.Log("Picked Up " + selectedObject.name);
        // Aufheben-Funktion der Itemverwaltung aufrufen
    }
}
