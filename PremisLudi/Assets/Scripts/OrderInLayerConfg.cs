using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeOrderLayer : MonoBehaviour
{
    private SpriteRenderer treeSpriteRenderer; 
    public float offsetY = 0.5f; 

    void Start()
    {
        treeSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdateTreeOrder();
    }

    void UpdateTreeOrder()
    {
        float treeBottomY = treeSpriteRenderer.bounds.min.y;

        GameObject player = GameObject.FindWithTag("Player");

        float playerY = player.transform.position.y;

        //Debug.Log($"Posición del jugador: {playerY}, Parte inferior del árbol: {treeBottomY}");

        if (playerY > treeBottomY + offsetY)
        {
            treeSpriteRenderer.sortingOrder = 5;
        }
        else
        {
            treeSpriteRenderer.sortingOrder = -5;
        }
    }

}
