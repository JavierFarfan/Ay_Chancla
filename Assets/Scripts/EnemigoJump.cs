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
            if (gameObject.name == "charco") {
                AudioManager.Instance.PlaySfx("charco");
            }
            if (gameObject.name == "popo")
            {
                AudioManager.Instance.PlaySfx("caca");
            }
            
          
        }

        
    }

}
