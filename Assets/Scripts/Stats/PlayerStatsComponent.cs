using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatsComponent : StatsComponent
{
    public event Action<float> OnRangeUpdated = null;
    public event Action<float> OnMoveSpeedUpdated = null;
    public event Action<float> OnAttackSpeedUpdated = null;
    public event Action<int> OnEnergyUpdated = null;

    [SerializeField] float range = 50;
    [SerializeField] float baseMoveSpeed = 10;
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float attackSpeed = .5f;
    [SerializeField] float baseAttackSpeed = .5f;
    [SerializeField] int currentEnergy = 50;
    [SerializeField] int maxEnergy = 100;
    [SerializeField] float currentTime = 0, depletionTimer = 3;

    [SerializeField] int energyToDeplete = 5, hpToDeplete = 1;
    [SerializeField] bool canLoseHp = false, canLoseEnergy = true;

    public float Range => range;
    public float MoveSpeed => moveSpeed;
    public float BaseMoveSpeed => baseMoveSpeed;
    public float AttackSpeed => attackSpeed;
    public float BaseAttackSpeed => BaseAttackSpeed;
    public int CurrentEnergy => currentEnergy;
    public int MaxEnergy => maxEnergy;

    // Start is called before the first frame update
    void Start()
    {
        OnEnergyUpdated += UpdateStatsBasedOnEnergy;
    }

    void Update()
    {
        if(canLoseEnergy)
            DepleteEnergyTimer(ref currentTime, depletionTimer);
        if(canLoseHp)
            DepleteHpTimer(ref currentTime, depletionTimer);
    }

    public void SetRange(float _range)
    {
        range = _range;
        OnRangeUpdated?.Invoke(range);
    }

    public void SetMoveSpeed(float _moveSpeed)
    {   
        moveSpeed = _moveSpeed;
        OnMoveSpeedUpdated?.Invoke(moveSpeed);
    }

    public void SetAttackSpeed(float _attackSpeed)
    {
        attackSpeed = _attackSpeed;
        OnAttackSpeedUpdated?.Invoke(attackSpeed);
    }

    public void SetEnergy(int _energy)
    {
        currentEnergy = _energy;
        OnEnergyUpdated?.Invoke(currentEnergy);
    }

    public void AddEnergy(int _toAdd)
    {
        if (isDead) return;
        currentEnergy += _toAdd;
        if(currentEnergy <= 0)
        {
            currentEnergy = 0;
        }
        OnEnergyUpdated?.Invoke(currentEnergy);
    }

    void DepleteEnergyTimer(ref float _current, float _max)
    {
        _current += Time.deltaTime;
        if(_current >= _max)
        {
            _current = 0;
            AddEnergy(-energyToDeplete);
        }
    }

    void DepleteHpTimer(ref float _current, float _max)
    {
        _current += Time.deltaTime;
        if (_current >= _max)
        {
            _current = 0;
            AddHp(-hpToDeplete);
        }
    }

    void UpdateStatsBasedOnEnergy(int _energy)
    {
        switch (_energy)
        {
            default:
                {
                    canLoseHp = false;
                    moveSpeed = baseMoveSpeed;
                    attackSpeed = baseAttackSpeed;
                    break;
                }
            case 0: 
                {
                    canLoseHp = true;
                    break;
                }
            case >= 100:
                {
                    canLoseHp = true;
                    attackSpeed = baseAttackSpeed * 1.5f;
                    break;
                }
            case >= 80: 
                {
                    canLoseHp = false;
                    moveSpeed = baseMoveSpeed / 2;
                    break;
                }

        }
    }
}
