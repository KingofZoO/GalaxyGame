using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLaserScript : BaseLaserScript
{
    public bool IsSecondary { get; set; }
    public Transform ShootPos { get; set; }

    private float currTime;
    private float queueInterval = 0.1f;
    private int queueCount = 2;

    protected override void SetParameters()
    {
        laserSpeed = 0.25f;
        lifeTime = 1f;
        damage = 1;
        shootInterval = 1f;

        IsSecondary = false;
    }

    protected override void Awake()
    {
        base.Awake();
        currTime = queueInterval + Time.fixedTime;

        InvokeRepeating("CreateQueue", queueInterval, queueInterval);
    }

    private void CreateQueue()
    {
        if (IsSecondary == false && ShootPos != null)
        {
            var obj = Instantiate(this, ShootPos.position, transform.rotation);
            obj.IsSecondary = true;
            queueCount--;

            if (queueCount <= 0)
            {
                IsSecondary = true;
                CancelInvoke();
            }
        }
    }
}
