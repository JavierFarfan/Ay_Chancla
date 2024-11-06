using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisible : MonoBehaviour
{
    public Transform character;          // Referencia al personaje
    public LayerMask targetLayer;        // Layer deseado del personaje
    public float minX = -5f;             // Límite izquierdo del rango en X
    public float maxX = 5f;              // Límite derecho del rango en X
    public float alphaValue = 0.5f;      // Valor de alpha deseado
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // Almacena el color original
    }

    void Update()
    {
        // Verifica si el personaje está en el layer correcto y en el rango X especificado
        if (((1 << character.gameObject.layer) & targetLayer) != 0 &&
            character.position.x > minX && character.position.x < maxX)
        {
            Color newColor = originalColor;
            newColor.a = alphaValue; // Cambia solo el alpha, manteniendo el color original
            spriteRenderer.color = newColor;
        }
        else
        {
            spriteRenderer.color = originalColor; // Restaura el color original
        }
    }
}
