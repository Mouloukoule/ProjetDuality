using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayedTimerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playedTimerText = null;
    double timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ConvertTimer();
        SetPlayedTimerText(timer);
    }

    void SetPlayedTimerText(double _value)
    {
        playedTimerText.text = $"Time alive : {_value} s";        
    }

    void ConvertTimer()
    {
        timer = Math.Round(Spawner.Instance.TotalTimer, 1);
    }
}
