using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioEscenaKill : MonoBehaviour
{
    public StartMenu startMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            startMenu.CambiarEscena("RestartMenu");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            startMenu.CambiarEscena("RestartMenu");
        }
    }
}
