using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipScript : BaseShipScript
{
    public static PlayerShipScript Player { get; private set; }

    [SerializeField] private List<BaseLaserScript> playersLaser = new List<BaseLaserScript>();
    private int currLaser;

    private bool isScreenTouched = false;
    private float touchXPos = 0f;
    private Vector2 vectorOfTouch;
    private int signOfTouch;

    private float minXPos = -2.25f;
    private float maxXPos = 2.25f;

    private float shield;
    private float maxShield;
    private float shieldRegen = 0.02f;

    protected override void SetParameters()
    {
        Player = this;
        playersLaser.Add(laser);
        currLaser = playersLaser.Count - 1;

        hp = 3;
        shipSpeed = 0.1f;
        shield = 10f;
        maxShield = shield;
    }

    private void Update()
    {
        TouchCheck();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        shield += shieldRegen;
        shield = Mathf.Clamp(shield, 0, maxShield);
    }

    private void TouchCheck()
    {
        Vector3 touchPos = Input.mousePosition;
        bool touchType = Input.GetMouseButton(0);

        if (Application.platform == RuntimePlatform.Android)
        {
            touchPos = Input.touches[0].position;
            touchType = Input.touchCount > 0 && (Input.touches[0].phase == TouchPhase.Moved || Input.touches[0].phase == TouchPhase.Stationary);
        }

        if (touchType)
        {
            isScreenTouched = true;
            touchXPos = Camera.main.ScreenToWorldPoint(touchPos).x;
        }
        else isScreenTouched = false;
    }

    protected override void MoveShip()
    {
        if (!isScreenTouched)
            return;

        if (Mathf.Abs(transform.position.x - touchXPos) < 0.2f)
            return;

        if (touchXPos > transform.position.x)
            signOfTouch = 1;
        else signOfTouch = -1;

        transform.position += new Vector3(shipSpeed * signOfTouch, 0, 0);

        if (transform.position.x < minXPos)
            transform.position = new Vector3(minXPos, transform.position.y, 0);
        if (transform.position.x > maxXPos)
            transform.position = new Vector3(maxXPos, transform.position.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<IDamaged>() != null)
        {
            Instantiate(explodeEffect, col.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            TakeDamage(2);
        }
    }

    public override void TakeDamage(int damage)
    {
        shield -= damage;
        if (shield <= 0)
        {
            shield = 0;
            hp--;
        }

        if (hp <= 0)
        {
            hp = 0;
            Instantiate(explodeEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            UIPanelController.Instance.ShowLooseMenu();
        }
    }

    public void ChangeLaser()
    {
        currLaser++;
        if (currLaser == playersLaser.Count)
            currLaser = 0;

        laser = playersLaser[currLaser];
    }

    public float MaxShield
    {
        get { return maxShield; }
    }

    public float ShieldCharge
    {
        get { return shield; }
    }

    public int CurrentHp
    {
        get { return hp; }
    }
}
