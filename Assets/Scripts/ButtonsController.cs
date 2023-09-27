using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public enum ButtonType {RIGHT, LEFT, JUMP};
public class ButtonsController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    ButtonType buttonType = ButtonType.LEFT;
    [SerializeField]
    float speed = 10;

    ChangeController changeController;
    bool buttonPressed = false;

    void Awake()
    {
        changeController = FindObjectOfType<ChangeController>();
    }
    void Update()
    {
        if (buttonPressed) IdentifyButton(); 
    }

    void IdentifyButton()
    {
        if (FindObjectOfType<ChangeController>().canMove)
        {
            switch (buttonType)
            {
                case ButtonType.LEFT:
                    changeController.ReturnCharacterSelected().transform.position += Vector3.left * speed * Time.deltaTime;
                    changeController.ReturnCharacter().ChangeToRun();
                    if (!changeController.ReturnCharacter().ReturnSprite().flipX)
                        changeController.ReturnCharacter().ReturnSprite().flipX = true;
                    break;
                case ButtonType.RIGHT:
                    changeController.ReturnCharacterSelected().transform.position += Vector3.right * speed * Time.deltaTime;
                    changeController.ReturnCharacter().ChangeToRun();
                    if (changeController.ReturnCharacter().ReturnSprite().flipX)
                        changeController.ReturnCharacter().ReturnSprite().flipX = false;
                    break;
                case ButtonType.JUMP:

                    break;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
        changeController.ReturnCharacter().ChangeToIddle();
    }

}
