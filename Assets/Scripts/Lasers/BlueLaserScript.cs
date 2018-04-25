using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLaserScript : BaseLaserScript
{
    protected override void SetParameters()
    {
        laserSpeed = 0.25f;
        lifeTime = 1f;
        damage = 2;
        shootInterval = 0.5f;
    }
}
