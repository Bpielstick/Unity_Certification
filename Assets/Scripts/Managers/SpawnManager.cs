using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SpawnWave
{
    public List<GameObject> Enemies;
}

[System.Serializable]
public class SpawnWaveList
{
    public List<SpawnWave> Wave;
}

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager _instance;
    public static SpawnManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("Spawn Manager = Null");

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public SpawnWaveList spawnWaveList = new SpawnWaveList();
    private Vector3 _spawnPosition;
    private int _currentSpawnWave = 0;
    private const int _waveDelay = 2;
    private const float _spawnDelay = 0.75f;

    private int _spawnCount;
    public int SpawnCount
    {
        get
        {
            return _spawnCount;
        }
        set
        {
            _spawnCount = value;    
        }
    }

    void Start()
    {
        StartCoroutine(SpawnWaveRoutine());
    }

    void Update()
    {
        
    }

    private IEnumerator SpawnWaveRoutine()
    {
        yield return new WaitForSeconds(_waveDelay);

        foreach (GameObject enemy in spawnWaveList.Wave[_currentSpawnWave].Enemies)
        {
            if (enemy != null)
            { 
                Instantiate(enemy, new Vector3(85, UnityEngine.Random.Range(-26, 32), 0), Quaternion.identity);
                _spawnCount++;
            }

            yield return new WaitForSeconds(_spawnDelay);
        }

        StartCoroutine(SpawnCountRoutine());
    }

    private IEnumerator SpawnCountRoutine()
    {
        while (_spawnCount != 0)
        {
            yield return null;
        }

        _currentSpawnWave++;

        if (_currentSpawnWave >= spawnWaveList.Wave.Count)
            StartCoroutine(EndRoutine());
        else
            StartCoroutine(SpawnWaveRoutine());
    }

    private IEnumerator EndRoutine()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("VictoryScene");
    }
}