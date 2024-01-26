using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Singleton<Spawner>
{
    //public event Action OnTimeElapsed = null;

    //[SerializeField] List<Enemy> enemyTypesToSpawn = new List<Enemy>();
    //[SerializeField] Player playerRef = null;
    //[SerializeField] float currentTime = 0, waveDelay = 15, spawnDelay = .5f, totalTimer = 0;
    //[SerializeField] float minSpawnRange = 50, maxSpawnRange = 75;
    //[SerializeField] int waveNumber = 1, enemyNumberToSpawn = 5;
    //[SerializeField] bool waveFinishedSpawn = false, waveCanSpawn = false;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    playerRef = FindObjectOfType<Player>();
    //    //InvokeRepeating(nameof(SpawnWave),3 ,waveDelay);
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    //void SpawnWave()
    //{
    //    UpdateEnemyNumberToSpawn();
    //    Vector3 _spawnPos = GetRandomSpawnPosition();
        
    //    waveNumber++;
    //}

    //Vector3 GetRandomSpawnPosition()
    //{
    //    Vector3 _center = playerRef.transform.position;
    //    float _range = UnityEngine.Random.Range(minSpawnRange, maxSpawnRange);
    //    Vector2 _offset = UnityEngine.Random.insideUnitCircle * _range;
    //    Vector3 _spawnPos = _center + new Vector3(_offset.x, 0, _offset.y);
    //    return _spawnPos;
    //}

    //void GetEnemyRepartition()
    //{

    //}

    //void UpdateEnemyNumberToSpawn()
    //{
    //    enemyNumberToSpawn =  + Mathf.RoundToInt(waveNumber * 1.2f);
    //}

    //float IncreaseTime(float _current, float _max)
    //{
    //    _current += Time.deltaTime;
    //    if(_current >= _max)
    //    {
    //        _current = 0;
    //        OnTimeElapsed?.Invoke();
    //    }
    //    return _current;
    //}
}
