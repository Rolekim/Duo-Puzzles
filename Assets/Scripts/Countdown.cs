using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    float minutes = 1;
    float seconds = 30;
    public bool timerIsRunning = false;
    [SerializeField]
    TextMeshProUGUI counter = null;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if(seconds < 10)
        {
            counter.text = (int)minutes + " : 0" + (int)seconds;
        }
        else
        {
            counter.text = (int)minutes + " : " + (int)seconds;
        }

        if (timerIsRunning)
        {
            if (seconds > 0)
            {
                seconds -= Time.deltaTime;
            }
            else
            {
                if(minutes == 1)
                {
                    minutes = 0;
                    seconds = 60;
                }
                else
                {
                    Debug.Log("Time has run out!");
                    SceneManager.LoadScene(0);
                }

            }
        }
    }

}
