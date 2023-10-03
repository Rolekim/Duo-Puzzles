using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    Button[] LevelsButtons = null;
    [SerializeField]
    Animator anim = null;
    [SerializeField]
    Animator animSoundMenu = null;
    [SerializeField]
    Animator animCreditMenu = null;

    [SerializeField]
    GameObject titleScreen = null;
    [SerializeField]
    GameObject selectLevelScreen = null;
    [SerializeField]
    GameObject soundMenu = null;
    [SerializeField]
    GameObject creditMenu = null;
    [SerializeField]
    Slider sliderStamina = null;
    [SerializeField]
    TextMeshProUGUI staminaValueText = null;

    int staminaValue;

    bool showConfig = false;
    bool showCredits = false;

    bool isInTitle = true;

    void Awake()
    {
        staminaValue = (int)sliderStamina.maxValue;
        sliderStamina.value = sliderStamina.maxValue;
        selectLevelScreen.SetActive(false);
        titleScreen.SetActive(true);
        soundMenu.SetActive(false);
        creditMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isInTitle)
        {
            //anim.SetTrigger("OpenWalls");
            //StartCoroutine(ShowSelectLevel());
            ChangeToLevel1();
        }
        CheckLevels();
        RefreshStamina();
    }

    IEnumerator ShowSelectLevel()
    {
        yield return new WaitForSeconds(0.7f);
        titleScreen.SetActive(false);
        selectLevelScreen.SetActive(true);
        isInTitle = false;
    }

    public void ChangeToLevel1()
    {
        StartCoroutine(ChangeScene(1, 1));
    }

    public void ChangeToLevel2()
    {
        StartCoroutine(ChangeScene(1, 2));
    }

    public void ChangeToLevel3()
    {
        StartCoroutine(ChangeScene(1, 3));
    }

    public void ChangeToLevel4()
    {
        StartCoroutine(ChangeScene(1, 4));
    }

    public void ChangeToLevel5()
    {
        StartCoroutine(ChangeScene(2, 5));
    }

    public void ChangeToLevel6()
    {
        StartCoroutine(ChangeScene(2, 6));
    }

    public void ChangeToLevel7()
    {
        StartCoroutine(ChangeScene(2, 7));
    }

    public void ChangeToLevel8()
    {
        StartCoroutine(ChangeScene(2, 8));
    }

    public void ChangeToLevel9()
    {
        StartCoroutine(ChangeScene(3, 9));
    }

    public void ChangeToLevel10()
    {
        StartCoroutine(ChangeScene(3, 10));
    }

    public void ShowConfig()
    {
        if (showConfig)
        {
            animSoundMenu.SetBool("Close", true);
            showConfig = false;
        }
        else
        {
            showConfig = true;
            animCreditMenu.SetBool("Close", true);
            soundMenu.SetActive(true);
            animSoundMenu.SetBool("Close", false);
        }
    }

    public void ShowCredits()
    {
        if (showCredits)
        {
            animCreditMenu.SetBool("Close", true);
            showCredits = false;
        }
        else
        {
            showCredits = true;
            animSoundMenu.SetBool("Close", true);
            creditMenu.SetActive(true);
            animCreditMenu.SetBool("Close", false);
        }
    }

    IEnumerator ChangeScene(int staminaCost, int level)
    {
        if(staminaCost < GameManager.gameManager.ReturnStamina())
        {
            /*CalculateStamina(staminaCost);
            yield return new WaitForSeconds(0.4f);
            anim.SetTrigger("CloseWalls");

            yield return new WaitForSeconds(0.2f);
            selectLevelScreen.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + level);*/
            //yield return new WaitForSeconds(0.4f);
            //anim.SetTrigger("CloseWalls");

            yield return new WaitForSeconds(0.2f);
            selectLevelScreen.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + level);
        }
        else
        {
            print("hula");
        }

    }

    void CalculateStamina(int staminaCost)
    {
        
        GameManager.gameManager.ChangeStamina(GameManager.gameManager.ReturnStamina() - staminaCost);

        if (staminaValue <= 0)
        {
            staminaValue = 0;
        }

        RefreshStamina();
    }

    void RefreshStamina()
    {
        sliderStamina.value = GameManager.gameManager.ReturnStamina();
        staminaValueText.text = (GameManager.gameManager.ReturnStamina() + " / 20");
    }

    void CheckLevels()
    {
        if(GameManager.gameManager.ReturnLevels() >= 1)
        {
            LevelsButtons[1].interactable = true;
            if(GameManager.gameManager.ReturnLevels() >= 2)
            {
                LevelsButtons[2].interactable = true;
                if (GameManager.gameManager.ReturnLevels() >= 3)
                {
                    LevelsButtons[3].interactable = true;
                    if (GameManager.gameManager.ReturnLevels() >= 4)
                    {
                        LevelsButtons[4].interactable = true;
                        if (GameManager.gameManager.ReturnLevels() >= 5)
                        {
                            LevelsButtons[5].interactable = true;
                            if (GameManager.gameManager.ReturnLevels() >= 6)
                            {
                                LevelsButtons[6].interactable = true;
                                if (GameManager.gameManager.ReturnLevels() >= 7)
                                {
                                    LevelsButtons[7].interactable = true;
                                    if (GameManager.gameManager.ReturnLevels() >= 8)
                                    {
                                        LevelsButtons[8].interactable = true;
                                        if (GameManager.gameManager.ReturnLevels() >= 9)
                                        {
                                            LevelsButtons[9].interactable = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
