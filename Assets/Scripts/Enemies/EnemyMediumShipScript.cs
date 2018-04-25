using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMediumShipScript : BaseShipScript
{
    private Transform playerShipPos;

    protected override void SetParameters()
    {
        hp = 5;
        shipSpeed = -0.025f;
        score = 25;
    }

    private void Start()
    {
        if (PlayerShipScript.Player != null)
            playerShipPos = PlayerShipScript.Player.transform;
        else playerShipPos = null;
    }

    protected override void MoveShip()
    {
        if (playerShipPos != null)
        {
            var distVector = playerShipPos.position - transform.position;
            transform.Translate(distVector.normalized * shipSpeed);
        }
        else transform.position += new Vector3(0, shipSpeed, 0);
    }
}
