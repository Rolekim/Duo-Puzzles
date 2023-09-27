using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleJumpButton : MonoBehaviour
{
    Button doubleJumpButton;

    void Awake()
    {
        doubleJumpButton = GetComponent<Button>();
    }

    void Update()
    {
        if(GameManager.gameManager.ReturnCoins() >= 2 && !ChangeController.changeController.canDoubleJump)
        {
            doubleJumpButton.interactable = true;
        }
        else
        {
            doubleJumpButton.interactable = false;
        }
    }
}
