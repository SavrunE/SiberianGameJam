using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Range(0, 100)]
    public float Health = 100f;
    public float MaxHealth = 100f;
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
        if ( Health - value > 0)
             Health -= value;
        else
            Application.Quit();
        EnergyBarUI.Instance.OnChangeEnergy?.Invoke();
    }
    public void RestoreDamage(float value)
    {
        if ( Health + value <  MaxHealth)
             Health += value;
        else
             Health =  MaxHealth;

        EnergyBarUI.Instance.OnChangeEnergy?.Invoke();
    }
}
