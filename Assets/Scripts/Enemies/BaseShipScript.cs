using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseShipScript : MonoBehaviour, IDamaged
{
    [SerializeField] protected BaseLaserScript laser;
    [SerializeField] protected GameObject explodeEffect;

    protected int hp;
    protected float currTime;
    protected float shipSpeed;
    protected int score = 0;

    protected Transform shootPos;

    protected abstract void SetParameters();
    protected abstract void MoveShip();

    protected virtual void Awake()
    {
        shootPos = transform.Find("shoot_pos");

        SetParameters();
        currTime = laser.ShootInterval + Time.fixedTime;
    }

    protected virtual void FixedUpdate()
    {
        Fire();
        MoveShip();
    }

    protected virtual void Fire()
    {
        if (Time.fixedTime > currTime)
        {
            var laserObj = Instantiate(laser, shootPos.position, Quaternion.identity);
            laserObj.tag = tag;

            if (laserObj.GetComponent<RedLaserScript>() != null)
                laserObj.GetComponent<RedLaserScript>().ShootPos = shootPos;

            currTime += laser.ShootInterval;
        }
    }

    public virtual void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            Instantiate(explodeEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            UIPanelController.Instance.GetScore(score);
        }
    }

    public Transform ShootPosition
    {
        get { return shootPos; }
    }
}
