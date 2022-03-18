using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{
    public TextMeshProUGUI preguntaText;
    public Trivia triviaGame;
    public TextMeshProUGUI textoBoton1;
    public TextMeshProUGUI textoBoton2;
    public TextMeshProUGUI textoBoton3;
    public TextMeshProUGUI textoBoton4;
    public GameObject botones;

    private int numPregunta;
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
        numPregunta = numeroPregunta;
        textoBoton1.text = triviaGame.getJSON().results[numeroPregunta].correct_answer;
        textoBoton2.text = triviaGame.getJSON().results[numeroPregunta].incorrect_answers[0];
        textoBoton3.text = triviaGame.getJSON().results[numeroPregunta].incorrect_answers[1];
        textoBoton4.text = triviaGame.getJSON().results[numeroPregunta].incorrect_answers[2];
    }

    public void ComprobarBoton(GameObject textoBoton)
    {
        string respuesta = textoBoton.GetComponentInChildren<TextMeshProUGUI>().text;
        if (respuesta == triviaGame.getJSON().results[numPregunta].correct_answer)
        {
            Correcto();
        }
        else
        {
            Incorrecto();
        }

    }

    private void Correcto()
    {
        Debug.Log("Respuesta CORRECTA");
    }

    private void Incorrecto()
    {
        Debug.Log("Respuesta INCORRECTA");
    }
}
