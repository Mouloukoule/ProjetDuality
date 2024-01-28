using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveStatusUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentWaveText = null;
    [SerializeField] TextMeshProUGUI nextWaveText = null;
    [SerializeField] TextMeshProUGUI enemyRemainingText = null;

    double currentTime = 0;
    double waveDelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ConvertTimer();
        SetCurrentWaveText(Spawner.Instance.WaveNumber);
        SetNextWaveText(waveDelay, currentTime);
        SetEnemyToKillText(Spawner.Instance.EnemyNumberToSpawn);
    }

    void SetCurrentWaveText(int _value)
    {
        currentWaveText.text = $"Current Wave : {_value}";
    }

    void SetNextWaveText(double _waveDelay, double _current)
    {
        nextWaveText.text = $"Next Wave when all present enemy killed or in {_waveDelay - _current} s";
    }

    void SetEnemyToKillText(int _enemies)
    {
        enemyRemainingText.text = $"Enemies to Kill : {_enemies}";
    }

    void ConvertTimer()
    {
        currentTime = Math.Round(Spawner.Instance.CurrentTime);
        waveDelay = Math.Round(Spawner.Instance.WaveDelay);
    }
}
