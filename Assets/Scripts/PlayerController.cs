using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Move
{

    private Rigidbody2D rbPlayer;
    

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.endGame)
        {
            if (base.RightMovement())
            {
                base.MoveObject("right", rbPlayer);
            }
            else if (base.LeftMovement())
            {
                base.MoveObject("left", rbPlayer);
            }
        }
        
    }

    
}
