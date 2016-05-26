using UnityEngine;
using System.Collections;

public class DialogSceneManager : MonoBehaviour 
{
    public void enterDialogScene()
    {
        ActiveGameMode.GAMEMODE = ActiveGameMode.GameModes.DIALOG;
        Debug.Log(ActiveGameMode.GAMEMODE);
        Application.LoadLevel("YasminDummyDialogScene");
    }

    public void leaveDialogScene()
    {
        ActiveGameMode.GAMEMODE = ActiveGameMode.GameModes.INGAME;
        Debug.Log(ActiveGameMode.GAMEMODE);
        Application.LoadLevel("YasminDummyInteraction");
    }
}
