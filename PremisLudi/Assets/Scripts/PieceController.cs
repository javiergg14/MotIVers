using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour
{
    [SerializeField]
    private readonly ExchangeWord exchangeWord;

    void Update()
    {
        if (exchangeWord == null)
        {

        }
        switch (exchangeWord.GetCurrentWord().tag)
        {
            case "Agressive":
                Debug.Log("Este es un mensaje de información.");
                break;

            default:
                Debug.Log("Palabra no reconocida.");
                break;
        }
    }
}
