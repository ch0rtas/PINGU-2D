using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radish : MonoBehaviour
{
    public bool isBreackable;
    public GameObject brickPiecePrefab;

    public int numCoins;
    public GameObject coinBlockPrefab;

    bool bouncing;

    public Sprite emptyBlock;
    bool isEmpty;

    public HUD hud;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("HeadPenguin"))
        {
            if(isBreackable)
            {
                Break();
            }
            else if(!isEmpty)
            {
                if(numCoins > 0)
                {
                    if(!bouncing)
                    {
                        Instantiate(coinBlockPrefab, transform.position, Quaternion.identity);
                        numCoins--;
                        hud.AddCoins();
                        //AudioManager.Instance.PlayCoin();
                        Bounce();
                        if(numCoins <= 0)
                        {
                            isEmpty = true;
                            GetComponent<SpriteRenderer>().sprite = emptyBlock;
                        }
                    }
                }
                
            }
        }
    }
    void Bounce()
    {
        if(!bouncing)
        {
            //AudioManager.Instance.PlayPunch();
            StartCoroutine(BounceAnimation());
        }
    }

    IEnumerator BounceAnimation()
    {
        bouncing = true;
        float time = 0;
        float duration = 0.1f;

        Vector2 startPosition = transform.position;
        Vector2 targetPosition = (Vector2)transform.position + Vector2.up * 0.25f;

        while(time < duration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        time = 0;
        while(time < duration)
        {
            transform.position = Vector2.Lerp(targetPosition, startPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = startPosition;
        bouncing = false;
        if(isEmpty)
        {
            GetComponent<SpriteRenderer>().sprite = emptyBlock;
        }
    }
    void Break()
    {
        //AudioManager.Instance.PlayBreak();
        GameObject brickPiece;

        brickPiece = Instantiate(brickPiecePrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        brickPiece.GetComponent<Rigidbody2D>().velocity = new Vector2(6f, 12f);

        brickPiece = Instantiate(brickPiecePrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
        brickPiece.GetComponent<Rigidbody2D>().velocity = new Vector2(-6f, 12f);

        brickPiece = Instantiate(brickPiecePrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, -90)));
        brickPiece.GetComponent<Rigidbody2D>().velocity = new Vector2(6f, 8f);

        brickPiece = Instantiate(brickPiecePrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
        brickPiece.GetComponent<Rigidbody2D>().velocity = new Vector2(-6f, 8f);

        Destroy(gameObject);
    }
}
