using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerMoveSpeedText = null;
    [SerializeField] TextMeshProUGUI playerAttackSpeedText = null;
    [SerializeField] TextMeshProUGUI skillCooldownText = null;
    [SerializeField] PlayerAttackComponent playerAttackComponent = null;

    double skillCooldown = 0; 
    double skillCurrentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ConvertTimer();
        SetSkillCooldownText(skillCooldown, skillCurrentTime);
    }

    public void SetPlayerMoveSpeedText(float _value)
    {
        playerMoveSpeedText.text = $"Your move speed is now : {_value}";
    }

    public void SetPlayerAttackSpeedText(float _value)
    {
        playerAttackSpeedText.text = $"Your attack speed is now : {1 - _value}/s";
    }

    public void SetSkillCooldownText(double _cooldown, double _current)
    {
        skillCooldownText.text = $"Your next Heal is in : {_cooldown - _current} s";
    }

    void ConvertTimer()
    {
        skillCooldown = Math.Round(playerAttackComponent.Skill1Cooldown, 1);
        skillCurrentTime = Math.Round(playerAttackComponent.Skill1CurrentTime, 1);
    }
}
