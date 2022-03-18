using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Minigame : MonoBehaviour
{
    public TextMeshProUGUI preguntaText;
    public Trivia triviaGame;
    public TextMeshProUGUI textoBoton1;
    public TextMeshProUGUI textoBoton2;
    public TextMeshProUGUI textoBoton3;
    public TextMeshProUGUI textoBoton4;
    public GameObject botones;
    void Start()
    {
        Invoke("RellenarPregunta", 5f);
    }

    void Update()
    {

    }

    private void RellenarPregunta()
    {
        preguntaText.text = triviaGame.getJSON().results[0].question;
        botones.SetActive(true);
        RellenarBotones(0);
    }

    private void RellenarPregunta(int numeroPregunta)
    {
    }

    private void RellenarBotones(int numeroPregunta)
    {
        triviaGame.numeroPregunta = numeroPregunta;
        textoBoton1.text = triviaGame.getJSON().results[numeroPregunta].correct_answer;
        textoBoton2.text = triviaGame.getJSON().results[numeroPregunta].incorrect_answers[0];
        textoBoton3.text = triviaGame.getJSON().results[numeroPregunta].incorrect_answers[1];
        textoBoton4.text = triviaGame.getJSON().results[numeroPregunta].incorrect_answers[2];
    }
}
