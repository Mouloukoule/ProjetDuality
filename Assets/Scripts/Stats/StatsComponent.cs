using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatsComponent : MonoBehaviour
{
    public event Action<bool> OnDeath = null;
    public event Action<int> OnHpUpdated = null;

    [SerializeField] protected string entityname = "";
    [SerializeField] protected int damage = 0;
    [SerializeField] protected int maxHp = 5, currentHp = 0;
    [SerializeField] protected bool isDead = false;

    public string EntityName => entityname;
    public int Damage => damage;
    public int Maxhp => maxHp;
    public int CurrentHp => currentHp;

    private void Start()
    {
        OnDeath += SetIsDead;
    }

    public void SetName(string _name)
    {
        entityname = _name;
    }

    public void SetDamage(int _damage)
    {
        damage = _damage;
    }

    public void SetMaxHp(int _maxHp)
    {
        maxHp = _maxHp;
    }

    public void SetCurrent(int _currentHp) 
    {
        currentHp = _currentHp;
    }

    public void AddHp(int _toAdd)
    {
        if(isDead) return;
        currentHp += _toAdd;
        if(currentHp <= 0)
        {
            currentHp = 0;
            OnDeath?.Invoke(true);
        }
        OnHpUpdated?.Invoke(currentHp);
    }

    public void SetIsDead(bool _value)
    {
        isDead = _value;
    }
}
