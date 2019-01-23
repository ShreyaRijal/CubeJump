using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class movement : MonoBehaviour {

    private PlatformerCharacter2D controls;
    private Rigidbody2D rigid;
    private Vector2 vec;
    public float speed = 0f;
    public float jump;
    bool grounded = false;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {

        float horizontal = Input.GetAxisRaw("Horizontal")*speed;

        MakeMovement(horizontal);

        if (grounded == true && rigid.velocity.y <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            grounded = false;

            GetComponent<Rigidbody2D>().velocity = new Vector2
                        (GetComponent<Rigidbody2D>().velocity.x, jump * 1.2f);

        }

    }

    private void MakeMovement(float horizontal)
    {
        rigid.velocity = new Vector2(horizontal, rigid.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }

}
