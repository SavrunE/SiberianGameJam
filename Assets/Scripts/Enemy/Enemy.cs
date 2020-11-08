using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float MaxHP = 255f;
    public float CurrentHP;
    public float Damage = 10f;
    public float RestoreEnergyOnDead = 10f;
    public delegate void ChangeText();
    public static event ChangeText OnEnemyDie;

    MeshRenderer mesh;
    Color color;
    Transform targetTransform;
    void Start()
    {
        CurrentHP = MaxHP;
        color = gameObject.GetComponent<Renderer>().material.color;
        mesh = GetComponent<MeshRenderer>();
    }
    public void SetDamage(float damage)
    {
        CurrentHP -= damage;
        if (CurrentHP <= 0)
        {
            OnEnemyDie?.Invoke();
            Player.Instance.RestoreDamage(RestoreEnergyOnDead);
            Destroy(gameObject);
        }
        else
        {
            Color redPower = new Color((MaxHP / CurrentHP * (color.r / Color.red.r)), color.g, color.b);
            mesh.material.color = Color.Lerp(color, redPower, 1f);
        }
    }
}