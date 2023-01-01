using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public int facingDirection = 0;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float dx = Input.GetAxis("Horizontal");
        float dy = Input.GetAxis("Vertical");

        Vector2 direction = new Vector2(dx, dy).normalized;
        
        if(direction != Vector2.zero)
        {
            float angle = (dx < 0 ? 1 : 0) * 180f + Vector2.Angle((dx < 0 ? -1 : 1) * Vector2.up, direction);
            facingDirection = (int)Mathf.Round(angle / 45f) % 8;
        }

        rb.velocity = direction * speed;
    }
}
