using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransforms : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite[] sprites;

    public ExchangeWord exchangeWord;

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private GameObject font;

    public enum SpriteNames
    {
        FROG,
        HUMAN 
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Transform(int type)
    {
        if (type == 0)
        {
            this.GetComponent<Animator>().enabled = false;
            spriteRenderer.sprite = sprites[(int)SpriteNames.FROG];
            font.GetComponent<Collider2D>().enabled = false;

        }
        else if (type == 1) {
            this.GetComponent<Animator>().enabled = true;
            spriteRenderer.sprite = sprites[(int)SpriteNames.HUMAN];
            font.GetComponent<Collider2D>().enabled = true;
        }
        
    }
}
