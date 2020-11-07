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
        if (EnergyBarUI.Instance.Health - value > 0)
            EnergyBarUI.Instance.Health -= value;
        else
            gameObject.SetActive(false);
        EnergyBarUI.Instance.OnChangeEnergy?.Invoke();
    }
    public void RestoreDamage(float value)
    {
        if (EnergyBarUI.Instance.Health + value < EnergyBarUI.Instance.MaxHealth)
            EnergyBarUI.Instance.Health += value;
        else
            EnergyBarUI.Instance.Health = EnergyBarUI.Instance.MaxHealth;

        EnergyBarUI.Instance.OnChangeEnergy?.Invoke();
    }
}
