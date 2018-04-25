using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    private List<BaseWaveScenario> waveScenarios = new List<BaseWaveScenario>();
    private BaseWaveScenario currWave;

    private bool waveStarted = false;

    private void Awake()
    {
        var scenarios = GetComponents<BaseWaveScenario>();

        foreach (var scen in scenarios)
            waveScenarios.Add(scen);
    }

    private void FixedUpdate()
    {
        if (!waveStarted)
            NewWave();
    }

    private void Update()
    {
        if (Time.frameCount % 10 == 0 && currWave.IsWaveEnded())
            waveStarted = false;
    }

    private void NewWave()
    {
        waveStarted = true;

        currWave = waveScenarios[Random.Range(0, waveScenarios.Count)];
        currWave.IsWaveStarted = true;
    }
}
