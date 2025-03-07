using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    enum Direction { Left = -1, None = 0, Right = 1};
    Direction currentDirection = Direction.None;

    public float speed;
    public float acceleration;
    public float maxVelocity;
    public float friction;
    float currentVelocity = 0;

    public float jumpForce;
    public float maxJumpingTime = 1f;
    public bool isJumping = false;
    float jumpTimer = 0;
    float defaultGravity;

    public bool isSkidding;

    public Rigidbody2D rb2D;
    Colisiones colisiones;

    public bool inputMoveEnabled = true;

    public GameObject headBox;

    Animaciones animaciones;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        colisiones = GetComponent<Colisiones>();
        animaciones = GetComponent<Animaciones>();
    }
    void Start()
    {
        defaultGravity = rb2D.gravityScale;
    }


    void Update()
    {
        headBox.SetActive(false);
        bool grounded = colisiones.Grounded();
        animaciones.Grounded(grounded);
        if(isJumping)
        {
            //AudioManager.Instance.PlayJump();
            if(rb2D.velocity.y > 0f)
            {
                headBox.SetActive(true);
                if(Input.GetKey(KeyCode.Space))
                {
                    jumpTimer += Time.deltaTime;
                }
                if(Input.GetKeyUp(KeyCode.Space))
                {
                    if(jumpTimer < maxJumpingTime)
                    {
                        rb2D.gravityScale = defaultGravity * 3f;
                    }
                }
            }
            else
            {
                rb2D.gravityScale = defaultGravity;
                if(grounded)
                {
                    isJumping = false;
                    jumpTimer = 0;
                    animaciones.Jumping(false);
                }
            }
        }


        currentDirection = Direction.None;
        if(inputMoveEnabled)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(grounded)
                {
                    Jump();
                }
            }
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                currentDirection = Direction.Left;
            }
            if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                currentDirection = Direction.Right;
            }
        }
    }
    private void FixedUpdate()
    {
        isSkidding = false;
        currentVelocity = rb2D.velocity.x;
        if(currentDirection > 0)
        {
            if(currentVelocity < 0)
            {
                currentVelocity += (acceleration + friction) * Time.deltaTime;
                isSkidding = true;
            }
            else if(currentVelocity < maxVelocity)
            {
                currentVelocity += acceleration * Time.deltaTime;
                transform.localScale = new Vector2(1, 1);
            }
        }
        else if(currentDirection < 0)
        {
            if(currentVelocity > 0)
            {
                currentVelocity -= (acceleration + friction) * Time.deltaTime;
                isSkidding = true;
            }
            else if(currentVelocity > -maxVelocity)
            {
                currentVelocity -= acceleration * Time.deltaTime;
                transform.localScale = new Vector2(-1, 1);
            }
        }
        else
        {
            if(currentVelocity > 1f)
            {
                currentVelocity -= friction * Time.deltaTime;
            }
            else if(currentVelocity < -1f)
            {
                currentVelocity += friction * Time.deltaTime;
            }
            else
            {
                currentVelocity = 0;
            }
        }
        Vector2 velocity = new Vector2(currentVelocity, rb2D.velocity.y);
        rb2D.velocity = velocity;

        animaciones.Velocity(currentVelocity);
        animaciones.Skid(isSkidding);
    }
    void Jump()
    {
        if(!isJumping)
        {
            isJumping = true;
            Vector2 fuerza = new Vector2(0, jumpForce);
            rb2D.AddForce(fuerza, ForceMode2D.Impulse);
            animaciones.Jumping(true);
        }
    }
    void MoveRight()
    {
        Vector2 velocity = new Vector2(1f, 0);
        rb2D.velocity = velocity;
    }
    public void Dead()
    {
        inputMoveEnabled = false;
        rb2D.velocity = Vector2.zero;
        rb2D.gravityScale = 1;
        rb2D.AddForce(Vector2.up * 10f, ForceMode2D.Impulse); //6
    }
    public void BounceUp()
    {
        rb2D.velocity = Vector2.zero;
        rb2D.AddForce(Vector2.up * 15f, ForceMode2D.Impulse);
    }

    public void DownFlagPole()
    {
        inputMoveEnabled = false;
        rb2D.velocity = new Vector2(0, -5f);
    }
}