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
                AudioManager.Instance.PlaySfx("charco");
            }
            if (gameObject.name == "popo")
            {
                AudioManager.Instance.PlaySfx("caca");
            }
            if (gameObject.name == "perro")
            {
                AudioManager.Instance.PlaySfx("perro ladra");
            }

            //Sonidos SFX Stage2
            if (gameObject.name == "cono")
            {
                Debug.Log("Agregar sonido del cono");
                //AudioManager.Instance.PlaySfx("");
            }
            if (gameObject.name == "casco")
            {
                AudioManager.Instance.PlaySfx("casco");
            }
            if (gameObject.name == "carretilla")
            {
                AudioManager.Instance.PlaySfx("carretilla");
            }

            //Sonidos SFX Stage3
            if (gameObject.name == "helado")
            {
                AudioManager.Instance.PlaySfx("caca");
            }
            if (gameObject.name == "piedra")
            {
                Debug.Log("Agregar sonido de pierda");
                //AudioManager.Instance.PlaySfx("");
            }
            if (gameObject.name == "pelota")
            {
                Debug.Log("Agregar sonido de pelota");
                //AudioManager.Instance.PlaySfx("");
            }


        }


    }

}
