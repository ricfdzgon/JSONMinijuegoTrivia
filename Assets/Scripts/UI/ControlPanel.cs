using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    public static ControlPanel instance;

    void Awake()
    {
        instance = this;
    }
    public GameObject panelWin;
    public GameObject panelGameOver;

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
        panelGameOver.SetActive(false);
        Invoke("ExitGame", 3f);
    }

    public void HabilitarGameOver()
    {
        panelWin.SetActive(false);
        panelGameOver.SetActive(true);
        Invoke("ExitGame", 3f);
    }
}
