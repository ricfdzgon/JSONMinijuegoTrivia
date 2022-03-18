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
    public PanelInicial panelInicial;

    private int numPregunta = 0;
    private int numeroPreguntas;
    void Start()
    {
        Invoke("RellenarPregunta", 2f);
        panelInicial = new PanelInicial();
    }


    private void RellenarPregunta()
    {
        preguntaText.text = triviaGame.getJSON().results[numPregunta].question;
        numeroPreguntas = triviaGame.getJSON().results.Count;
        botones.SetActive(true);
        RellenarBotones(numPregunta);
    }

    private void RellenarPregunta(int numeroPregunta)
    {
        preguntaText.text = triviaGame.getJSON().results[numPregunta].question;
        numeroPreguntas = triviaGame.getJSON().results.Count;
        botones.SetActive(true);
        RellenarBotones(numeroPregunta);
    }

    private void RellenarBotones(int numeroPregunta)
    {
        numPregunta = numeroPregunta;
        int random = Random.Range(0, 4);

        switch (random)
        {
            case 0:
                textoBoton1.text = triviaGame.getJSON().results[numeroPregunta].correct_answer;
                textoBoton2.text = triviaGame.getJSON().results[numeroPregunta].incorrect_answers[0];
                textoBoton3.text = triviaGame.getJSON().results[numeroPregunta].incorrect_answers[1];
                textoBoton4.text = triviaGame.getJSON().results[numeroPregunta].incorrect_answers[2];
                break;
            case 1:
                textoBoton2.text = triviaGame.getJSON().results[numeroPregunta].correct_answer;
                textoBoton1.text = triviaGame.getJSON().results[numeroPregunta].incorrect_answers[0];
                textoBoton3.text = triviaGame.getJSON().results[numeroPregunta].incorrect_answers[1];
                textoBoton4.text = triviaGame.getJSON().results[numeroPregunta].incorrect_answers[2];
                break;
            case 2:
                textoBoton3.text = triviaGame.getJSON().results[numeroPregunta].correct_answer;
                textoBoton1.text = triviaGame.getJSON().results[numeroPregunta].incorrect_answers[0];
                textoBoton2.text = triviaGame.getJSON().results[numeroPregunta].incorrect_answers[1];
                textoBoton4.text = triviaGame.getJSON().results[numeroPregunta].incorrect_answers[2];
                break;
            case 3:
                textoBoton4.text = triviaGame.getJSON().results[numeroPregunta].correct_answer;
                textoBoton1.text = triviaGame.getJSON().results[numeroPregunta].incorrect_answers[0];
                textoBoton2.text = triviaGame.getJSON().results[numeroPregunta].incorrect_answers[1];
                textoBoton3.text = triviaGame.getJSON().results[numeroPregunta].incorrect_answers[2];
                break;
        }
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
        if (numPregunta < numeroPreguntas - 1)
        {
            numPregunta++;
            RellenarPregunta(numPregunta);
            RellenarBotones(numPregunta);
        }
        else
        {
            panelInicial.HabilitarWin();
        }
    }

    private void Incorrecto()
    {
        panelInicial.HabilitarGameOver();
    }

}
