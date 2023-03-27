using System;
using UnityEngine;

public class ProjectileData
{
    public float lifetime = 0f;
    public Vector2 origin = Vector2.zero;
    public Vector2 initialVelocity = Vector2.zero;
    public GameObject instance;
    public string enemyTag = "Enemy";

    public ProjectileData()
    {}

    public ProjectileData(GameObject g)
    {
        instance = g;
    }

    public ProjectileData(float lt, Vector2 o, Vector2 iv, GameObject g)
    {
        lifetime = lt;
        origin = o;
        initialVelocity = iv;
        instance = g;
    }

    public ProjectileData(float lt, Vector2 o, Vector2 iv, GameObject g, string t)
    {
        lifetime = lt;
        origin = o;
        initialVelocity = iv;
        instance = g;
        enemyTag = t;
    }

    public ProjectileData Clone()
    {
        return new ProjectileData(lifetime, origin, initialVelocity, instance, enemyTag);
    }
}