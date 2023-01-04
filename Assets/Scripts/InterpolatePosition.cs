using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolatePosition : MonoBehaviour
{
    public Transform parent;
    public float k1 = 3f;
    public float k2 = 4f;
    
    private Vector2 velocity = Vector2.zero;

    void Update()
    {
        transform.position += (Vector3)(Time.deltaTime * velocity);
        Vector2 dr = parent.position - transform.position;
        velocity = k1 * dr + k2 * dr * dr.magnitude;
    }
}
