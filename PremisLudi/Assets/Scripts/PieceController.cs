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

    [SerializeField]
    private GameObject lvl;

    [SerializeField]
    private GameObject entradaDuende;

    [SerializeField]
    private OvejaTransform sheep;

    [SerializeField]
    private ExchangeWord exchangeWordCec;



    public static class SharedData
    {
        public static bool duendeTrained = false;
    }



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

    void Update()
    {
        if (this.tag == "Cec" && SharedData.duendeTrained && exchangeWordCec.currentWord != null)
        {
            exchangeWordCec.piece.ChangeSprite(exchangeWordCec.currentWord.tag);
        }
    }

    public void ChangeSprite(String wordTag)
    {
        if (this.tag != "Cec" || this.tag == "Cec" && SharedData.duendeTrained)
        {
            switch (wordTag)
            {
                case "Agressive":
                    Debug.Log("Agressive");
                    spriteRenderer.sprite = sprites[(int)SpriteNames.AGRESSIVE];
                    if (this.tag == "Duende")
                    {
                        playerTransforms.Transform(0);
                    }
                    if (this.tag == "Gos")
                    {
                        entradaDuende.GetComponent<Collider2D>().enabled = false;
                        sheep.TransformSheep();
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
                        SharedData.duendeTrained = true;
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
                    if (this.tag == "Cec")
                    {
                        Debug.Log("Superhero");
                        lvl.GetComponent<Collider2D>().enabled = false;
                    }
                    break;

                case "Default":
                    Debug.Log("Deafult");
                    spriteRenderer.sprite = sprites[(int)SpriteNames.DEFAULT];
                    if (this.tag == "Duende")
                    {
                        playerTransforms.Transform(1);
                        SharedData.duendeTrained = false;
                        exchangeWordCec.piece.ChangeSprite("Default");
                    }
                    break;
            }
        }
        else if (this.tag == "Cec" && !SharedData.duendeTrained)    
        {
            spriteRenderer.sprite = sprites[(int)SpriteNames.DEFAULT];
        }
        
    }
}
