using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchInputManager : MonoBehaviour
{
    public GameObject CharacterController;
   /* public GameObject ItemInteraction;
    public GameObject NPCInteraction;
    public GameObject OtherInteraction;*/

    public GameObject LookAtButton;
    public GameObject PickUpButton;
    public GameObject TalkToButton;
    public Text infoText;

    private SwitchCharacterController switchCharacterController;
    private DialogSceneManager dialogSceneManager;

    private GameObject selectedObject;
    private Ray ray;
    private RaycastHit rayHit;

    private Vector3 touchPosition;
    private Vector3 lookPosition;
    private Vector3 talkPosition;
    private Vector3 pickPosition;

	void Start () 
    {
        switchCharacterController = CharacterController.GetComponent<SwitchCharacterController>();
        dialogSceneManager = this.GetComponent<DialogSceneManager>();
        infoText.text = "";

        SetInteraction(false, false, false);
	}
	
	void Update () 
    {
      /*  if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("true");
        }
        else
            Debug.Log("false");*/

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                Touch touch = Input.touches[0];
                touchPosition = Input.GetTouch(0).position;

                SetPositionsToTouchPosition();
                /*Debug.Log(EventSystem.current.IsPointerOverGameObject(touch.fingerId));*/

                if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    if (Physics.Raycast(ray, out rayHit, Mathf.Infinity))
                    {
                        GameObject hitObject = rayHit.transform.gameObject;
                        selectedObject = hitObject;
                        Debug.Log("HIT " + hitObject.name);

                        if (hitObject.tag == "ActiveCharacter" || hitObject.tag == "NPC")
                        {
                            lookPosition.x -= 30;
                            lookPosition.y += 30;

                            talkPosition.x += 30;
                            talkPosition.y += 30;

                            SetButtonPositions();

                            SetInteraction(true, true, false);
                        }
                        else if (hitObject.tag == "PickableItem")
                        {
                            lookPosition.x -= 30;
                            lookPosition.y += 30;

                            pickPosition.x += 30;
                            pickPosition.y += 30;

                            SetButtonPositions();

                            SetInteraction(true, false, true);
                        }
                        else if (hitObject.tag == "UnpickableItem")
                        {
                            lookPosition.y += 30;

                            SetButtonPositions();

                            SetInteraction(true, false, false);
                        }
                    }
                    else
                    {
                        SetInteraction(false, false, false);
                    }
                }
            }
        }
	}

    private void SetInteraction(bool stateA, bool stateB, bool stateC)
    {
        LookAtButton.SetActive(stateA);
        TalkToButton.SetActive(stateB);
        PickUpButton.SetActive(stateC);
    }

    private void SetPositionsToTouchPosition()
    {
        lookPosition = touchPosition;
        pickPosition = touchPosition;
        talkPosition = touchPosition;
    }

    private void SetButtonPositions()
    {
        LookAtButton.transform.position = lookPosition;
        PickUpButton.transform.position = pickPosition;
        TalkToButton.transform.position = talkPosition;
    }

    public void switchCharacterOnButton()
    {
        switchCharacterController.switchActiveCharacter();
    }

    public void LookAt() // Steuerung über das Element
    {
        SetInteraction(false, false, false);
        infoText.text = "Looking at " + selectedObject.name;
            // Look At Object/NPC Dialog aufrufen
    }

    public void TalkTo() // Steuerung über das Element
    {
        SetInteraction(false, false, false);

        if (selectedObject.name == ActiveCharacter.activeCharacter.name)
        {
            infoText.text = "Selbstgespräch.";
                // Anschauen Dialog öffnen, da Spieler sonst mit sich selbst redet
        }
        else
        {
            dialogSceneManager.enterDialogScene();
        }
    }

    public void PickUp() // Steuerung über das Element
    {
        SetInteraction(false, false, false);

        infoText.text = "Picked up " + selectedObject.name;

        selectedObject.SetActive(false);
        // Aufheben-Funktion der Itemverwaltung aufrufen
    }

    public void ClearInfoText()
    {
        infoText.text = "";
    }
}
