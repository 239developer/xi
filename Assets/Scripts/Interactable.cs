using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Material defaultMaterial;
    public Material selectedMaterial;
    private int cycle = -1;
    private bool selected = false;

    public void StartInteraction()
    {
        cycle = InteractionHandler.cycle;
        GetComponent<SpriteRenderer>().material = selectedMaterial;
        selected = true;
    }

    public void EndInteraction()
    {
        GetComponent<SpriteRenderer>().material = defaultMaterial;
        selected = false;
    }

    void Update()
    {
        if(selected && cycle != InteractionHandler.cycle)
            EndInteraction();
    }
}
