using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saltoCarril: MonoBehaviour
{
    public float alturaSalto = 2f;       // Altura máxima del salto
    public float velocidadSalto = 2f;    // Velocidad de ascenso y descenso

    private Vector2 puntoDeInicio;       // Almacena la posición de inicio
    private bool saltando;               // Indica si el objeto está en el proceso de saltar
    private bool enElSuelo = true;       // Indica si el objeto está en el suelo

    //[Header("Animacion")]
    //private Animator animator;

    private void Start()
    {
        puntoDeInicio = transform.position; // Guarda la posición inicial del objeto
        //animator = GetComponent<Animator>();
    }

    public void iniciarSalto()
    {
        if (enElSuelo)
        {
            puntoDeInicio = transform.position; // Guarda la posición inicial del objeto
            saltando = true;         // Inicia el proceso de salto
            enElSuelo = false;       // El objeto ya no está en el suelo
        }


    }

    private void Update()
    {
        //Verifica si se presionó la tecla Espacio y si el objeto está en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && enElSuelo)
        {
            puntoDeInicio = transform.position; // Guarda la posición inicial del objeto
            saltando = true;         // Inicia el proceso de salto
            enElSuelo = false;       // El objeto ya no está en el suelo
        }

        if (saltando)
        {
            float nuevaAltura = transform.position.y + velocidadSalto * Time.deltaTime;

            // Realiza el salto verificando si la nueva altura es menor que la altura máxima del salto
            if (nuevaAltura < puntoDeInicio.y + alturaSalto)
            {
                transform.position = new Vector2(transform.position.x, nuevaAltura);
                //animator.SetBool("enSuelo", true);
            }
            else
            {
                // Alcanzamos la altura máxima del salto, invertir la dirección para descender
                velocidadSalto *= -1;
            }

            // Comprueba si hemos vuelto al punto de inicio
            if (velocidadSalto < 0 && transform.position.y <= puntoDeInicio.y)
            {
                transform.position = new Vector2(transform.position.x, puntoDeInicio.y);
                saltando = false;       // Finaliza el proceso de salto
                enElSuelo = true;      // El objeto está de nuevo en el suelo
                velocidadSalto = velocidadSalto * -1;
                //animator.SetBool("enSuelo", false);
            }
        }
    }
}
