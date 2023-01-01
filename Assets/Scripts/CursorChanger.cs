using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    public Camera cam;
    public Material material;

    void Start()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }

    public float theta_scale = 0.1f;        //Set lower to add more points
    int size; //Total number of points in circle
    public float radius = 0.8f;
    public float lineWidth = 0.08f;
    LineRenderer lineRenderer;
 
    void Awake()
    {
        float sizeValue = (2.0f * Mathf.PI) / theta_scale;
        size = (int)sizeValue;
        size++;
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = material;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.positionCount = size;
    }
 
    void Update()
    {
        Vector3 delta = cam.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 3);
        Vector3 pos;
        float theta = 0f;
        for (int i = 0; i < size; i++)
        {
            theta += (2.0f * Mathf.PI * theta_scale);
            float x = radius * Mathf.Cos(theta);
            float y = radius * Mathf.Sin(theta);
            x += gameObject.transform.position.x;
            y += gameObject.transform.position.y;
            pos = new Vector3(x, y, 0) + delta;
            lineRenderer.SetPosition(i, pos);
        }

        if(radius > 1.0f) radius = 0.1f;
        radius += Time.deltaTime * 0.5f;
    }
}
