using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBici : MonoBehaviour
{

    public float velX;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * velX * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstaculo_NoJump")
        {
            Destroy(collision.gameObject);
        }
    }

    
}
