using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHugeBossScenario : BaseWaveScenario
{
    [SerializeField] private EnemyHugeShipScript enemy;
    private bool isEnemySpawned = false;

    protected override void WaveScenario()
    {
        if (!isEnemySpawned)
        {
            var obj = Instantiate(enemy, transform.position, transform.rotation);
            sceneEnemy.Add(obj);
            isEnemySpawned = true;
        }
    }

    protected override void RefreshValues()
    {
        base.RefreshValues();
        isEnemySpawned = false;
    }
}
