using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    SpriteRenderer sprite;
    Animator anim;
    Rigidbody2D rb;
    [SerializeField]
    float fallMultiplier = 2.5f;
    [SerializeField]
    float lowJumpMultiplier = 2f;

    void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        if(rb.velocity.y > 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }


    public SpriteRenderer ReturnSprite()
    {
        return sprite;
    }

    public void ChangeToIddle()
    {
        if(anim != null)
        {
            anim.SetTrigger("Iddle");
            anim.ResetTrigger("Run");
        }


    }

    public void ChangeToFreeze()
    {
        if(anim != null)
        {
            anim.SetTrigger("Freeze");
            anim.ResetTrigger("Iddle");
        }

    }

    public void ChangeToRun()
    {
        anim.SetTrigger("Run");
        anim.ResetTrigger("Iddle");
    }
}
