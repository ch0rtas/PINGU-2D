using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {Life, Coin}
public class Item : MonoBehaviour
{
    
    public ItemType type;
    bool isCatched;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isCatched)
        {
            if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                isCatched = true;
                collision.gameObject.GetComponent<Penguin>().CatchItem(type);
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.gameObject.GetComponent<Penguin>().CatchItem(type);
            Destroy(gameObject);
        }
        */
        if(!isCatched)
        {
            Penguin penguin = collision.gameObject.GetComponent<Penguin>();
            if(penguin != null)
            {
                isCatched = true;
                penguin.CatchItem(type);
                Destroy(gameObject);
            }
        }
    }
}
