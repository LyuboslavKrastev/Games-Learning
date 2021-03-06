﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private GameObject[] _powerUpPrefabs;

    private bool _continueSpawning = true;

    // Start is called before the first frame update

    public void StartSpawning()
    {
        StartCoroutine(this.SpawnEnemyRoutine());
        StartCoroutine(this.SpawnPowerUpRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3.0f); // In order to make spawning not so immediate

        while (_continueSpawning)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 7, 0);

            GameObject newEnemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);

            newEnemy.transform.parent = _enemyContainer.transform; // parent is a transform type

            yield return new WaitForSeconds(5.0f); // wait for 5 seconds so we dont get a stack overflow
        }
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        yield return new WaitForSeconds(3.0f); // In order to make spawning not so immediate

        while (_continueSpawning)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-8f, 8f), 7, 0);

            int powerUpindex = Random.Range(0, 3);

            GameObject newPowerup = Instantiate(_powerUpPrefabs[powerUpindex], spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(7.0f, 12.0f));
        }
    }

    public void OnPlayerDeath()
    {
        _continueSpawning = false;
    }
}
