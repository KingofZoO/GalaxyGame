using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAdditionalButtons : MonoBehaviour
{
    public void ShowPauseMenu()
    {
        UIPanelController.Instance.ShowPauseMenu();
    }

    public void ChangeLaser()
    {
        PlayerShipScript.Player.ChangeLaser();
    }
}
