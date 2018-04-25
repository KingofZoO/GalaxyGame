using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWaveScenario : MonoBehaviour
{
    protected abstract void WaveScenario();

    protected List<BaseShipScript> sceneEnemy = new List<BaseShipScript>();
    protected bool isWaveStarted = false;

    private bool isNewCall = true;
    protected float minWaveTime = 5f;
    private float currWaveTime;

    private void Awake()
    {
        currWaveTime = minWaveTime + Time.fixedTime;
    }

    private void FixedUpdate()
    {
        if (isWaveStarted)
        {
            if (isNewCall)
            {
                RefreshValues();
                isNewCall = false;
            }

            WaveScenario();
        }
    }

    protected virtual void RefreshValues()
    {
        sceneEnemy.RemoveRange(0, sceneEnemy.Count);
        currWaveTime = minWaveTime + Time.fixedTime;
    }

    public virtual bool IsWaveEnded()
    {
        if (Time.fixedTime > currWaveTime)
        {
            if (sceneEnemy.Exists(i => i != null))
                return false;
            else
            {
                isWaveStarted = false;
                isNewCall = true;
                return true;
            }
        }
        return false;
    }

    public bool IsWaveStarted
    {
        get { return isWaveStarted; }
        set { isWaveStarted = value; }
    }
}
