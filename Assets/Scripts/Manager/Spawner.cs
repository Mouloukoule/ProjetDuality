using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Singleton<Spawner>
{
    public event Action OnTimeElapsed = null;

    [SerializeField] List<Enemy> enemyTypesToSpawn = new List<Enemy>();
    [SerializeField] List<Vector3> debugPositions = new List<Vector3>();
    [SerializeField] Player playerRef = null;
    [SerializeField] float currentTime = 0, waveDelay = 15, spawnDelay = .5f, totalTimer = 0;
    [SerializeField] float minSpawnRange = 50, maxSpawnRange = 75;
    [SerializeField] int waveNumber = 0, baseEnemyNumberToSpawn = 3, enemyNumberToSpawn = 0, lightToSpawn = 0, heavyToSpawn = 0;
    [SerializeField] bool waveFinishedSpawn = false, waveCanSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRef = FindObjectOfType<Player>();
        //InvokeRepeating(nameof(SpawnWave),3 ,waveDelay);
        for (int i = 0; i < 5; i++)
        {
            debugPositions.Add(GetRandomSpawnPosition());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnWave()
    {
        waveNumber++;
        UpdateEnemyNumberToSpawn();
        

    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 _center = playerRef.transform.position;
        Debug.Log(_center);
        float _range = UnityEngine.Random.Range(minSpawnRange, maxSpawnRange);
        Vector2 _offset = UnityEngine.Random.insideUnitCircle.normalized * _range;
        Debug.Log($"offset : {_offset}");

        Vector3 _spawnPos = _center + new Vector3(_offset.x, 0, _offset.y);

        return _spawnPos;
    }

    void GetEnemyRepartition()
    {

    }

    void UpdateEnemyNumberToSpawn()
    {
        enemyNumberToSpawn = baseEnemyNumberToSpawn + Mathf.RoundToInt(waveNumber * 1.2f);
        heavyToSpawn = 1 + Mathf.RoundToInt(enemyNumberToSpawn / 5);
        lightToSpawn = enemyNumberToSpawn - heavyToSpawn;
    }

    float IncreaseTime(float _current, float _max)
    {
        _current += Time.deltaTime;
        if (_current >= _max)
        {
            _current = 0;
            OnTimeElapsed?.Invoke();
        }
        return _current;
    }

    private void OnDrawGizmos()
    {
        if (!playerRef) return;
        Gizmos.color = Color.black;
        for (int i = 0; i < 5; i++)
        {
            Gizmos.DrawSphere(debugPositions[i], 1);
        }
        Gizmos.color = Color.white;
    }
}
