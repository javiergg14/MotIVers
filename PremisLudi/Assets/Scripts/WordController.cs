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

    [SerializeField]
    private ExchangeWord exchangeWord;

    public RectTransform joystickArea;

    private void Start()
    {
        if (exchangeWord != null)
        {
            transform.position = exchangeWord.transform.position;
            transform.SetParent(exchangeWord.transform);
            exchangeWord.SetCurrentWord(this);
        }
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Obtiene el primer toque

            // Verifica si el toque est� dentro del �rea del joystick
            bool isTouchInsideJoystick = IsTouchInsideJoystick(touch.position);

            if (touch.phase == TouchPhase.Began && (isPlayerInRange || isHeld) && !isTouchInsideJoystick)
            {
                InteractWithWord();
            }
        }

        // Para el input del teclado, permite interactuar incluso si el joystick est� tocado
        if ((isPlayerInRange || isHeld) && Input.GetKeyDown(KeyCode.Space))
        {
            InteractWithWord();
        }
    }

    bool IsTouchInsideJoystick(Vector2 touchPosition)
    {
        // Verifica si la posici�n del toque est� dentro del �rea del joystick
        return RectTransformUtility.RectangleContainsScreenPoint(joystickArea, touchPosition);
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
            }
            else
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
            if (exchangeWord != null)
            {
                exchangeWord.SetDefault();
            }
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
