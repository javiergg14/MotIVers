using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private GameObject PassTutorial;    

    [SerializeField]
    private OvejaTransform sheep;

    [SerializeField]
    private ExchangeWord exchangeWordCec;

    [SerializeField]
    private WordController word;


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

        if (word != null)
        {
            ChangeSprite(word.tag);
        }
        
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
        // Verificar si spriteRenderer y sprites están correctamente inicializados
        if (spriteRenderer == null || sprites == null || sprites.Length <= (int)SpriteNames.DEFAULT)
        {
            Debug.LogWarning("SpriteRenderer o sprites no están configurados correctamente.");
            return;
        }

        // Verificar si el tag es válido antes de proceder
        if (this.tag != "Cec" || (this.tag == "Cec" && SharedData.duendeTrained))
        {
            switch (wordTag)
            {
                case "Agressive":
                    // Verificar si el índice es válido antes de asignar el sprite
                    if (sprites.Length > (int)SpriteNames.AGRESSIVE)
                    {
                        spriteRenderer.sprite = sprites[(int)SpriteNames.AGRESSIVE];
                    }

                    if (this.tag == "Duende" && playerTransforms != null)
                    {
                        playerTransforms.Transform(0);
                    }

                    if (this.tag == "Gos" && entradaDuende != null && entradaDuende.GetComponent<Collider2D>() != null && sheep != null)
                    {
                        entradaDuende.GetComponent<Collider2D>().enabled = false;
                        sheep.TransformSheep();
                    }
                    break;

                case "Little":
                    if (sprites.Length > (int)SpriteNames.LITTLE)
                    {
                        spriteRenderer.sprite = sprites[(int)SpriteNames.LITTLE];
                    }

                    if (this.tag == "Duende" && playerTransforms != null)
                    {
                        playerTransforms.Transform(1);
                    }

                    if (this.tag == "Tree" && PassTutorial != null && PassTutorial.GetComponent<Collider2D>() != null)
                    {
                        PassTutorial.GetComponent<Collider2D>().enabled = false;
                    }
                    break;

                case "Trained":
                    if (sprites.Length > (int)SpriteNames.TRAINED)
                    {
                        spriteRenderer.sprite = sprites[(int)SpriteNames.TRAINED];
                    }

                    if (this.tag == "Duende" && playerTransforms != null)
                    {
                        SharedData.duendeTrained = true;
                        playerTransforms.Transform(1);
                    }
                    break;

                case "Big":
                    if (sprites.Length > (int)SpriteNames.BIG)
                    {
                        spriteRenderer.sprite = sprites[(int)SpriteNames.BIG];
                    }

                    if (this.tag == "Duende" && playerTransforms != null)
                    {
                        playerTransforms.Transform(1);
                    }
                    break;

                case "Superhero":
                    if (sprites.Length > (int)SpriteNames.SUPERHERO)
                    {
                        spriteRenderer.sprite = sprites[(int)SpriteNames.SUPERHERO];
                    }

                    if (this.tag == "Duende" && playerTransforms != null)
                    {
                        playerTransforms.Transform(1);
                    }

                    if (this.tag == "Cec" && lvl != null && lvl.GetComponent<Collider2D>() != null)
                    {
                        lvl.GetComponent<Collider2D>().enabled = false;
                        lvl.GetComponent<SpriteRenderer>().enabled = false;
                    }
                    break;

                case "Default":
                    if (sprites.Length > (int)SpriteNames.DEFAULT)
                    {
                        spriteRenderer.sprite = sprites[(int)SpriteNames.DEFAULT];
                    }

                    if (this.tag == "Duende" && playerTransforms != null)
                    {
                        playerTransforms.Transform(1);
                        SharedData.duendeTrained = false;
                        if (exchangeWordCec != null && exchangeWordCec.piece != null)
                        {
                            exchangeWordCec.piece.ChangeSprite("Default");
                        }
                    }
                    break;
            }
        }
        else if (this.tag == "Cec" && !SharedData.duendeTrained)
        {
            if (sprites.Length > (int)SpriteNames.DEFAULT)
            {
                spriteRenderer.sprite = sprites[(int)SpriteNames.DEFAULT];
            }
        }
    }


}
