using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTinyShipScript : BaseShipScript
{
    private float amplitude = 0.05f;
    private float amplSign;
    private float sinArg = 0;

    protected override void SetParameters()
    {
        hp = 1;
        shipSpeed = -0.05f;
        score = 5;

        amplSign = Random.Range(0, 2);
        amplSign = (amplSign > 0) ? amplSign = 1 : amplSign = -1;
    }

    protected override void MoveShip()
    {
        transform.position += new Vector3(Mathf.Sin(sinArg) * amplitude, shipSpeed, 0);
        sinArg += 0.1f;
    }
}
