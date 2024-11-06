using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercarril : MonoBehaviour
{
    public Transform carrilesParent;
    public Transform[] carrilesPositions;

    public Transform carrilPositionActual;

    public int carrilActualIndex = 0; // Carriles 0, 1

    public float playerHorizontalSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        carrilesPositions = new Transform[carrilesParent.childCount];
        for (int i = 0; i < carrilesParent.childCount; i++)
        {
            carrilesPositions[i] = carrilesParent.GetChild(i);
        }
        carrilPositionActual = carrilesPositions[carrilActualIndex];
    }

    void Update()
    {
        // Mover hacia arriba con la tecla W
        if (Input.GetKey(KeyCode.W))
        {
            MoverArriba();
        }

        // Mover hacia abajo con la tecla S
        if (Input.GetKey(KeyCode.S))
        {
            MoverAbajo();
        }

        transform.position = Vector3.MoveTowards(transform.position, carrilPositionActual.position, playerHorizontalSpeed * Time.deltaTime);
    }

    // Función para mover hacia arriba
    public void MoverArriba()
    {
        saltoYRegreso salto = GetComponent<saltoYRegreso>();

        if (!salto.saltando && carrilActualIndex > 0)
        {
            carrilActualIndex--;
        }

        carrilPositionActual = carrilesPositions[carrilActualIndex];
    }

    // Función para mover hacia abajo
    public void MoverAbajo()
    {
        saltoYRegreso salto = GetComponent<saltoYRegreso>();

        if (!salto.saltando && carrilActualIndex < carrilesPositions.Length - 1)
        {
            carrilActualIndex++;
        }

        carrilPositionActual = carrilesPositions[carrilActualIndex];
    }

    // Update is called once per frame
   /* void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, carrilPositionActual.position, playerHorizontalSpeed * Time.deltaTime);
    }*/
}

