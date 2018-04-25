using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseLaserScript : MonoBehaviour
{
    [SerializeField] protected float shootInterval;

    protected float laserSpeed;
    protected float lifeTime;
    protected int damage;

    protected int signSpeed = 1;

    protected abstract void SetParameters();

    protected virtual void Awake()
    {
        SetParameters();
        Destroy(gameObject, lifeTime);
    }

    private void Start()
    {
        if (tag == "Enemy")
            signSpeed = -1;
    }

    protected virtual void FixedUpdate()
    {
        MoveLaser();
    }

    protected virtual void MoveLaser()
    {
        transform.position += new Vector3(0, laserSpeed * signSpeed, 0);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag != tag && col.gameObject.GetComponent<IDamaged>() != null)
        {
            col.gameObject.GetComponent<IDamaged>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public float ShootInterval
    {
        get { return shootInterval; }
    }
}
