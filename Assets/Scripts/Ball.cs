using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : Move
{
    public float speed = 10;
    private bool isThrow = false;
    private Rigidbody2D rbBall;
    private Rigidbody2D rbPlayer;
    private ScoreManager sm;

    private void Start()
    {
        rbBall = GameObject.Find("Ball").GetComponent<Rigidbody2D>();
        rbPlayer = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        sm = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        InitPosBall();
    }

    void Update()
    {
        if(!GameManager.endGame)
        {
            if (!isThrow)
            {
                InitPosBall();

                if (base.RightMovement())
                {
                    base.MoveObject("right", rbBall);
                }
                else if (base.LeftMovement())
                {
                    base.MoveObject("left", rbBall);
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) || isThrow)
            {
                ThrowBall();
                OutOfRange();
            }
        }
       
    }

    private void ThrowBall()
    {
        isThrow = true;
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OutOfRange()
    {
        if(gameObject.transform.position.y > 4)
        {
            isThrow = false;
        }
    }

    private void InitPosBall()
    {
        gameObject.transform.position = new Vector3(rbPlayer.transform.position.x, -2.5f, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hoop"))
        {
            sm.scoreValue+= 1;
        }
    }

}
