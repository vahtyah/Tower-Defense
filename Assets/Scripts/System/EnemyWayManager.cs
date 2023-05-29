using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayManager : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public int Amount;
        public GameObject Enemy;
        public float SpawnTime;
        public float RestTime;
        public int AmountHealth;
    }

    [SerializeField] List<Wave> waves;
    private int waveIndex = 0;
    private Wave currentWave;
    private float spawnTime = 2.0f;

    [SerializeField] List<Vector2Int> pathCells;

    public List<Vector2Int> PathCells { get { return pathCells; } }

    private void OnEnable()
    {
        currentWave = waves[waveIndex];
    }

    private void Update()
    {
        Spawn();
        if (waveIndex >= waves.Count)
        {
            Enemy[] enemies = transform.GetComponentsInChildren<Enemy>();
            foreach (Enemy enemy in enemies)
            {
                if (enemy.gameObject.activeSelf)
                {
                    return;
                }
            }
            Player.instance.OnCompleteLevel();
        }
    }

    private void Spawn()
    {
        if (waveIndex >= waves.Count) return;
        if (currentWave.RestTime < 0)
        {
            waveIndex += 1;
            if (waveIndex >= waves.Count) return;

            currentWave = waves[waveIndex];
            return;
        }

        if (currentWave.Amount <= 0)
        {
            currentWave.RestTime -= Time.deltaTime;
            return;
        }

        if (spawnTime < 0)
        {
            Enemy.Create(currentWave.Enemy, currentWave.AmountHealth);
            spawnTime = currentWave.SpawnTime;
            currentWave.Amount--;
            return;
        }

        spawnTime -= Time.deltaTime;
    }

    public void setPathCells(List<Vector2Int> pathCells)
    {
        this.pathCells = pathCells;
    }
}
