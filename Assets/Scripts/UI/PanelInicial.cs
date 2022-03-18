using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelInicial : MonoBehaviour
{
    public GameObject panel;
    public GameObject panelWin;
    public GameObject panelGameOver;
    public void BotonJugarOnClick()
    {
        panel.SetActive(false);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void HabilitarWin()
    {
        panelWin.SetActive(true);
        panel.SetActive(false);
        panelGameOver.SetActive(false);
        Invoke("ExitGame", 3f);
    }

    public void HabilitarGameOver()
    {
        panelWin.SetActive(false);
        panel.SetActive(false);
        panelGameOver.SetActive(true);
        Invoke("ExitGame", 3f);
    }


}
