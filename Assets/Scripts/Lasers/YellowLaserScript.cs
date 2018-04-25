using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowLaserScript : BaseLaserScript
{
    [SerializeField] private GameObject explodeEffect;

    protected override void SetParameters()
    {
        laserSpeed = 0.15f;
        lifeTime = 2f;
        damage = 5;
        shootInterval = 1f;
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        if (col.transform.tag != tag && col.gameObject.GetComponent<IDamaged>() != null)
            Instantiate(explodeEffect, transform.position, Quaternion.identity);
    }
}
