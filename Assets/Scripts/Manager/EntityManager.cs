using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : Singleton<EntityManager>
{
    public event Action OnLastEnemyKilled = null;

    [SerializeField] List<Enemy> allEnemies = new List<Enemy>();
    [SerializeField] bool noEnemies = false;
    public List<Enemy> AllEnemies => allEnemies;

    private void Update()
    {
        noEnemies = CheckIfEmpty();
        if(noEnemies)
            OnLastEnemyKilled?.Invoke();
    }

    public bool CheckIfEmpty()
    {
        return allEnemies.Count == 0;
    }

    public void AddEnemy(Enemy _toAdd)
    {
        if(!_toAdd || Exist(_toAdd)) return;
        allEnemies.Add(_toAdd);
        _toAdd.name += "[Managed]";
    }

    public void RemoveEnemy(Enemy _toRemove)
    {
        if(!Exist(_toRemove)) return;
        allEnemies.Remove(_toRemove);
    }

    public void RemoveEnemy(int  _index)
    {
        if (!Exist(_index)) return;
        allEnemies.RemoveAt(_index);
    }

    public void RemoveAll()
    {
        DestroyAllEnemiesReferenced();
        allEnemies.Clear();
    }

    public void DestroyAllEnemiesReferenced()
    {
        foreach (Enemy _enemy in allEnemies)
        {
            Destroy(_enemy.gameObject);
        }
    }

    public bool Exist(Enemy _toCheck)
    {
        return allEnemies.Contains(_toCheck);
    }

    public bool Exist(int _index)
    {
        if (_index >= allEnemies.Count || _index <= 0) return false;
        return Exist(allEnemies[_index]);
    }
}
