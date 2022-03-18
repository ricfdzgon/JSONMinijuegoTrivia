using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ComprobacionBotones : MonoBehaviour
{
    public Trivia triviaGame;

    void Start()
    {

    }

    void Update()
    {

    }

    public bool Comprobar(TextMeshPro textoBoton, int numeroPregunta)
    {
        return textoBoton.text == triviaGame.getJSON().results[numeroPregunta].correct_answer;
    }
}
