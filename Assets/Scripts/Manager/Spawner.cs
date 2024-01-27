using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Singleton<Spawner>
{
    public event Action OnTimeElapsed = null;
    

    [SerializeField] List<Enemy> enemyTypesToSpawn = new List<Enemy>();
    [SerializeField] Player playerRef = null;
    [SerializeField] float currentTime = 0, waveDelay = 15, totalTimer = 0; /*spawnDelay = .5f,*/
    [SerializeField] float minSpawnRange = 50, maxSpawnRange = 75;
    [SerializeField] int waveNumber = 0, baseEnemyNumberToSpawn = 3, enemyNumberToSpawn = 0, lightToSpawn = 0, heavyToSpawn = 0;
    [SerializeField] bool waveCanSpawn = true;

    public float TotalTimer => totalTimer;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (!waveCanSpawn)
            IncreaseTime(ref currentTime, waveDelay);
        IncreaseTotalTimer(ref totalTimer);
    }

    void Init()
    {
        playerRef = FindObjectOfType<Player>();
        OnTimeElapsed += SpawnWave;
        EntityManager.Instance.OnLastEnemyKilled += LaunchNextWaveEarly;
        SpawnWave();
    }

    void SpawnWave() //Increase wave number and spawn enemies using numbers generated  via UpdateEnemyNumberToSpawn
    {
        if (!waveCanSpawn || !playerRef) return;
        waveNumber++;
        UpdateEnemyNumberToSpawn();
        for (int i = 0; i < heavyToSpawn; i++)
        {
            Enemy _spawned = Instantiate(enemyTypesToSpawn[0], GenerateRandomSpawnPosition(), Quaternion.identity);
            if (!_spawned) return;
            _spawned.PlayerRef = playerRef;
            EntityManager.Instance.AddEnemy(_spawned);
        }
        for (int i = 0; i < lightToSpawn; i++)
        {
            Enemy _spawned = Instantiate(enemyTypesToSpawn[1], GenerateRandomSpawnPosition(), Quaternion.identity);
            if (!_spawned) return;
            _spawned.PlayerRef = playerRef;
            EntityManager.Instance.AddEnemy(_spawned);
        }
        waveCanSpawn = false;
    }

    void IncreaseTime(ref float _current, float _max) //wave delay, overriden if there are no enemies remaining
    {
        _current += Time.deltaTime;
        if(_current >= _max) 
        {
            _current = 0;
            waveDelay += 5;
            waveCanSpawn = true;
            OnTimeElapsed?.Invoke();
        }
    }

    void IncreaseTotalTimer(ref float _current) //total timer for high score
    {
        _current += Time.deltaTime;
    }

    Vector3 GenerateRandomSpawnPosition() //get random point around the player
    {
        if (!playerRef) return Vector3.zero;
        Vector3 _center = playerRef.transform.position;
        float _range = UnityEngine.Random.Range(minSpawnRange, maxSpawnRange);
        Vector2 _offset = UnityEngine.Random.insideUnitCircle.normalized * _range;
        Vector3 _spawnPos = _center + new Vector3(_offset.x, 0, _offset.y);
        return _spawnPos;
    }

    void UpdateEnemyNumberToSpawn()
    {
        enemyNumberToSpawn = baseEnemyNumberToSpawn + Mathf.RoundToInt(waveNumber * 1.2f); //update total enemy number based on the wave number
        heavyToSpawn = 1 + Mathf.RoundToInt(enemyNumberToSpawn / 5); //20% (rounded) heavy enemies
        lightToSpawn = enemyNumberToSpawn - heavyToSpawn; //the rest is lightEnemies
    }

    void LaunchNextWaveEarly()
    {
        if (!playerRef) return;
        waveCanSpawn = true;
        currentTime = 0;
        OnTimeElapsed?.Invoke();
    }
}
