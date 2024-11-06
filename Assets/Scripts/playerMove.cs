using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public int velx;
    //public float salto;
    public Rigidbody2D rbd;
    //public float velocidad = 2.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            rbd.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
        }*/

        rbd.velocity = new Vector2(velx, rbd.velocity.y);

        //float movimientoY = Input.GetAxis("Vertical"); // Obtener la entrada vertical (eje Y).

        // Calcular la nueva posición del objeto solo en el eje Y.
        // Vector3 nuevaPosicion = transform.position + new Vector3(0f, movimientoY * velocidad * Time.deltaTime, 0f);

        // Asignar la nueva posición al objeto.
        //transform.position = nuevaPosicion;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo_NoJump"))
        {
            GameManager.Instance.PerderGame();
            if (collision.gameObject.name == "valla")
            {
                AudioManager.Instance.PlaySfx("valla");
            }
            if (collision.gameObject.name == "auto")
            {
                AudioManager.Instance.PlaySfx("auto");
            }
        }


    }

}