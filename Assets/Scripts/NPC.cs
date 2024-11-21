using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    Animator anim;
    public string sonido;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    private void OnBecameInvisible()
    {
        anim.enabled = false;

        Debug.Log("no me estoy animando"); 
    }

    private void OnBecameVisible()
    {
        anim.enabled = true;
        AudioManager.Instance.PlaySfx(sonido);
        Debug.Log("me anime");    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
