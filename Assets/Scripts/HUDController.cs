using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    private JUANITO player; // Referencia al script del jugador
    private MARIA maria;

    public Button jumpButton; // Botón en el HUD
    public Button upButton;
    public Button downButton;

    /*private void Start()
    {
        SetupButtons();
    }*/

    private void OnEnable()
    {
        SetupButtons();
    }
    public void SetupButtons()
    {
        // Busca el objeto del jugador en la escena
        player = FindObjectOfType<JUANITO>();
        maria = FindObjectOfType<MARIA>();

        if (player != null)
        {
            // Limpiar listeners previos
            jumpButton.onClick.RemoveAllListeners();
            upButton.onClick.RemoveAllListeners();
            downButton.onClick.RemoveAllListeners();
            // Asigna las funciones a los botones

            if (jumpButton != null)
            {
                jumpButton.onClick.AddListener(player.OnJumpButtonPressed);    
            }
            if (upButton != null)
            {
                upButton.onClick.AddListener(player.OnUpButtonPressed);
            }
            if (downButton != null)
            {
                downButton.onClick.AddListener(player.OnDownButtonPressed);
            }
        }
        else
        {
            Debug.LogError("No se encontró el jugador en la escena.");
        }
        if (maria != null)
        {
            Debug.Log("Se encontro a Maria ");
            if (upButton != null)
            {
                upButton.onClick.AddListener(maria.OnUpButtonPressed);
            }
            if (downButton != null)
            {
                downButton.onClick.AddListener(maria.OnDownButtonPressed);
            }
        }
        else
        {
            Debug.LogError("No se encontro a maria en la escena");
        }
    }
}
