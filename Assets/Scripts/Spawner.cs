using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Propiedades p�blicas que se pueden ajustar desde el Inspector en Unity
    public List<GameObject> enemigos; // Lista de prefabs que ser�n instanciados
    public float minTime = 1f; // Tiempo m�nimo entre instancias
    public float maxTime = 5f; // Tiempo m�ximo entre instancias

    public float velX; //para que el spawner se mueva tambien 

    // M�todo Start se llama al inicio del juego o cuando el script es activado
    void Start()
    {
        // Inicia la coroutine de creaci�n de instancias
        StartCoroutine(CrearRutina());
    }

    private void Update()
    {
        transform.Translate(velX * Time.deltaTime, 0, 0);
    }


    // Coroutine para crear prefabs a intervalos aleatorios
    IEnumerator CrearRutina()
    {
        while (true)
        {
            // Espera un tiempo aleatorio entre minTime y maxTime
            float tiempoEspera = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(tiempoEspera);

            // Llama al m�todo Crear para instanciar un prefab
            Crear();
        }
    }

    // M�todo Crear se llama para instanciar un prefab aleatorio de la lista en la posici�n y rotaci�n del objeto que contiene este script
    void Crear()
    {
        if (enemigos.Count == 0)
        {
            Debug.LogWarning("No hay prefabs en la lista para instanciar.");
            return;
        }

        // Selecciona aleatoriamente un prefab de la lista
        int index = Random.Range(0, enemigos.Count);
        GameObject prefabSeleccionado = enemigos[index];

        // Crea una instancia del prefab seleccionado en la posici�n y rotaci�n del objeto actual (this.transform)
        Instantiate(prefabSeleccionado, transform.position, transform.rotation);
    }
}
