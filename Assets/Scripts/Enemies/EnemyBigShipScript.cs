using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBigShipScript : BaseShipScript
{
    [SerializeField] private BaseLaserScript additionalLaser;
    private Transform[] shootPositions = new Transform[2];
    private float currAddTime;
    private int gunNumber;

    private float yStopPos = 4f;
    private float radDist = 2f;
    private bool isRotationStarted = false;

    private float centerYOffset;
    private float angle;
    private float angleSpeed = 1f;

    protected override void SetParameters()
    {
        hp = 10;
        shipSpeed = -0.04f;
        score = 50;

        shootPositions[0] = transform.Find("shoot_pos_2");
        shootPositions[1] = transform.Find("shoot_pos_3");
        gunNumber = Random.Range(0, 2);

        centerYOffset = yStopPos - radDist;
        angle = Vector2.SignedAngle(transform.position, Vector2.zero);
        currAddTime = additionalLaser.ShootInterval + Time.fixedTime;
    }

    protected override void MoveShip()
    {
        if (transform.position.y > yStopPos && !isRotationStarted)
            transform.position += new Vector3(0, shipSpeed, 0);
        else isRotationStarted = true;

        if (isRotationStarted)
        {
            var xPos = Mathf.Cos(angle * Mathf.Deg2Rad) * radDist;
            var yPos = Mathf.Sin(angle * Mathf.Deg2Rad) * radDist + centerYOffset;
            angle += angleSpeed;
            transform.position = new Vector3(xPos, yPos, 0);
        }
    }

    protected override void Fire()
    {
        base.Fire();

        if (Time.fixedTime > currAddTime)
        {
            var laserObj = Instantiate(additionalLaser, shootPositions[gunNumber].position, Quaternion.identity);
            laserObj.tag = tag;

            if (laserObj.GetComponent<RedLaserScript>() != null)
                laserObj.GetComponent<RedLaserScript>().ShootPos = transform;

            gunNumber++;
            if (gunNumber >= shootPositions.Length)
                gunNumber = 0;

            currAddTime += additionalLaser.ShootInterval;
        }
    }
}
