using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarUI : MonoBehaviour
{
    public static EnergyBarUI Instance;
    [Range(0, 100)]
    public float Health = 100f;
    public Slider Slider;
    public Text EnergyValue;

    public delegate void ChangeEnergy();
    public ChangeEnergy OnChangeEnergy;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance = this)
            Destroy(gameObject);

        DisplayEnergy();
        OnChangeEnergy += DisplayEnergy;
    }

    void Update()
    {
        //OnChangeEnergy?.Invoke();
    }
    private void DisplayEnergy()
    {
        Slider.value = Health;
        EnergyValue.text = ((int)Health).ToString();
    }
}
