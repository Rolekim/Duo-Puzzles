using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stamina : MonoBehaviour
{
    [SerializeField]
    Slider sliderStamina = null;
    [SerializeField]
    TextMeshProUGUI staminaValueText = null;
    [SerializeField]
    TextMeshProUGUI coinText = null;

    // Update is called once per frame
    void Update()
    {
        RefreshStamina();
        RefreshCoins();
    }

    void RefreshStamina()
    {
        if (GameManager.gameManager != null)
        {
            sliderStamina.value = GameManager.gameManager.ReturnStamina();
            staminaValueText.text = (GameManager.gameManager.ReturnStamina() + " / 20");
        }

    }

    void RefreshCoins()
    {
        coinText.text = GameManager.gameManager.ReturnCoins().ToString();
    }
}
