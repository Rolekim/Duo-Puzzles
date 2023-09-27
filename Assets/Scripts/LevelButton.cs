using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButton : Object
{
    [SerializeField]
    protected Sprite notPressedSpriteRed = null;
    [SerializeField]
    protected Sprite notPressedSpriteBlue = null;
    [SerializeField]
    protected Sprite pressedSpriteRed = null;
    [SerializeField]
    protected Sprite pressedSpriteBlue = null;

    void Awake()
    {
        activeSprite = GetComponentInChildren<SpriteRenderer>();
    }

    public override void ChangeActiveSprite()
    {
        if (activeSprite.sprite == notPressedSpriteRed) activeSprite.sprite = notPressedSpriteBlue;

        else if (activeSprite.sprite == notPressedSpriteBlue) activeSprite.sprite = notPressedSpriteRed;

        else if (activeSprite.sprite == pressedSpriteBlue) activeSprite.sprite = pressedSpriteRed;

        else if (activeSprite.sprite == pressedSpriteRed) activeSprite.sprite = pressedSpriteBlue;

    }

    public virtual void OnTriggerStay2D(Collider2D col)
    {
        if (activeSprite.sprite == notPressedSpriteRed) activeSprite.sprite = pressedSpriteRed;
        else if (activeSprite.sprite == notPressedSpriteBlue) activeSprite.sprite = pressedSpriteBlue;

    }

}
