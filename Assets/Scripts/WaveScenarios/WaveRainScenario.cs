﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveRainScenario : BaseWaveScenario
{
    [SerializeField] private EnemyTinyShipScript enemy;

    private float currTime;
    private float spawnInterval = 0.6f;
    private int enemyCount = 30;
    private int enemySpawned = 0;
    private bool isEnemySpawned = false;

    private void Awake()
    {
        minWaveTime = enemyCount * spawnInterval;
        currTime = spawnInterval + Time.fixedTime;
    }

    protected override void WaveScenario()
    {
        if (isEnemySpawned)
            return;

        if (Time.fixedTime > currTime)
        {
            var randX = Random.Range(-2f, 2f);
            var obj = Instantiate(enemy, transform.position + new Vector3(randX, 0, 0), transform.rotation);
            sceneEnemy.Add(obj);

            enemySpawned++;
            if (enemySpawned >= enemyCount)
                isEnemySpawned = true;

            currTime += spawnInterval;
        }
    }

    protected override void RefreshValues()
    {
        base.RefreshValues();
        enemySpawned = 0;
        isEnemySpawned = false;
        currTime = spawnInterval + Time.fixedTime;
    }
}
