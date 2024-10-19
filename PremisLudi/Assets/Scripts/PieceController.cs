using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private enum SpriteNames
    {
        AGRESSIVE,
        LITTLE,
        TRAINED,
        BIG,
        SUPERHERO
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void ChangeSprite(String wordTag)
    {
        switch (wordTag)
        {
            case "Agressive":
                spriteRenderer.sprite = sprites[(int)SpriteNames.AGRESSIVE];
                break;

            case "Little":
                spriteRenderer.sprite = sprites[(int)SpriteNames.LITTLE];
                break;

            case "Trained":
                spriteRenderer.sprite = sprites[(int)SpriteNames.TRAINED];
                break;

            case "Big":
                spriteRenderer.sprite = sprites[(int)SpriteNames.BIG];
                break;

            case "Superhero":
                spriteRenderer.sprite = sprites[(int)SpriteNames.SUPERHERO];
                break;
        }
    }
}
