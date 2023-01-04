using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPCAI : MonoBehaviour
{
    public int facingDirection = 0;
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
