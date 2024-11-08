using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUANITO : MonoBehaviour
{
    [Header("Variables Mov.Carriles")]
    public float disCarriles = 2.0f;
    public int carrilInicio = 0;
    public int maxCarriles = 2;
    public float movY = 5f;

    [Space(30)]
    [Header("Variables Mov.Horizontal")]
    public float movX = 5f;

    [Space(30)]
    [Header("Variables Salto")]
    public float alturaSalto = 1.5f;
    public float duracionSalto = 0.75f;

    private bool isMovingVertically = false;
    private bool isJumping = false;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private Vector3 jumpStartPosition;
    private float jumpStartTime;

    private Animator animator;

    void Start()
    {
        carrilInicio = 0;
        initialPosition = transform.position;
        targetPosition = initialPosition;

       // carrilInicio = 0;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position += Vector3.right * movX * Time.deltaTime;

        if (isJumping)
        {
            HandleJump();
        }
        else if (!isMovingVertically)
        {
            HandleInput();
        }
        else
        {
            MoveToTargetLane();
        }

    }

    public void HandleJump()
    {
        float elapsedTime = Time.time - jumpStartTime;
        float progress = elapsedTime / duracionSalto;

        if (progress < 1f)
        {
            float height = Mathf.Sin(Mathf.PI * progress) * alturaSalto;
            transform.position = new Vector3(transform.position.x, jumpStartPosition.y + height, transform.position.z);
        }
        else
        {
            // Finalizar el salto
            isJumping = false;
            // Asegurarse de que el personaje esté en la altura inicial del carril tras el salto
            transform.position = new Vector3(transform.position.x, jumpStartPosition.y, transform.position.z);
            animator.SetBool("enSuelo", false);
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartJump();
        }
        else if (Input.GetKeyDown(KeyCode.S) && carrilInicio < maxCarriles - 1)
        {
            ChangeLane(1);
        }
        else if (Input.GetKeyDown(KeyCode.W) && carrilInicio > 0)
        {
            ChangeLane(-1);
        }
    }

    public void ChangeLane(int direction)
    {
        carrilInicio += direction;
        MoveToLane();
    }

    public void StartJump()
    {
        if (!isJumping)
        {
            jumpStartPosition = transform.position;
            jumpStartTime = Time.time;
            isJumping = true;
            animator.SetBool("enSuelo", true);
        }
    }

    void MoveToLane()
    {
        targetPosition = new Vector3(transform.position.x, initialPosition.y - (carrilInicio * disCarriles), transform.position.z);
        isMovingVertically = true;

        // Cambiar el layer basado en el carril actual
        switch (carrilInicio)
        {
            case 0:
                gameObject.layer = LayerMask.NameToLayer("Carril 1");
                gameObject.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Carril 1");
                break;
            case 1:
                gameObject.layer = LayerMask.NameToLayer("Carril 2");
                gameObject.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Carril 2");
                break;
            case 2:
                gameObject.layer = LayerMask.NameToLayer("Carril 3");
                gameObject.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Carril 3");

                break;
            case 3:
                gameObject.layer = LayerMask.NameToLayer("Carril 4");
                gameObject.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Carril 4");

                break;
            case 4:
                gameObject.layer = LayerMask.NameToLayer("Carril 5");
                gameObject.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Carril 5");

                break;
            default:
                // Capa por defecto si ocurre algo inesperado
                gameObject.layer = LayerMask.NameToLayer("Carril 1");
                gameObject.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Carril 1");

                break;
        }
    }

    void MoveToTargetLane()
    {
        float newYPosition = Mathf.MoveTowards(transform.position.y, targetPosition.y, movY * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);

        if (Mathf.Approximately(transform.position.y, targetPosition.y))
        {
            isMovingVertically = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo_NoJump"))
        {

            GameManager.Instance.PerderGame();
            //Sonidos SFX Stage 1
            if (collision.gameObject.name == "auto")
            {
                AudioManager.Instance.PlaySfx("auto");
            }

            if (collision.gameObject.name == "valla")
            {
                AudioManager.Instance.PlaySfx("valla");
            }

            //Sonidos SFX Stage 2
            if (collision.gameObject.name == "arena")
            {
                AudioManager.Instance.PlaySfx("arena");
            }
            if (collision.gameObject.name == "camion")
            {
                AudioManager.Instance.PlaySfx("camionImpacto");
            }
            if (collision.gameObject.name == "vigas")
            {
                AudioManager.Instance.PlaySfx("vigas");
            }
            if (collision.gameObject.name == "alcantarilla")
            {
                AudioManager.Instance.PlaySfx("charco");
                AudioManager.Instance.PlaySfx("casco");
            }

            //Sonidos SFX Stage 3

            if (collision.gameObject.name == "banca")
            {
                AudioManager.Instance.PlaySfx("bancoParque");
            }
            if (collision.gameObject.name == "camionHelado")
            {
                AudioManager.Instance.PlaySfx("auto");
                AudioManager.Instance.PlaySfx("caca");
            }
            if (collision.gameObject.name == "camionDonas")
            {
                AudioManager.Instance.PlaySfx("auto");
                AudioManager.Instance.PlaySfx("caca");
            }
            if (collision.gameObject.name == "tacho")
            {
                AudioManager.Instance.PlaySfx("casco");
            }
            if (collision.gameObject.name == "abuela")
            {
                Debug.Log("Agregar sonido de abuela");
                //AudioManager.Instance.PlaySfx("");
            }
            if (collision.gameObject.name == "abuela2")
            {
                Debug.Log("Agregar sonido de abuela 2");
                //AudioManager.Instance.PlaySfx("");
            }
            if (collision.gameObject.name == "abuela3")
            {
                Debug.Log("Agregar sonido de abuela 3");
                //AudioManager.Instance.PlaySfx("");
            }
            

        }


    }

    // --- Métodos Públicos para los Botones en Canva ---

    // Boton para bajar de carril
    public void OnDownButtonPressed()
    {
        if (carrilInicio < maxCarriles - 1)
        {
            ChangeLane(1); // Cambiar a un carril inferior.
        }
    }

    // Boton para subir de carril
    public void OnUpButtonPressed()
    {
        if (carrilInicio > 0)
        {
            ChangeLane(-1); // Cambiar a un carril superior.
        }
    }

    // Boton para el Salto
    public void OnJumpButtonPressed()
    {
        Debug.Log("Boton de salto presionado");
        StartJump(); // Iniciar el salto.
    }
}