using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    float jumpForce = 5f;

    bool buttonPressed = false;

    public void Jump()
    {
        if (FindObjectOfType<ChangeController>().canMove)
        {
            if (ChangeController.changeController.isGrounded(ChangeController.changeController.ReturnCharacterSelected()))
            {
                if (ChangeController.changeController.canDoubleJump)
                {
                    ChangeController.changeController.canJump = true;
                }
                SoundManager.soundManager.PlayJump();
                ChangeController.changeController.ReturnCharacterSelected().GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            else if (ChangeController.changeController.canJump)
            {
                ChangeController.changeController.canJump = false;
                SoundManager.soundManager.PlayJump();
                ChangeController.changeController.ReturnCharacterSelected().GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
        Jump();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }
}
