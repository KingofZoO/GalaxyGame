using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHPText : MonoBehaviour
{
    private Text hpText;

    private void Awake()
    {
        hpText = GetComponent<Text>();
    }

    private void Update()
    {
        if (Time.frameCount % 10 == 0)
        {
            var hp = PlayerShipScript.Player.CurrentHp;
            hpText.text = "HP x " + hp.ToString();
        }
    }
}
