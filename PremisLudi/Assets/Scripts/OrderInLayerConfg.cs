using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeOrderLayer : MonoBehaviour
{
    private SpriteRenderer treeSpriteRenderer;
    public float offsetY = 0.5f;
    public float detectionRange = 5f; // Rango en el que el árbol reacciona al jugador

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
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null) return; // Asegúrate de que el jugador existe

        float playerY = player.transform.position.y;
        float treeBottomY = treeSpriteRenderer.bounds.min.y;

        // Calcula la distancia entre el jugador y el árbol
        float distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);

        // Solo actualiza el orden de capa si el jugador está dentro del rango
        if (distanceToPlayer <= detectionRange)
        {
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
}
