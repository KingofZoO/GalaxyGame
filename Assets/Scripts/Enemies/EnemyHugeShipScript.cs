using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHugeShipScript : BaseShipScript
{
    [SerializeField] private BaseShipScript enemy;
    private Transform[] spawnPoints = new Transform[2];
    private float spawnInterval = 1.6f;
    private float currSpawnTime;

    private float yStopPos = 3f;
    private float xSpeed = 0.01f;
    private float minXPos = -2f;
    private float maxXPos = 2f;
    private float sign;

    protected override void SetParameters()
    {
        hp = 20;
        shipSpeed = -0.02f;
        score = 100;

        spawnPoints[0] = transform.Find("spawn_point_1");
        spawnPoints[1] = transform.Find("spawn_point_2");

        sign = Random.Range(0, 2);
        sign = (sign > 0) ? sign = 1 : sign = -1;
        currSpawnTime = spawnInterval + Time.fixedTime;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        SpawnEnemy();
    }

    protected override void MoveShip()
    {
        if (transform.position.y > yStopPos)
            transform.position += new Vector3(0, shipSpeed, 0);
        else transform.position += new Vector3(xSpeed * sign, 0, 0);

        if (transform.position.x > maxXPos || transform.position.x < minXPos)
            xSpeed *= -1;
    }

    private void SpawnEnemy()
    {
        if (Time.fixedTime > currSpawnTime)
        {
            Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Length)].position, transform.rotation);
            currSpawnTime += spawnInterval;
        }
    }
}
