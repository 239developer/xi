using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject window;

    public void OpenWindow()
    {
        window.SetActive(true);
        InteractionHandler.interacting = true;
    }

    public void CloseWindow()
    {
        window.SetActive(false);
        InteractionHandler.interacting = false;
    }
}
