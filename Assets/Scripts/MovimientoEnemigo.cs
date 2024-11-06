using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour

{
    //Propiedades
    public float velX;
   
    //public GameObject explosion;NO VA
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velX * Time.deltaTime, 0, 0);

        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);

    }

    /* private void OnCollisionEnter2D(Collision2D collision) NO VA PARA ESTE JUEGO A NO SER QUE HAGA FALTAA !!!!!!!!!!!!!!!!!!!!!!!!!
     {
         if (collision.gameObject.tag == "Player")
         {
             Destroy(gameObject);
             GameObject explo = Instantiate(explosion);
             //Donde aparece la explosion
             explo.transform.position = new Vector3(this.gameObject.transform.position.x,
                 this.gameObject.transform.position.y, this.gameObject.transform.position.z);
         }
     }*/
}
