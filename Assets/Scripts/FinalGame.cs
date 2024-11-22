using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGame : MonoBehaviour
{

    public int nivelActual;
    public int stageActual;// Solo cuenta el ultimo nivel de cada stage
    public bool desbloqueaSiguienteStage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ControladorNiveles.Instance.IncreaseLevel(nivelActual + 1);
            if (desbloqueaSiguienteStage) 
            {
                ControladorNiveles.Instance.IncreaseStage(stageActual + 1);
            }
            GameManager.Instance.GanarGame();
        }
    }

}