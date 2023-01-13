using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{  
    public float maxSpeed;
    Rigidbody2D rigid;
    Animator anim;

    SpriteRenderer spriteRenderer;

    void Awake() {
            rigid = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
    }

    void Update() {
        //stop Speed
        if(Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(0.5f * rigid.velocity.normalized.x,rigid.velocity.y);
        }
        // direction sprite
        else if(Input.GetButtonDown("Horizontal"))
        {
            spriteRenderer.flipX = (Input.GetAxisRaw("Horizontal") == -1); //조건연산자로 True ,False 보여줌
        }

        if(Mathf.Abs(rigid.velocity.x) < 0.5)
        {
            anim.SetBool("isWalking", false);
        }   
        else 
        {
            anim.SetBool("isWalking", true);
        }   
    }

    void FixedUpdate() {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h , ForceMode2D.Impulse);
        if(rigid.velocity.x > maxSpeed )
        {
            rigid.velocity = new Vector2(maxSpeed,rigid.velocity.y);
        }
        else if(rigid.velocity.x< maxSpeed * (-1))
        {
            rigid.velocity = new Vector2(maxSpeed*(-1),rigid.velocity.y);
        }

    }

}
