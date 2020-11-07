using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform targetTransform;

    public float MaxHP = 255f;
    public float CurrentHP;
    public float Damage = 10f;

    private MeshRenderer mesh;
    private Color color;

    void Start()
    {
        CurrentHP = MaxHP;
        color = gameObject.GetComponent<Renderer>().material.color;
        mesh = GetComponent<MeshRenderer>();

    }

    public void SetDamage(float damage)
    {
        if (CurrentHP < 0)
        {
            Debug.Log("Eneme dead");
        }
        Color redPower = new Color((MaxHP / CurrentHP * (color.r / Color.red.r)), color.g, color.b);
        mesh.material.color = Color.Lerp(color, redPower, 1f);
    }
}