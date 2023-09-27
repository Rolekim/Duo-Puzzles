using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    protected SpriteRenderer activeSprite;
    [SerializeField]
    protected Sprite spriteRed = null;
    [SerializeField]
    protected Sprite spriteBlue = null;

    void Awake()
    {
        activeSprite = GetComponent<SpriteRenderer>();
    }

    public virtual void ChangeActiveSprite()
    {
        if (activeSprite.sprite == spriteRed) activeSprite.sprite = spriteBlue;

        else if (activeSprite.sprite == spriteBlue) activeSprite.sprite = spriteRed;

    }
}
