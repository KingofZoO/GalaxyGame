using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveLegionScenario : BaseWaveScenario
{
    [SerializeField] private EnemySmallShipScript enemy;

    private float currTime;
    private float spawnInterval = 0.4f;

    private float xDist = 1.2f;
    private float yDist = 1f;
    private float yOffset = 3f;

    private int legionSize;
    private int xSize = 3;
    private int ySize = 3;
    private Vector3[] positions;
    private int destinated = 0;
    private int living = 0;

    private bool isLegionFormed = false;

    private void Awake()
    {
        legionSize = xSize * ySize;
        positions = new Vector3[legionSize];
        minWaveTime = legionSize * spawnInterval;
        currTime = spawnInterval + Time.fixedTime;
    }

    private void Start()
    {
        SetPositions();
    }

    protected override void WaveScenario()
    {
        if (isLegionFormed)
            return;

        if (Time.fixedTime > currTime)
        {
            if (legionSize > 0)
            {
                var obj = Instantiate(enemy, transform.position, transform.rotation);
                sceneEnemy.Add(obj);
                obj.GetComponent<EnemySmallShipScript>().SetDestinationPos(positions[legionSize - 1]);

                legionSize--;
            }
            else if (legionSize <= 0)
            {
                destinated = 0;
                living = 0;
                foreach (var en in sceneEnemy)
                {
                    if (en != null)
                        living++;
                    if (en != null && en.GetComponent<EnemySmallShipScript>().IsDestinated)
                        destinated++;
                }

                if (destinated == living)
                {
                    foreach (var en in sceneEnemy)
                        if (en != null)
                            en.GetComponent<EnemySmallShipScript>().IsLegionFormed = true;
                    isLegionFormed = true;
                }
            }

            currTime += spawnInterval;
        }
    }

    private void SetPositions()
    {
        for (int i = 0; i < xSize; i++)
            for (int j = 0; j < ySize; j++)
            {
                positions[j + i * xSize] = new Vector3(xDist * (j - 1), yDist * (i - 1) + yOffset, 0);
            }
    }

    protected override void RefreshValues()
    {
        base.RefreshValues();
        isLegionFormed = false;
        legionSize = xSize * ySize;
        destinated = 0;
        living = 0;
        currTime = spawnInterval + Time.fixedTime;
    }
}
