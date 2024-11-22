using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoJump : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.PerderVida();

            //Sonidos SFX Stage1
            if (gameObject.name == "charco") 
            {
                AudioManager.Instance.PlaySfx("charco", 1.3f);
            }
            if (gameObject.name == "popo")
            {
                AudioManager.Instance.PlaySfx("caca", 1.5f);
            }
            if (gameObject.name == "perro")
            {
                AudioManager.Instance.PlaySfx("perro ladra", 1.3f);
            }

            //Sonidos SFX Stage2
            if (gameObject.name == "cono")
            {   
                AudioManager.Instance.PlaySfx("cono", 1.5f);
            }
            if (gameObject.name == "casco")
            {
                AudioManager.Instance.PlaySfx("herramientas");
            }
            if (gameObject.name == "carretilla")
            {
                AudioManager.Instance.PlaySfx("carretilla");
            }

            //Sonidos SFX Stage3
            if (gameObject.name == "helado")
            {
                AudioManager.Instance.PlaySfx("helado", 1.5f);
            }
            if (gameObject.name == "rocas")
            {         
                AudioManager.Instance.PlaySfx("rocas", 1.5f);
            }
            if (gameObject.name == "pelota")
            {         
                AudioManager.Instance.PlaySfx("pelota", 1.2f);
            }
            if (gameObject.name == "basurero")
            {
                AudioManager.Instance.PlaySfx("cestoBasura", 1.2f);
            }
            if (gameObject.name == "perroJugueton")
            {
                AudioManager.Instance.PlaySfx("perroJugandoImpact", 1.5f);
            }

        }
    }

}
