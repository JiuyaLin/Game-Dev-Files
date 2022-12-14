using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerMove : MonoBehaviour
{
    public float speed;
    public float decelerate;
    private float hSpeed = 0;
    private float vSpeed = 0;
    public Animator anim;
    private SpriteRenderer sprRender;
    public bool moveLeft;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sprRender = GetComponent<SpriteRenderer>();
        moveLeft = false;
    }


    // Update is called once per frame
    void Update()
    {
        
        //change the animation
        if (Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.D) ||
            Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.S))
        {
            anim.Play("Walk");
            if (Input.GetKeyDown(KeyCode.A))
            {
                sprRender.flipX = true;
            }
            else
            {
                sprRender.flipX = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.A) ||
            Input.GetKeyUp(KeyCode.D) ||
            Input.GetKeyUp(KeyCode.W) ||
            Input.GetKeyUp(KeyCode.S))
        {
            anim.Play("Idle");
        }


        //slow down gradually
        Vector3 curPos = transform.position;
        hSpeed = (float)(decelerate * hSpeed);
        vSpeed = (float)(decelerate * vSpeed);


        //move the player character
        if (Input.GetKey(KeyCode.A))
        {
            hSpeed = -speed;
            moveLeft = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            hSpeed = speed;
            moveLeft = false;
            
        }
        if (Input.GetKey(KeyCode.W))
        {
            vSpeed = speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vSpeed = -speed;
        }

        curPos.x += hSpeed;
        curPos.y += vSpeed;

        transform.position = curPos;



        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("to collect");
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
    }


}
