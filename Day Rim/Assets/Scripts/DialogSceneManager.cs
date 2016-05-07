using UnityEngine;
using System.Collections;

public class DialogSceneManager : MonoBehaviour 
{
    public void enterDialogScene()
    {
        Application.LoadLevel("YasminDummyDialogScene");
    }

    public void leaveDialogScene()
    {
        Application.LoadLevel("YasminDummyInteraction");
    }
}
