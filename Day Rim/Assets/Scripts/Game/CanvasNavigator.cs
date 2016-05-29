using UnityEngine;
using System.Collections;

public class CanvasNavigator : MonoBehaviour {

    public static bool inventar_isActive = false;
    private Animation inventar;
    public GameObject Inventar_Panel;

    void Start () 
    {
        inventar = Inventar_Panel.GetComponent<Animation>();
    }

    public void OpenDialog()
    {
        if (!inventar_isActive)
        {
            inventar.Play("Inventar_IN");
            inventar_isActive = true;
            ActiveGameMode.GAMEMODE = ActiveGameMode.GameModes.INVENTORY;
        }
        else
        {
            inventar.Play("Inventar_OUT");
            inventar_isActive = false;
            ActiveGameMode.GAMEMODE = ActiveGameMode.GameModes.INGAME;
        }
    }
}
