using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField]
    int staminaCost;


    public void Start()
    {
        NextLevel();
    }


    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 10)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if(GameManager.gameManager != null)
        {
            //var stamina = GameManager.gameManager.ReturnStamina() - staminaCost;
            //GameManager.gameManager.ChangeStamina(stamina);
        }

    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }
}
