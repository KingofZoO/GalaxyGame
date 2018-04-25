using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveThunderScenario : BaseWaveScenario
{
    [SerializeField] private BaseShipScript enemy;

    protected float currTime;
    protected float spawnInterval = 2.75f;
    protected int enemyCount = 3;
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
            var obj = Instantiate(enemy, transform.position, transform.rotation);
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
