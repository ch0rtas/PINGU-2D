using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    public GameObject stompBox;
    Mover mover;
    Colisiones colisiones;
    Animaciones animaciones;
    Rigidbody2D rb2D;
    ItemType itemType;
    
    //public GameObject headBox;
    bool isDead;

    public HUD hud;
    private void Awake()
    {
        mover = GetComponent<Mover>();
        colisiones = GetComponent<Colisiones>();
        animaciones = GetComponent<Animaciones>();
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(rb2D.velocity.y < 0 && !isDead)
        {
            stompBox.SetActive(true);
        }
        else
        {
            stompBox.SetActive(false);
        }
        /*
        if(rb2D.velocity.y > 0 && !isDead)
        {
            headBox.SetActive(true);
        }
        else
        {
            headBox.SetActive(false);
        }
        */
    }
    public void Hit()
    {
        //Debug.Log("HIT");
        Dead();
    }
    public void Dead()
    {
        if(!isDead)
        {
            //AudioManager.Instance.PlayDie();
            isDead = true;
            colisiones.Dead();
            mover.Dead();
            animaciones.Dead();
        }
    }
    public void CatchItem(ItemType type)
    {
        switch(type)
        {
            case ItemType.Life:
                //Life
                break;
            case ItemType.Coin:
                //AudioManager.Instance.PlayCoin();
                Debug.Log("Coin");
                hud.AddCoins();
                //LevelManager.Instance.AddCoins();
                break;
        }
    }
    public void Goal()
    {
        //AudioManager.Instance.PlayGoal();
        mover.DownFlagPole();
    }
}
