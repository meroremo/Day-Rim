using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TouchInputManager : MonoBehaviour
{
    public GameObject CharacterController;

    public GameObject LookAtButton;
    public GameObject PickUpButton;
    public GameObject TalkToButton;

    public Text infoText;

    private SwitchCharacterController switchCharacterController;
    private DialogSceneManager dialogSceneManager;
    private LookAtDialogManager lookAtDialogManager;
    private ItemSingleInteraction itemSingleInteraction;

    private GameObject selectedObject;
    private Ray ray;
    private RaycastHit rayHit;

    private Vector3 touchPosition;
    private Vector3 lookPosition;
    private Vector3 talkPosition;
    private Vector3 pickPosition; 

	void Start () 
    {
        SceneNameManager.lastIngameScene = SceneManager.GetActiveScene().name;
        ActiveGameMode.GAMEMODE = ActiveGameMode.GameModes.INGAME;

        switchCharacterController = CharacterController.GetComponent<SwitchCharacterController>();
        dialogSceneManager = this.GetComponent<DialogSceneManager>();
        infoText.text = "ICH BIN DA";

        SetInteraction(false, false, false);
	}
	
	void Update () 
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                Touch touch = Input.touches[0];
                touchPosition = Input.GetTouch(0).position;

                SetPositionsToTouchPosition();

                switch (ActiveGameMode.GAMEMODE) // NOCH ZU ERWEITERN
                {
                    case ActiveGameMode.GameModes.INGAME:
                        HandleTouchIngameScene(touch);
                        break;
                    default:
                        Debug.Log("NOT INGAME GAMEMODE");
                        break;
                }
            }
        }
	}

    private void HandleTouchIngameScene(Touch touch)
    {
        if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            Debug.Log("NUMMER 1");
            if (Physics.Raycast(ray, out rayHit, Mathf.Infinity))
            {
                GameObject hitObject = rayHit.transform.gameObject;
                selectedObject = hitObject;

                Debug.Log(hitObject.tag);
                Debug.Log(hitObject.name);
                
                if(hitObject.name == "Felix")
                {
                    if (hitObject.tag != "NPC" && hitObject.tag != "ActiveCharacter")
                    {
                        if (ActiveCharacter.activeCharacter.name == "Feli")
                            hitObject.tag = "NPC";
                    }
                }

                if (hitObject.tag == "ActiveCharacter" || hitObject.tag == "NPC")
                {
                    Debug.Log("FELIX ODER FELI");
                    lookPosition.x -= 30;
                    lookPosition.y += 30;

                    talkPosition.x += 30;
                    talkPosition.y += 30;

                    SetButtonPositions();

                    SetInteraction(true, true, false);
                }
                else if (hitObject.tag == "PickableItem")
                {
                    itemSingleInteraction = hitObject.GetComponent<ItemSingleInteraction>();
                    if (itemSingleInteraction.singleInteraction)
                        infoText.text = "Ich interagiere mit diesem Objekt";
                    else
                        infoText.text = "Mit diesem Objekt ist keine Interaktion möglich";

                    lookPosition.x -= 30;
                    lookPosition.y += 30;

                    pickPosition.x += 30;
                    pickPosition.y += 30;

                    SetButtonPositions();

                    SetInteraction(true, false, true);
                }
                else if (hitObject.tag == "UnpickableItem")
                {
                    itemSingleInteraction = hitObject.GetComponent<ItemSingleInteraction>();
                    if (itemSingleInteraction.singleInteraction)
                        infoText.text = "Ich interagiere mit diesem Objekt"; // ENTSPRECHEND ETWAS TUN, BETRETEN ODER SO, KA
                    else
                        infoText.text = "Mit diesem Objekt ist keine Interaktion möglich";

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
        lookAtDialogManager = selectedObject.GetComponent<LookAtDialogManager>();

        SetInteraction(false, false, false);
        infoText.text = lookAtDialogManager.getLookAtDialog();
    }

    public void TalkTo() // Steuerung über das Element
    {
        SetInteraction(false, false, false);
        lookAtDialogManager = selectedObject.GetComponent<LookAtDialogManager>();

        if (selectedObject.name == ActiveCharacter.activeCharacter.name)
        {
            infoText.text = lookAtDialogManager.getLookAtDialog();
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
        lookAtDialogManager = selectedObject.GetComponent<LookAtDialogManager>();

        lookAtDialogManager.getLookAtDialog();

        selectedObject.SetActive(false);
        // Aufheben-Funktion der Itemverwaltung aufrufen
    }

    public void ClearInfoText()
    {
        infoText.text = "";
    }

  /*  public void OpenInventory()
    {
        ActiveGameMode.GAMEMODE = ActiveGameMode.GameModes.INVENTORY;
        Debug.Log(ActiveGameMode.GAMEMODE);

        // Inventar einblenden (Mit Vanessa zusammen erarbeiten)
            // INVENTAR SCHLIEßEN, UM DANN DEN GAMEMODE WIEDER ZU ÄNDERN
    }

    public void OpenMenu()
    {
        ActiveGameMode.GAMEMODE = ActiveGameMode.GameModes.MENU;
        Debug.Log(ActiveGameMode.GAMEMODE);

        // Menu öffnen
            // Beim Schließen des Menüs den GameMode wieder ändern!
    }*/

    public void OpenDrawScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
