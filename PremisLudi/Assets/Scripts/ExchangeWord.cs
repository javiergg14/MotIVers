using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeWord : MonoBehaviour
{
    public WordController currentWord;

    [SerializeField]
    public PieceController piece;

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

    public WordController GetCurrentWord()
    {
        return currentWord;
    }

    public void SetCurrentWord(WordController currentWord)
    {
        piece.ChangeSprite(currentWord.tag);
        this.currentWord = currentWord;
    }

    public void SetDefault()
    {
        piece.ChangeSprite("Default");
        this.currentWord = null;
    }
}
