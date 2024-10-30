using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerTransforms;

public class OvejaTransform : MonoBehaviour 
{

    public Sprite sprite;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TransformSheep()
    {
        spriteRenderer.sprite = sprite;
    }
}
