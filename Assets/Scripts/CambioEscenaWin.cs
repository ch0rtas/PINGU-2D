using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioEscenaWin : MonoBehaviour
{
    public StartMenu startMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            startMenu.CambiarEscena("Fin");
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            startMenu.CambiarEscena("Fin");
        }
    }
}
