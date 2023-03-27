using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject thing;

    void Spawn(ProjectileData data)
    {
        var wow = GameObject.Instantiate(data.instance, (Vector3)data.origin, Quaternion.identity);
        wow.GetComponent<Projectile>().data = data;
    }

    void SpawnCircle(int n, ProjectileData data)
    {
        float alpha = Vector2.SignedAngle(Vector2.right, data.initialVelocity) * Mathf.Deg2Rad;
        float phi = 2f * Mathf.PI / n;
        float speed = data.initialVelocity.magnitude;

        for(int i = 0; i < n; i++)
        {
            Vector2 newVelocity = new Vector2(Mathf.Cos(alpha + i * phi) * speed, Mathf.Sin(alpha + i * phi) * speed);
            data.initialVelocity = newVelocity;
            Spawn(data.Clone());
        }
    }

    void SpawnCone(int n, float delta, ProjectileData data)
    {
        float alpha = Vector2.SignedAngle(Vector2.right, data.initialVelocity) * Mathf.Deg2Rad;
        float phi = delta * Mathf.Deg2Rad;
        float speed = data.initialVelocity.magnitude;

        for(int i = -n; i <= n; i++)
        {
            Vector2 newVelocity = new Vector2(Mathf.Cos(alpha + i * phi) * speed, Mathf.Sin(alpha + i * phi) * speed);
            data.initialVelocity = newVelocity;
            Spawn(data.Clone());
        }
    }

    void SpawnLines(int n, float spacing, ProjectileData data)
    {
        Vector2 delta = -Vector2.Perpendicular(data.initialVelocity).normalized * spacing;

        for(int i = 0; i < n; i++)
        {
            Spawn(data.Clone());
            data.origin += delta;
        }
    }

    void Start()
    {
        ProjectileData someData = new ProjectileData(10f, (Vector2)transform.position, Vector2.right * 3f, thing);

        SpawnLines(3, 1f, someData);
    }
}
