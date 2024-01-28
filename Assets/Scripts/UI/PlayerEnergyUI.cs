using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergyBarUI : MonoBehaviour
{
    [SerializeField] Slider playerEnergySlider = null;
    [SerializeField] TextMeshProUGUI playerEnergyText = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePlayerEnergySlider(int _value)
    {
        playerEnergySlider.value = _value;
    }

    public void SetPlayerEnergyText(int _value)
    {
        playerEnergyText.text = $"{_value}";
    }
}
