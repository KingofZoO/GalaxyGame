using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmallShipScript : BaseShipScript
{
    private Vector3 destPos;
    public bool IsDestinated { get; set; }
    public bool IsLegionFormed { get; set; }
    private Vector3 distVector;

    private float distSqrOffset = 0.01f;
    private float distYSpeed = -0.01f;
    private float amplitude = 0.005f;
    private float sinArg = 0;

    protected override void SetParameters()
    {
        hp = 2;
        shipSpeed = -0.05f;
        score = 10;

        IsDestinated = false;
        IsLegionFormed = false;
    }

    protected override void MoveShip()
    {
        if (!IsDestinated)
        {
            distVector = destPos - transform.position;
            if (distVector.sqrMagnitude < distSqrOffset)
                IsDestinated = true;
            transform.Translate(distVector.normalized * shipSpeed);
        }
        else if(IsDestinated && IsLegionFormed)
        {
            transform.position += new Vector3(Mathf.Sin(sinArg) * amplitude, distYSpeed, 0);
            sinArg += 0.02f;
        }
    }

    public void SetDestinationPos(Vector3 pos)
    {
        destPos = pos;
    }
}
