using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField]
    Animator wallsAnimator = null;
    [SerializeField]
    Animator flashAnim = null;
    [SerializeField]
    int level = 0;
    [SerializeField]
    bool finalLevel;
    [SerializeField]
    GameObject EndLevel;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            flashAnim.SetTrigger("BigFlash");
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel()
    {
        GameManager.gameManager.IncreaseLevel(level);
        yield return new WaitForSeconds(0.4f);
        wallsAnimator.SetTrigger("CloseWalls");
        yield return new WaitForSeconds(0.6f);
        EndLevel.SetActive(true);
    }
}
