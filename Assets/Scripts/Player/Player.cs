using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance = this)
        {
            Destroy(gameObject);
        }
    }
    public void SetDamage(float value)
    {
        EnergyBarUI.Instance.Health -= value;
        EnergyBarUI.Instance.OnChangeEnergy?.Invoke();
    }
    public void RestoreDamage(float value)
    {
        EnergyBarUI.Instance.Health += value;
        EnergyBarUI.Instance.OnChangeEnergy?.Invoke();
    }
}
