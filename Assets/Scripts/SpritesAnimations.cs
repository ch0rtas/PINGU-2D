using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesAnimations : MonoBehaviour
{
    public Sprite[] sprites;
    public float frameTime = 0.1f;

    //float timer = 0f;
    int animationFrame = 0;

    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Animation());
    }

    // Update is called once per frame
    /*
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= frameTime)
        {
            //Cambiamos de sprites
            //Sumamos 1 a nuestro indice
            animationFrame++;
            if(animationFrame >= sprites.Length)
            {
                animationFrame = 0;
            }

            spriteRenderer.sprite = sprites[animationFrame];
            timer = 0;
        }
    }
    */

    IEnumerator Animation()
    {
        while(true)
        {
            spriteRenderer.sprite = sprites[animationFrame];
            animationFrame++;
            if(animationFrame >= sprites.Length)
            {
                animationFrame = 0;
            }
            yield return new WaitForSeconds(frameTime);
        }
    }
}
