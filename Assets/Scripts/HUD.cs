using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HUD : MonoBehaviour
{

    public GameObject[] vidas;

    public void DesactivarVida(int indice)
    {
        vidas[indice].SetActive(false);
    }

    //Se agrega esta funcion para en futuro sumar vidas.
    public void ActivarVida(int indice)
    {
        vidas[indice].SetActive(true);
    }
}
