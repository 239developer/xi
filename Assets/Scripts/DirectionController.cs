using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionController : MonoBehaviour
{
    public string sheetName;
    public bool isPlayer = false;
    public int direction = 0;
    private SpriteRenderer sr;
    private Sprite[] sprites;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>(sheetName);
    }

    void Update()
    {   
        if(!isPlayer) 
        {
            if(TryGetComponent(out NPCAI script))
                direction = script.facingDirection;
        }
        else
            if(TryGetComponent(out PlayerController script))
                direction = script.facingDirection;

        sr.sprite = sprites[direction];
    }
}
