using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private bool isPlayerInRange = false;
    private Vector2 gap = new(0, 0.5f);
    private bool isHeld = false;

    private ExchangeWord exchangeWord;

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Space) || isHeld && Input.GetKeyDown(KeyCode.Space))
        {
            InteractWithWord();
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Obtiene el primer toque

            // Verifica si el toque comenzó
            if (touch.phase == TouchPhase.Began)
            {
                // Comprueba si el jugador está en rango o si está sosteniendo el objeto
                if (isPlayerInRange || isHeld)
                {
                    InteractWithWord();
                }
            }
        }
    }

    private void InteractWithWord()
    {
        if (isHeld)
        {

            if (exchangeWord != null)
            {
                transform.position = exchangeWord.transform.position;
                transform.SetParent(exchangeWord.transform);
                exchangeWord.SetCurrentWord(this);
            } else
            {
                transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
                transform.SetParent(null);
            }
            isHeld = false;

            GetComponent<WordLevitation>().SetHeld(false);
        }
        else
        {
            transform.position = (Vector2)player.transform.position + gap;
            transform.SetParent(player.transform);
            isHeld = true;

            GetComponent<WordLevitation>().SetHeld(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            isPlayerInRange = false;
        }
    }

    public void SetExchangeWord(ExchangeWord exchangeWord)
    {
        this.exchangeWord = exchangeWord;
    }
}
