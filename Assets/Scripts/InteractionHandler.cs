using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    public static bool interacting = false;
    public RectTransform message;
    private int currentType = InteractionType.nill;
    private Camera cam;
    private Interactable currentObject;

    void Start()
    {
        interacting = false;
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.up, 0.001f);

        if(!interacting)
        {
            try
            {
                switch(hit.collider.tag)
                {
                    case "NPC":
                        currentType = InteractionType.NPC;
                        break;
                    default:
                        currentType = InteractionType.none;
                        break;
                }
                currentObject = hit.collider.GetComponent<Interactable>();
            }
            catch
            {
                currentType = InteractionType.nill;
            }
        }

        if(!interacting && currentType > InteractionType.none)
        {
            message.gameObject.SetActive(true);
            message.anchoredPosition = Input.mousePosition;
            if(Input.GetKeyDown(KeyCode.E))
            {
                currentObject.OpenWindow();
            }
        }
        else
        {
            message.gameObject.SetActive(false);
        }
    }
}
