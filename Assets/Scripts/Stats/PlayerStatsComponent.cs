using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsComponent : StatsComponent
{
    public event Action<float> OnRangeUpdated = null;
    public event Action<float> OnMoveSpeedUpdated = null;
    public event Action<float> OnAttackSpeedUpdated = null;
    public event Action<int> OnEnergyUpdated = null;

    [SerializeField] float range = 0;
    [SerializeField] float baseMoveSpeed = 5;
    [SerializeField] float moveSpeed = 0;
    [SerializeField] float attackSpeed = 0;
    [SerializeField] float baseAttackSpeed = .5f;
    [SerializeField] int currentEnergy = 0;
    [SerializeField] int maxEnergy = 0;

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
        
    }

    void Update()
    {
        
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
}
