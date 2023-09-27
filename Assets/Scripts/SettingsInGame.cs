using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsInGame : MonoBehaviour
{

    bool showConfig = false;

    [SerializeField]
    GameObject shop;

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowShop()
    {
        shop.SetActive(true);
        FindObjectOfType<ChangeController>().canMove = false;
    }

    public void DontShowShop()
    {
        shop.SetActive(false);
        FindObjectOfType<ChangeController>().canMove = true;
    }

    public void DoubleJump()
    {
        if(GameManager.gameManager.ReturnCoins() >= 2)
        {
            GameManager.gameManager.DecreaseCoins(2);
            FindObjectOfType<ChangeController>().canDoubleJump = true;
        }
    }

}
