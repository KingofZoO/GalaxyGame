using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMoving : MonoBehaviour
{
    [SerializeField] private float angleSpeed = 1f;

    private float distToSun;
    private float angleToSun;

    private void Awake()
    {
        distToSun = Vector2.Distance(transform.position, transform.parent.position);
        angleToSun = Vector2.SignedAngle(transform.parent.position, transform.position);
    }

    private void FixedUpdate()
    {
        RotatePlanet();
    }

    private void RotatePlanet()
    {
        var xPos = Mathf.Sin(angleToSun * Mathf.Deg2Rad) * distToSun;
        var yPos = Mathf.Cos(angleToSun * Mathf.Deg2Rad) * distToSun;
        angleToSun += angleSpeed;

        transform.position = transform.parent.position - new Vector3(xPos, yPos, 0);
        transform.Rotate(0, 0, -2f);
    }
}
