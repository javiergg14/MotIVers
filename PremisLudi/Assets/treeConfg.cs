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
        if (player == null)
        {
            Debug.LogError("No se encontró al jugador.");
            return; // Salir si no se encuentra el jugador
        }

        float playerY = player.transform.position.y;

        Debug.Log($"Posición del jugador: {playerY}, Parte inferior del árbol: {treeBottomY}");

        if (playerY > treeBottomY + offsetY)
        {
            treeSpriteRenderer.sortingOrder = 1;
        }
        else
        {
            treeSpriteRenderer.sortingOrder = -1;
        }
    }

}
