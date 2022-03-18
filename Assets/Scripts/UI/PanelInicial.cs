using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelInicial : MonoBehaviour
{
    public GameObject panel;
    public void BotonJugarOnClick()
    {
        panel.SetActive(false);
    }
}
