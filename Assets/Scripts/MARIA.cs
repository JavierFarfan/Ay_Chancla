using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MARIA : MonoBehaviour
{
    [Header("Variables Mov.Carriles")]
    public float disCarriles = 2.0f;  // Distancia entre carriles
    public int carrilInicio = 0;      // El carril en el que comienza el personaje
    public int maxCarriles = 2;       // Número total de carriles (mínimo 2)
    public float movY = 2.5f;         // Velocidad de movimiento entre carriles

    [Header("Variables Mov.Horizontal")]
    public float movX = 2f;           // Velocidad de movimiento horizontal constante

    private bool isMovingVertically = false;
    private Vector3 initialPosition;  // Posición inicial en el mundo
    private Vector3 targetPosition;

    

    void Start()
    {
        carrilInicio = 0;
        initialPosition = transform.position;
        targetPosition = initialPosition;
        //carrilInicio = 0;

    }

    void Update()
    {
        // Movimiento horizontal constante
        transform.position += Vector3.right * movX * Time.deltaTime;

        if (!isMovingVertically)
        {
            HandleInput();  // Manejar la entrada del teclado.
        }
        else
        {
            // Movimiento suave hacia el carril objetivo solo en el eje Y
            float newYPosition = Mathf.MoveTowards(transform.position.y, targetPosition.y, movY * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);

            // Verificar si llegó al carril (en el eje Y)
            if (Mathf.Approximately(transform.position.y, targetPosition.y))
            {
                isMovingVertically = false;
            }
        }
    }

    // Manejar la entrada del teclado
    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.S) && carrilInicio < maxCarriles - 1)
        {
            MoveDown();
        }
        else if (Input.GetKeyDown(KeyCode.W) && carrilInicio > 0)
        {
            MoveUp();
        }
    }

    // Mover al carril inferior
    public void MoveDown()
    {
        if (carrilInicio < maxCarriles - 1)
        {
            carrilInicio++;
            MoveToLane();
        }
    }

    // Mover al carril superior
    public void MoveUp()
    {
        if (carrilInicio > 0)
        {
            carrilInicio--;
            MoveToLane();
        }
    }

    void MoveToLane()
    {
        targetPosition = new Vector3(transform.position.x, initialPosition.y - (carrilInicio * disCarriles), transform.position.z);
        isMovingVertically = true;

        // Cambiar el Sorting Layer para que no se solapen los obstaculos 
        switch (carrilInicio)
        {
            case 0:
                gameObject.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Carril 1");
                break;
            case 1:
                gameObject.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Carril 2");
                break;
            case 2:
                gameObject.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Carril 3");
                break;
            case 3:
                gameObject.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Carril 4");
                break;
            case 4:
                gameObject.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Carril 5");
                break;
            default:
                // Capa por defecto si ocurre algo inesperado
                gameObject.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Carril 1");

                break;
        }
    }

    // Métodos para los botones flotantes

    // Llamado cuando se presiona el botón para bajar de carril.
    public void OnDownButtonPressed()
    {
        MoveDown();
    }

    // Llamado cuando se presiona el botón para subir de carril.
    public void OnUpButtonPressed()
    {
        MoveUp();
    }


}