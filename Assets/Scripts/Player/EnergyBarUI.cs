using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBarUI : MonoBehaviour
{
    public static EnergyBarUI Instance;

    public Slider Slider;
    public Text EnergyValue;

    public delegate void ChangeEnergy();
    public ChangeEnergy OnChangeEnergy;

    Color textColor;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance = this)
            Destroy(gameObject);
        textColor = EnergyValue.color;
        DisplayEnergy();
        OnChangeEnergy += DisplayEnergy;
    }

    void Update()
    {
        //OnChangeEnergy?.Invoke();
    }
    private void DisplayEnergy()
    {
        float playerEnergy = Player.Instance.Health;
        Slider.value = playerEnergy;
        EnergyValue.text = ((int)playerEnergy).ToString();

        if (playerEnergy < 30f)
            EnergyValue.color = Color.red;
        else
            EnergyValue.color = textColor;
    }
}
