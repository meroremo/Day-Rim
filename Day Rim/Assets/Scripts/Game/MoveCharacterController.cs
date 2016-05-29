using UnityEngine;
using System.Collections;

public class MoveCharacterController : MonoBehaviour 
{
    public GameObject feli;
    public GameObject felix;

    public float movementSpeed = 4f;

    private GameObject inactiveCharacter;

	void Start () 
    {
        ActiveCharacter.activeCharacter = feli;
        inactiveCharacter = felix;

        if (ActiveCharacter.activeCharacter != null)
        {
            setFollowingCharacter();
        }
	}
	
	void Update () 
    {
        setFollowingCharacter();

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ActiveCharacter.activeCharacter.transform.position += Vector3.left * movementSpeed * Time.deltaTime;
            inactiveCharacter.transform.position += Vector3.left * movementSpeed * Time.deltaTime;

            if (ActiveCharacter.activeCharacter.transform.position.x > inactiveCharacter.transform.position.x)
                switchCharacterPosition();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            ActiveCharacter.activeCharacter.transform.position += Vector3.right * movementSpeed * Time.deltaTime;
            inactiveCharacter.transform.position += Vector3.right * movementSpeed * Time.deltaTime;

            if (ActiveCharacter.activeCharacter.transform.position.x < inactiveCharacter.transform.position.x)
                switchCharacterPosition();
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            ActiveCharacter.activeCharacter.transform.position += Vector3.up * movementSpeed * Time.deltaTime;
            inactiveCharacter.transform.position += Vector3.up * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            ActiveCharacter.activeCharacter.transform.position += Vector3.down * movementSpeed * Time.deltaTime;
            inactiveCharacter.transform.position += Vector3.down * movementSpeed * Time.deltaTime;
        }
	}

    private void setFollowingCharacter()
    {
        if (ActiveCharacter.activeCharacter.name == "Felix" && inactiveCharacter != feli)
        {
            inactiveCharacter = feli;
            switchCharacterPosition();
        }
        else if (ActiveCharacter.activeCharacter.name == "Feli" && inactiveCharacter != felix)
        {
            inactiveCharacter = felix;
            switchCharacterPosition();
        }
    }

    private void switchCharacterPosition()
    {
        float tmpActivePosition = ActiveCharacter.activeCharacter.transform.position.x;

        ActiveCharacter.activeCharacter.transform.position = new Vector3(inactiveCharacter.transform.position.x, ActiveCharacter.activeCharacter.transform.position.y, ActiveCharacter.activeCharacter.transform.position.y);
        inactiveCharacter.transform.position = new Vector3(tmpActivePosition, inactiveCharacter.transform.position.y, inactiveCharacter.transform.position.z);
    }
}
