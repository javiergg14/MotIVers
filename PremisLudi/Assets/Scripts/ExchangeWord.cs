using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeWord : MonoBehaviour
{
    public WordController currentWord;

    [SerializeField]
    private PieceController piece;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<WordController>())
        {
            other.GetComponent<WordController>().SetExchangeWord(this);
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<WordController>())
        {
            other.GetComponent<WordController>().SetExchangeWord(null);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("entra");
        if (currentWord != null)
        {
            switch (currentWord.tag)
            {
                case "Agressive":
                    //Debug.Log("Tag: Agressive");
                    break;

                default:
                    Debug.Log("Palabra no reconocida.");
                    break;
            }

        }
    }

    public WordController GetCurrentWord()
    {
        return currentWord;
    }

    public void SetCurrentWord(WordController currentWord)
    {
        this.currentWord = currentWord;
    }
}
