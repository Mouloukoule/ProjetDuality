using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarUI : MonoBehaviour
{
    [SerializeField] Slider playerHealthSlider = null;
    [SerializeField] TextMeshProUGUI playerHealthText = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePlayerHealthSlider(int _value)
    {
        playerHealthSlider.value = _value;
    }

    public void SetPlayerHealthText(int _value)
    {
        playerHealthText.text = $"{_value}";
    }
}
