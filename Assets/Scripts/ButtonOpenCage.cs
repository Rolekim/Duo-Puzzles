using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOpenCage : LevelButton
{
    [SerializeField]
    GameObject cage = null;
    [SerializeField]
    GameObject tutorialText1 = null;
    [SerializeField]
    GameObject tutorialText2 = null;

    public override void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            base.OnTriggerStay2D(col);
            cage.SetActive(false);
            tutorialText1.SetActive(false);
            tutorialText2.SetActive(true);

            ChangeController.changeController.ChangeCanSwitch(true);

        }

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            SoundManager.soundManager.PlayButton();

        }
    }
}
