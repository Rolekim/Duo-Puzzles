using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField]
    int levelsAvalible = 1;
    [SerializeField]
    private int stamina = 20;
    [SerializeField]
    private float counter = 0;
    [SerializeField]
    private int coins = 0;


    void Awake()
    {
        if(gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    void Update()
    {
        counter += Time.deltaTime;

        if (counter >= 120)
        {
            ChangeStamina(stamina + 1);
            counter = 0;
        }
    }

    public void IncreaseCoins()
    {
        coins += 1;
    }

    public void DecreaseCoins(int value)
    {
        coins -= value;

        if(coins < 0)
        {
            coins = 0;
        }

    }

    public int ReturnStamina()
    {
        return stamina;
    }

    public void ChangeStamina(int newStamina)
    {
        stamina = newStamina;

        if(stamina >= 20)
        {
            stamina = 20;
        }

    }

    public void IncreaseLevel(int level)
    {
        levelsAvalible = level;
    }

    public int ReturnLevels()
    {
        return levelsAvalible;
    }

    public int ReturnCoins()
    {
        return coins;
    }
}
