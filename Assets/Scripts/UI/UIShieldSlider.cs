using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShieldSlider : MonoBehaviour
{
    private Slider shieldSlider;
    private float maxShield;
    private PlayerShipScript player;

    private void Awake()
    {
        shieldSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        player = PlayerShipScript.Player;
        maxShield = player.MaxShield;
    }

    private void Update()
    {
        if (Time.frameCount % 10 == 0)
            shieldSlider.value = player.ShieldCharge / maxShield;
    }
}
