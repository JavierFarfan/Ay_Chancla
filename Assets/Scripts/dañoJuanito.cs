using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dañoJuanito : MonoBehaviour
{
    public int blinkCount = 3;       // Número de parpadeos
    public float blinkDuration = 0.1f; // Duración de cada parpadeo

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Obtenemos el SpriteRenderer del objeto
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("No se encontró SpriteRenderer en el objeto.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstaculo_Jump"))
        {
            Debug.Log("Colisión con Obstaculo_Jump detectada (Trigger)");
            StartCoroutine(BlinkEffect());
        }
    }

    private IEnumerator BlinkEffect()
    {
        for (int i = 0; i < blinkCount; i++)
        {
            // Cambia el alpha a 0 para hacer que el objeto "desaparezca"
            SetAlpha(0);
            yield return new WaitForSeconds(blinkDuration);

            // Cambia el alpha a 1 para hacer que el objeto "reaparezca"
            SetAlpha(1);
            yield return new WaitForSeconds(blinkDuration);
        }
    }

    private void SetAlpha(float alpha)
    {
        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
        }
    }
}
