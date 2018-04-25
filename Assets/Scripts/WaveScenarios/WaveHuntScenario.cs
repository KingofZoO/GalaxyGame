using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveHuntScenario : WaveThunderScenario
{
    private void Awake()
    {
        spawnInterval = 2f;
        enemyCount = 6;
        minWaveTime = spawnInterval * enemyCount;
        currTime = spawnInterval + Time.fixedTime;
    }

    protected override void RefreshValues()
    {
        base.RefreshValues();
    }
}
