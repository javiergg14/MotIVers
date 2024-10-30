using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [SerializeField]
    private PlayerTransforms playerTransforms;

    private enum SpriteNames
    {
        AGRESSIVE,
        LITTLE,
        TRAINED,
        SUPERHERO,
        BIG,
        DEFAULT
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
                if(this.tag == "Duende")
                {
                    playerTransforms.Transform(0);
                }

                break;

            case "Little":
                spriteRenderer.sprite = sprites[(int)SpriteNames.LITTLE];
                if (this.tag == "Duende")
                {
                    playerTransforms.Transform(1);
                }
                break;

            case "Trained":
                spriteRenderer.sprite = sprites[(int)SpriteNames.TRAINED];
                if (this.tag == "Duende")
                {
                    playerTransforms.Transform(1);
                }
                break;

            case "Big":
                spriteRenderer.sprite = sprites[(int)SpriteNames.BIG];
                if (this.tag == "Duende")
                {
                    playerTransforms.Transform(1);
                }
                break;

            case "Superhero":
                spriteRenderer.sprite = sprites[(int)SpriteNames.SUPERHERO];
                if (this.tag == "Duende")
                {
                    playerTransforms.Transform(1);
                }
                break;
            case "Default":
                spriteRenderer.sprite = sprites[(int)SpriteNames.DEFAULT];
                if (this.tag == "Duende")
                {
                    playerTransforms.Transform(1);
                }
                break;
        }
    }
}
