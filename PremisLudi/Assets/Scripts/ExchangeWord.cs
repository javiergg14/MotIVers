using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeWord : MonoBehaviour
{
    private WordController currentWord;

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
}
