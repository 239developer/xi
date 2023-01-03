using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour //must be on the player
{ 
    public static bool interacting = false;
    public static int currentType = InteractionType.nill;
    public float maxDist = 3f;
    public RectTransform message;
    private Camera cam;
    private Interactable currentObject;

    void Start()
    {
        interacting = false;
        currentType = InteractionType.nill;
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        

        if(!interacting)
        {
            Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 playerPosition = transform.position; 
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.up, 0.001f);
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
            message.GetComponent<MessageThing>().SetText();
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
